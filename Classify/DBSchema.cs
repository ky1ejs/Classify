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
                String createModulesStm = "CREATE TABLE Modules (module_id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, code TEXT NOT NULL, year INT NOT NULL, credits INT NOT NULL)";
                SQLiteCommand command = new SQLiteCommand(createModulesStm, dbConnection);
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
}
