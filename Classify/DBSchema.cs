using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Classify
{
    class DBSchema
    {
        private static SQLiteConnection dbConnection;

        public static SQLiteConnection connection() 
        {
            return dbConnection;
        }

        public static void initialiseConnection()
        {
            String dbName = "ClassifyDB";
            String dbPath = dbName + ".sqlite";
            Boolean dbIsNew = !File.Exists(dbPath);
            if (dbIsNew) SQLiteConnection.CreateFile(dbPath);
            dbConnection = new SQLiteConnection("Data Source=" + dbName + ".sqlite;Version=3;");
            dbConnection.Open();
            if (dbIsNew)
            {
                SQLiteCommand fkOn = new SQLiteCommand("PRAGMA foreign_keys = ON;", dbConnection);
                fkOn.ExecuteNonQuery();

                String createModulesStm = "CREATE TABLE Modules (module_id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, code TEXT NOT NULL, year INTEGER NOT NULL, credits INTEGER NOT NULL)";
                SQLiteCommand command = new SQLiteCommand(createModulesStm, dbConnection);
                command.ExecuteNonQuery();

                String createAssessmentsStm = "CREATE TABLE Assessments (assessment_id INTEGER PRIMARY KEY AUTOINCREMENT, title TEXT NOT NULL, weight INTEGER NOT NULL, type TEXT NOT NULL, result INTEGER, module_id INTEGER, FOREIGN KEY(module_id) REFERENCES Modules(module_id) ON DELETE CASCADE ON UPDATE CASCADE)";
                command = new SQLiteCommand(createAssessmentsStm, dbConnection);
                command.ExecuteNonQuery();
            }
        }
    }

    public class Module
    {
        const String tableName =        "Modules";
        const String idColumn =         "module_id";
        const String nameColumn =       "name";
        const String codeColumn =       "code";
        const String yearColumn =       "year";
        const String creditsColumn =    "credits";

        private Int16 _id;
        public Int16 id
        {
            get { return _id; }
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
        private Int16 _year;
        public Int16 year
        {
            get { return _year; }
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
        private Int16 _credits;
        public Int16 credits
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
            this.id = results.GetInt16(0);
            this.name = results["name"] as String;
            this.code = results["code"] as String;
            this.year = results.GetInt16(3);
        }

        private Module(Int16 id, String name, String code, Int16 year, Int16 credits) {
            this.id = id;
            this.name = name;
            this.code = code;
            this.year = year;
            this.credits = credits;
        }

        public static Module create(String name, String code, Int16 year, Int16 credits)
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
            return new Module(reader.GetInt16(0), name, code, year, credits);
        }
    }

    public class Assessment
    {
        const String tableName = "Assessments";
        const String idColumn = "assessment_id";
        const String titleColumn = "title";
        const String weightColumn = "weight";
        const String typeColumn = "type";
        const String resultColumn = "result";
        const String moduleIdColumn = "module_id";

        private Int16? _id;
        public Int16? id
        {
            get { return _id; }
            set { }
        }

        private String _title;
        public String title
        {
            get { return _title; }
            set
            {
                if (!value.Equals(_title))
                {
                    if (id > 0)
                    {
                        String stm = "UPDATE " + tableName + " SET " + titleColumn + " @title WHERE " + idColumn + " = @id";
                        SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
                        command.Parameters.Add(new SQLiteParameter("@id", id));
                        command.Parameters.Add(new SQLiteParameter("@WHERE", value));
                    }
                    _title = value;
                }
            }
        }
        private Int16? _weight;
        public Int16? weight
        {
            get { return _weight; }
            set
            {
                if (value != _weight)
                {
                    if (id > 0)
                    {
                        String stm = "UPDATE " + tableName + " SET " + weightColumn + " @weight WHERE " + idColumn + " = @id";
                        SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
                        command.Parameters.Add(new SQLiteParameter("@id", id));
                        command.Parameters.Add(new SQLiteParameter("@weight", value));
                    }
                    _weight = value;
                }
            }
        }

        private String _type;
        public String type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    if (id > 0)
                    {
                        String stm = "UPDATE " + tableName + " SET " + typeColumn + " @type WHERE " + idColumn + " = @id";
                        SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
                        command.Parameters.Add(new SQLiteParameter("@id", id));
                        command.Parameters.Add(new SQLiteParameter("@type", value));
                    }
                    _type = value;
                }
            }
        }

        private Int16? _result;
        public Int16? result
        {
            get { return _result; }
            set
            {
                if (value != _result)
                {
                    if (id > 0)
                    {
                        String stm = "UPDATE " + tableName + " SET " + resultColumn + " @result WHERE " + idColumn + " = @id";
                        SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
                        command.Parameters.Add(new SQLiteParameter("@id", id));
                        command.Parameters.Add(new SQLiteParameter("@result", value));
                    }
                    _result = value;
                }
            }
        }

        private Int16? _moduleId;
        public Int16? moduleId
        {
            get { return _moduleId; }
            set
            {
                if (value != _moduleId)
                {
                    if (id > 0)
                    {
                        String stm = "UPDATE " + tableName + " SET " + moduleIdColumn + " @moduleId WHERE " + idColumn + " = @id";
                        SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
                        command.Parameters.Add(new SQLiteParameter("@id", id));
                        command.Parameters.Add(new SQLiteParameter("@moduleId", value));
                    }
                    _moduleId = value;
                }
            }
        }

        public Assessment(SQLiteDataReader results)
        {
            this.id = results[idColumn] as Int16?;
            this.title = results[titleColumn] as String;
            this.weight = results[weightColumn] as Int16?;
            this.type = results[typeColumn] as String;
            this.result = results[resultColumn] as Int16?;
        }

        private Assessment(Int16 id, String title, Int16 weight, String type, Int16? result, Int16? moduleId)
        {
            this.id = id;
            this.title = title;
            this.weight = weight;
            this.type = type;
            this.result = result;
            this.moduleId = moduleId;
        }

        public static Assessment create(String title, Int16 weight, String type, Int16 moduleId)
        {
            String stm = "INSERT INTO " + tableName + " (title, weight, type, module_id) VALUES(@title, @weight, @type, @moduleId)";
            SQLiteCommand insert = new SQLiteCommand(stm, DBSchema.connection());
            insert.Parameters.Add(new SQLiteParameter("@title", title));
            insert.Parameters.Add(new SQLiteParameter("@weight", weight));
            insert.Parameters.Add(new SQLiteParameter("@type", type));
            insert.Parameters.Add(new SQLiteParameter("@moduleId", moduleId));
            insert.ExecuteNonQuery();
            SQLiteCommand insertedID = new SQLiteCommand("SELECT LAST_INSERT_ROWID()", DBSchema.connection());
            SQLiteDataReader reader = insertedID.ExecuteReader();
            reader.Read();
            return new Assessment(reader.GetInt16(0), title, weight, type, null, moduleId);
        }
        public static Assessment create(String title, Int16 weight, String type, Int16 result, Int16 moduleId)
        {
            String stm = "INSERT INTO " + tableName + " (title, weight, type, result, module_id) VALUES(@title, @weight, @type, @result, @moduleId)";
            SQLiteCommand insert = new SQLiteCommand(stm, DBSchema.connection());
            insert.Parameters.Add(new SQLiteParameter("@title", title));
            insert.Parameters.Add(new SQLiteParameter("@weight", weight));
            insert.Parameters.Add(new SQLiteParameter("@type", type));
            insert.Parameters.Add(new SQLiteParameter("@result", result));
            insert.Parameters.Add(new SQLiteParameter("@moduleId", moduleId));
            insert.ExecuteNonQuery();
            SQLiteCommand insertedID = new SQLiteCommand("SELECT LAST_INSERT_ROWID()", DBSchema.connection());
            SQLiteDataReader reader = insertedID.ExecuteReader();
            reader.Read();
            return new Assessment(reader.GetInt16(0), title, weight, type, result, moduleId);
        }
    }
}
