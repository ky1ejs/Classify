using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classify
{
    public class Module
    {
        const String tableName =        "Modules";
        const String idColumn =         "module_id";
        const String nameColumn =       "name";
        const String codeColumn =       "code";
        const String yearColumn =       "year";
        const String creditsColumn =    "credits";

        private Int64? _id;
        public Int64 id
        {
            get { return _id.Value; }
            set { }
        }

        private String _name;
        public String name
        {
            get { return _name; }
            set
            {
                if (!value.Equals(_name))
                {
                    if (id > 0)
                    {
                        String stm = "UPDATE " + tableName + " SET " + nameColumn + " @name WHERE " + idColumn + " = @id";
                        SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
                        command.Parameters.Add(new SQLiteParameter("@id", id));
                        command.Parameters.Add(new SQLiteParameter("@name", value));
                    }
                    _name = value;
                }
            }   
        }
        private String _code;
        public String code
        {
            get { return _code; }
            set
            {
                if (!value.Equals(_code))
                {
                    if (id > 0)
                    {
                        String stm = "UPDATE " + tableName + " SET " + codeColumn + " @code WHERE " + idColumn + " = @id";
                        SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
                        command.Parameters.Add(new SQLiteParameter("@id", id));
                        command.Parameters.Add(new SQLiteParameter("@code", value));
                    }
                    _code = value;
                }
            }
        }
        private Int64? _year;
        public Int64 year
        {
            get { return _year.Value; }
            set
            {
                if (value != _year)
                {
                    if (id > 0)
                    {
                        String stm = "UPDATE " + tableName + " SET " + yearColumn + " @year WHERE " + idColumn + " = @id";
                        SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
                        command.Parameters.Add(new SQLiteParameter("@id", id));
                        command.Parameters.Add(new SQLiteParameter("@year", value));
                    }
                    _year = value;
                }
            }
        }
        private Int64 _credits;
        public Int64 credits
        {
            get { return _credits; }
            set
            {
                if (value != _credits)
                {
                    if (id > 0)
                    {
                        String stm = "UPDATE " + tableName + " SET " + creditsColumn + " @credits WHERE " + idColumn + " = @id";
                        SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
                        command.Parameters.Add(new SQLiteParameter("@id", id));
                        command.Parameters.Add(new SQLiteParameter("@credits", value));
                    }
                    _credits = value;
                }
            }
        }

        public Module(SQLiteDataReader results) {
            this._id = results[idColumn] as Int64?;
            this._name = results[nameColumn] as String;
            this._code = results[codeColumn] as String;
            this._year = results[yearColumn] as Int64?;
        }

        private Module(Int64 id, String name, String code, Int64 year, Int64 credits) {
            this._id = id;
            this._name = name;
            this._code = code;
            this._year = year;
            this._credits = credits;
        }

        public static Module create(String name, String code, Int64 year, Int64 credits)
        {
            String stm = "INSERT INTO " + tableName + " (name, code, year, credits) VALUES(@name, @code, @year, @credits)";
            SQLiteCommand insert = new SQLiteCommand(stm, DBSchema.connection());
            insert.Parameters.Add(new SQLiteParameter("@name", name));
            insert.Parameters.Add(new SQLiteParameter("@code", code));
            insert.Parameters.Add(new SQLiteParameter("@year", year));
            insert.Parameters.Add(new SQLiteParameter("@credits", credits));
            insert.ExecuteNonQuery();
            SQLiteCommand insertedID = new SQLiteCommand("SELECT LAST_INSERT_ROWID()", DBSchema.connection());
            SQLiteDataReader reader = insertedID.ExecuteReader();
            reader.Read();
            return new Module(reader.GetInt64(0), name, code, year, credits);
        }

        public struct ModuleScore
        {
            public Module module;
            public Int64? percentageScore;
            public Int64? creditScore;
            public Int64? percentageAttempted;
            public Int64? averageAssessmentResult;
        }

        public ModuleScore score()
        {
            String stm = "SELECT * FROM Assessments WHERE module_id = @module";
            SQLiteCommand cm = new SQLiteCommand(stm, DBSchema.connection());
            cm.Parameters.Add(new SQLiteParameter("@module", id));
            SQLiteDataReader dr = cm.ExecuteReader();
            List<Assessment> assessments = Assessment.assessmentsFromDataReader(dr);
            Int64? percentageScore = null;
            Int64? totalPercentages = null;
            Int64? totalWeight = null;
            foreach (Assessment assessment in assessments)
            {
                if (assessment.result != null)
                {
                    if (percentageScore == null) percentageScore = 0;
                    if (totalPercentages == null) totalPercentages = 0;
                    percentageScore += Convert.ToInt64((float)assessment.weight * ((float)assessment.result.Value / 100F));
                    totalPercentages += assessment.result.Value;
                }
                if (totalWeight == null) totalWeight = 0;
                totalWeight += assessment.weight;
            }
            ModuleScore score;
            score.module = this;
            score.percentageScore = percentageScore;
            score.creditScore = this.credits * (percentageScore / 100);
            score.percentageAttempted = totalWeight;
            score.averageAssessmentResult = totalPercentages / assessments.Count;
            return score;
            
        }

        public struct ModulePredition
        {
            public ModuleScore actualScore;
            public Int64? predictedPercentageScore;
            public Int64? predictedCreditScore;
            public Int64? creditsPredicted;
        }

        public ModulePredition prediction()
        {
            ModulePredition prediction;
            prediction.actualScore = score();
            prediction.creditsPredicted = 100 - prediction.actualScore.percentageAttempted;
            prediction.predictedPercentageScore = Convert.ToInt64((float)prediction.actualScore.percentageScore + ((float)prediction.creditsPredicted * ((float)prediction.actualScore.averageAssessmentResult / 100F)));
            prediction.predictedCreditScore = Convert.ToInt64((float)this.credits * ((float)prediction.predictedPercentageScore / 100F));
            return prediction;
        }

        public struct YearScore
        {
            public Int64 year;
            public Int64? percentageScore;
            public Int64? creditScore;
            //public Int64? best105CreditPercentage;
            public ModuleScore? bestModule;
            public Int64? averageModulePercentage;
            public Int64? moduleCount;
            public Int64? creditsAttempted;
        }

        public static YearScore scoreForYear(Int64 year)
        {
            List<Module> mods = modulesForYear(year);
            ModuleScore? bestModule = null;
            Int64? totalPercentage = null;
            Int64? totalCreditsScored = null;
            Int64? totalCreditsAttempted = null;
            foreach (Module mod in mods)
            {
                ModuleScore modScore = mod.score();
                if (bestModule == null || modScore.percentageScore > bestModule.Value.percentageScore) bestModule = modScore;
                if (modScore.percentageScore != null)
                {
                    if (totalPercentage == null) totalPercentage = 0;
                    totalPercentage += modScore.percentageScore.Value;
                }
                if (modScore.creditScore != null)
                {
                    if (totalCreditsScored == null) totalCreditsScored = 0;
                    totalCreditsScored += modScore.creditScore.Value;
                }
                if (totalCreditsAttempted == null) totalCreditsAttempted = 0;
                totalCreditsAttempted += mod.credits;
            }
            YearScore score;
            score.year = year;
            score.creditScore = totalCreditsScored;
            if (totalCreditsScored != null)
            {
                score.percentageScore = Convert.ToInt64((float)totalCreditsScored.Value / (120F / 100F));
            }
            else
            {
                score.percentageScore = null;
            }
            score.bestModule = bestModule;
            score.averageModulePercentage = totalPercentage / mods.Count;
            score.moduleCount = mods.Count;
            score.creditsAttempted = totalCreditsAttempted;
            return score;
        }

        public struct YearPrediction {
            public Int64 year;
            public Int64? percentageScore;
            public Int64? creditScore;
            //public Int64? best105CreditPercentage;
            public ModulePredition? bestModule;
            public Int64? averageModulePercentage;
            public Int64? moduleCount;
            public Int64? creditsAttempted;
            public Int64? predictedPercentageScore;
            public Int64? predictedCreditScore;
            public Int64? creditsPredicted;
        }

        public static YearPrediction predictionForYear(Int64 year)
        {
            List<Module> mods = modulesForYear(year);
            ModulePredition? bestModule = null;
            Int64? totalPercentage = null;
            Int64? totalCreditsScored = null;
            Int64? totalCreditsAttempted = null;
            foreach (Module mod in mods)
            {
                ModulePredition modPrediction = mod.prediction();
                if (bestModule == null || modPrediction.predictedPercentageScore > bestModule.Value.predictedPercentageScore) bestModule = modPrediction;
                if (modPrediction.predictedPercentageScore != null)
                {
                    if (totalPercentage == null) totalPercentage = 0;
                    totalPercentage += modPrediction.predictedPercentageScore.Value;
                }
                if (modPrediction.predictedCreditScore != null)
                {
                    if (totalCreditsScored == null) totalCreditsScored = 0;
                    totalCreditsScored += modPrediction.predictedCreditScore.Value;
                }
                if (totalCreditsAttempted == null) totalCreditsAttempted = 0;
                totalCreditsAttempted += mod.credits;
            }
            YearPrediction prediction;
            prediction.year = year;
            prediction.creditScore = totalCreditsScored;
            prediction.bestModule = bestModule;
            prediction.averageModulePercentage = totalPercentage / mods.Count;
            prediction.moduleCount = mods.Count;
            prediction.creditsAttempted = totalCreditsAttempted;
            prediction.creditsPredicted = 120 - prediction.creditsAttempted;
            if (totalCreditsScored != null)
            {
                prediction.percentageScore = Convert.ToInt64((float)totalCreditsScored.Value / (120F / 100F));
                prediction.predictedPercentageScore = Convert.ToInt64((float)prediction.percentageScore.Value + ((float)prediction.creditsPredicted.Value * ((float)prediction.averageModulePercentage / 100F)));
                prediction.predictedCreditScore = Convert.ToInt64(120F * ((float)prediction.predictedPercentageScore / 100F));
            }
            else
            {
                prediction.percentageScore = null;
                prediction.predictedPercentageScore = null;
                prediction.predictedCreditScore = null;
            }
            return prediction;
        }

        public static List<Module> modulesForYear(Int64 year)
        {
            List<Module> results = new List<Module>();
            String stm = "SELECT * FROM Modules WHERE year = @yr";
            SQLiteCommand cm = new SQLiteCommand(stm, DBSchema.connection());
            cm.Parameters.Add(new SQLiteParameter("@yr", year));
            SQLiteDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                results.Add(new Module(dr));
            }
            return results;
        }

        public static List<Module> modulesFromDataReader(SQLiteDataReader dr)
        {
            List<Module> list = new List<Module>();
            while (dr.Read())
            {
                list.Add(new Module(dr));
            }
            return list;
        }
    }
}
