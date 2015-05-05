using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classify
{
    public class Assessment
    {
        const String tableName = "Assessments";
        const String idColumn = "assessment_id";
        const String titleColumn = "title";
        const String weightColumn = "weight";
        const String typeColumn = "type";
        const String resultColumn = "result";
        const String moduleIdColumn = "module_id";

        private Int64? _id;
        public Int64 id
        {
            get { return _id.Value; }
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
        private Int64? _weight;
        public Int64 weight
        {
            get { return _weight.Value; }
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

        private Int64? _result;
        public Int64? result
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

        private Int64? _moduleId;
        public Int64 moduleId
        {
            get { return _moduleId.Value; }
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
            this._id = results[idColumn] as Int64?;
            this._title = results[titleColumn] as String;
            this._weight = results[weightColumn] as Int64?;
            this._type = results[typeColumn] as String;
            this._result = results[resultColumn] as Int64?;
        }

        private Assessment(Int64 id, String title, Int64 weight, String type, Int64? result, Int64? moduleId)
        {
            this._id = id;
            this._title = title;
            this._weight = weight;
            this._type = type;
            this._result = result;
            this._moduleId = moduleId;
        }

        public static Assessment create(String title, Int64 weight, String type, Int64 moduleId)
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
            return new Assessment(reader.GetInt64(0), title, weight, type, null, moduleId);
        }
        public static Assessment create(String title, Int64 weight, String type, Int64 result, Int64 moduleId)
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
            return new Assessment(reader.GetInt64(0), title, weight, type, result, moduleId);
        }

        public static List<Assessment> assessmentsFromDataReader(SQLiteDataReader dr)
        {
            List<Assessment> list = new List<Assessment>();
            while (dr.Read())
            {
                list.Add(new Assessment(dr));
            }
            return list;
        }
    }
}
