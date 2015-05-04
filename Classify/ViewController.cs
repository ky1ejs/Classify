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
    public partial class ViewController : Form, AddEditModuleViewDelegate
    {
        AddEditModuleView addEditModView;
        ModuleTableView year1Table;
        ModuleTableView year2Table;
        ModuleTableView year3Table;
        public ViewController()
        {
            InitializeComponent();

            addModuleButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            addEditModView = new AddEditModuleView(this);
            addEditModView.Location = new Point(0, 0);
            addEditModView.Size = new Size(this.Size.Width, this.Size.Height);

            tabControl.Anchor = AnchorStyles.Bottom |
                                AnchorStyles.Right |
                                AnchorStyles.Top |
                                AnchorStyles.Left;

            year1Table = new ModuleTableView(1);
            year1Table.Anchor = AnchorStyles.Bottom |
                                AnchorStyles.Right |
                                AnchorStyles.Top |
                                AnchorStyles.Left;
            year1Table.Location = new Point(0, 0);
            year1Table.Size = new Size(year1TabPage.Size.Width, year1TabPage.Size.Height);
            year1TabPage.Controls.Add(year1Table);

            year2Table = new ModuleTableView(2);
            year2Table.Anchor = AnchorStyles.Bottom |
                                AnchorStyles.Right |
                                AnchorStyles.Top |
                                AnchorStyles.Left;
            year2Table.Location = new Point(0, 0);
            year2Table.Size = new Size(year2TabPage.Size.Width, year2TabPage.Size.Height);
            year2TabPage.Controls.Add(year2Table);

            year3Table = new ModuleTableView(3);
            year3Table.Anchor = AnchorStyles.Bottom |
                                AnchorStyles.Right |
                                AnchorStyles.Top |
                                AnchorStyles.Left;
            year3Table.Location = new Point(0, 0);
            year3Table.Size = new Size(year2TabPage.Size.Width, year2TabPage.Size.Height);
            year3TabPage.Controls.Add(year3Table);
        }

        public void newModuleCreated(Module module)
        {
            year1TabPage.Controls.Remove(addEditModView);
            switch (module.year)
            {
                case 1:
                    year1Table.reloadData();
                    break;

                case 2:
                    year2Table.reloadData();
                    break;

                case 3:
                    year3Table.reloadData();
                    break;
                    
                default:
                    break;
            }
            year1Table.reloadData();
            this.Controls.Remove(addEditModView);
        }

        private void addModuleButton_Click(object sender, EventArgs e)
        {
            this.Controls.Add(addEditModView);
            addEditModView.BringToFront();
        }
    }
}
