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
        ModuleTableView moduleTable;
        public ViewController()
        {
            InitializeComponent();

            moduleTable = new ModuleTableView(1);
            moduleTable.Location = new Point(0, 20);
            moduleTable.Size = new Size(year1TabPage.Size.Width, year1TabPage.Size.Height - 20);
            moduleTable.BackColor = Color.Yellow;
            year1TabPage.Controls.Add(moduleTable);

            addEditModView = new AddEditModuleView(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addEditModView.Size = new Size(year1TabPage.Size.Width, year1TabPage.Size.Height);
            addEditModView.Location = new Point(0, 0);
            year1TabPage.Controls.Add(addEditModView);
            addEditModView.BringToFront();
        }

        public void newModuleCreated(Module module)
        {
            year1TabPage.Controls.Remove(addEditModView);
            moduleTable.reloadData();
        }
    }
}
