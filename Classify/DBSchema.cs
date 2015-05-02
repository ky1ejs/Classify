using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

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
                String createModulesStm = "CREATE TABLE Modules (module_id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, code TEXT NOT NULL, credits INT NOT NULL)";
                SQLiteCommand command = new SQLiteCommand(createModulesStm, dbConnection);
                command.ExecuteNonQuery();
            }
        }
    }

    class Module
    {
        static const String tableName = "Modules";
        static const String idColumn = "module_id";
        static const String nameColumn = "name";
        static const String codeColumn = "code";
        static const String yearColumn = "year";
        Int16 id
        {
            get { return id; }
            set { }
        }
        String name
        {
            get { return name; }
            set
            {
                if (!value.Equals(name) && id > 0)
                {
                    String stm = "UPDATE " + tableName + " SET " + nameColumn + " = '" + value + "' WHERE " + idColumn + " = " id;
                    SQLiteCommandBuilder builder = new SQLiteCommandBuilder()
                }
            }   
        }
        String code;
        Int16 year;

        public Module(SQLiteDataReader results) {
            this.id = results.GetInt16(0);
            this.name = results["name"] as String;
            this.code = results["code"] as String;
            this.year = results.GetInt16(3);
        }
    }
}
