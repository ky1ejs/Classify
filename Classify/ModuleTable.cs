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
        private List<Module> modules;
        private Int32 year;
        private ModuleDetailView detailView;
        public ModuleTableView(Int32 year)
        {
            this.year = year;
            initialiseTable();
        }

        private void initialiseTable()
        {
            if (this.table != null) this.Controls.Remove(this.table);
            table = new DataGridView();
            table.Dock = DockStyle.Fill;
            table.Size = new Size(this.Size.Width, this.Size.Height);
            table.RowHeadersVisible = false;
            table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            table.MultiSelect = false;
            String stm = "SELECT name, code, credits FROM Modules WHERE year = @year";
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(stm, DBSchema.connection());
            adapt.SelectCommand.Parameters.Add(new SQLiteParameter("@year", year));
            DataSet ds = new DataSet();
            adapt.Fill(ds, "Modules");
            table.DataSource = ds.Tables["Modules"];
            this.Controls.Add(table);
            stm = "SELECT * FROM Modules WHERE year = @year";
            SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
            command.Parameters.Add(new SQLiteParameter("@year", year));
            SQLiteDataReader dr = command.ExecuteReader();
            modules = new List<Module>();
            while (dr.Read())
            {
                modules.Add(new Module(dr));
            }
            table.ClearSelection();
            table.CellClick += new DataGridViewCellEventHandler(this.rowSelected);
        }

        private void rowSelected(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = table.CurrentCell.RowIndex;
            if (selectedRow > -1)
            {
                if (detailView != null) this.Controls.Remove(detailView);
                detailView = new ModuleDetailView(modules[selectedRow]);
                detailView.Location = new Point(0, 0);
                detailView.Size = new Size(this.Size.Width, this.Size.Height);
                detailView.Dock = DockStyle.Fill;
                this.Controls.Add(detailView);
                detailView.BringToFront();
                table.ClearSelection();
            }
        }

        public void reloadData() {
            initialiseTable();
        }
    }
}
