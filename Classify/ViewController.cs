using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classify
{
    public partial class ViewController : Form
    {
        public ViewController()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.year1TabPage.BackColor = Color.Azure;
            String dbPath = "ClassifyDB.sqlite";
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile("ClassifyDB.sqlite");
            }
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

        }
    }
}
