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
    public partial class ModuleTableView : UserControl
    {
        private DataGridView table;
        private Int16 year;
        public ModuleTableView(Int16 year)
        {
            this.year = year;
            initialiseTable();
        }

        private void initialiseTable()
        {
            table = new DataGridView();
            table.Anchor =  AnchorStyles.Bottom |
                            AnchorStyles.Right |
                            AnchorStyles.Top |
                            AnchorStyles.Left;
            table.Location = new Point(0, 0);
            table.Size = new Size(this.Size.Width, this.Size.Height);
            table.RowHeadersVisible = false;
            String stm = "SELECT name, code, credits FROM Modules WHERE year = @year";
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(stm, DBSchema.connection());
            adapt.SelectCommand.Parameters.Add(new SQLiteParameter("@year", year));
            DataSet ds = new DataSet();
            adapt.Fill(ds, "Modules");
            table.DataSource = ds.Tables["Modules"];
            this.Controls.Add(table);
        }

        public void reloadData() {
            initialiseTable();
        }
    }
}
