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
}
