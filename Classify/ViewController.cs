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
            String select = "SELECT * FROM Modules";
            SQLiteCommand command = new SQLiteCommand(select, DBSchema.connection());
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read()) label1.Text = reader["name"] as String;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditModuleView addEdit = new AddEditModuleView();
            addEdit.Size = new Size(200, 200);
            addEdit.Location = new Point(100, 100);
            year1TabPage.Controls.Add(addEdit);
        }
    }
}
