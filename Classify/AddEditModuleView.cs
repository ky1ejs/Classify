using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Classify
{
    public partial class AddEditModuleView : UserControl
    {
        public AddEditModuleView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = nameTF.Text;
            String code = codeTF.Text;
            int year;
            int.TryParse(yearTF.Text, out year);
            String insert = "INSERT INTO Modules (name, code, credits) VALUES('" + name + "', '" + code + "', " + yearTF.Text + ")";
            SQLiteCommand command = new SQLiteCommand(insert, DBSchema.connection());
            command.ExecuteNonQuery();
        }
    }
}
