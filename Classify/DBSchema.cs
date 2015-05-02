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
}
