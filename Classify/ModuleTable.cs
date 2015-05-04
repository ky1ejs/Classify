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
        private TableLayoutPanel table;
        private Int16 year;
        public ModuleTableView(Int16 year)
        {
            this.year = year;
            initialiseTable();
        }

        private void initialiseTable()
        {
            if (table != null) this.Controls.Remove(table);
            table = new TableLayoutPanel();
            table.Location = new Point(0, 0);
            table.Size = new Size(this.Size.Width, this.Size.Height);

            String stm = "SELECT * FROM Modules WHERE year = @year";
            SQLiteCommand command = new SQLiteCommand(stm, DBSchema.connection());
            command.Parameters.Add(new SQLiteParameter("@year", year));
            SQLiteDataReader results = command.ExecuteReader();
            table.ColumnCount = 5;
            table.RowCount = results.StepCount;
            if (results.StepCount > 0)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                Point labelOrigin = new Point(0, 0);
                Size labelSize = new Size(100, 30);
                int i = 0;
                while (results.Read())
                {
                    Module moduleForRow = new Module(results);
                    Label nameLabel = new Label();
                    Label codeLabel = new Label();
                    Label yearLabel = new Label();
                    Label creditsLabel = new Label();
                    nameLabel.Location = labelOrigin;
                    codeLabel.Location = labelOrigin;
                    yearLabel.Location = labelOrigin;
                    creditsLabel.Location = labelOrigin;
                    nameLabel.Size = labelSize;
                    codeLabel.Size = labelSize;
                    yearLabel.Size = labelSize;
                    creditsLabel.Size = labelSize;
                    nameLabel.Text = moduleForRow.name;
                    codeLabel.Text = moduleForRow.code;
                    yearLabel.Text = moduleForRow.year.ToString();
                    creditsLabel.Text = moduleForRow.credits.ToString();
                    table.Controls.Add(nameLabel, 0, i);
                    table.Controls.Add(codeLabel, 1, i);
                    table.Controls.Add(yearLabel, 2, i);
                    table.Controls.Add(creditsLabel, 3, i);
                    i++;
                }
            }
            this.Controls.Add(table);
        }

        public void reloadData() {
            initialiseTable();
        }
    }
}
