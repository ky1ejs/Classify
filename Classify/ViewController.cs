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
            addEditModView.Anchor = AnchorStyles.Bottom |
                                    AnchorStyles.Right |
                                    AnchorStyles.Top |
                                    AnchorStyles.Left;

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

            tabControl.Selected += this.tab_Selected;

            calcStats();
        }

        private void tab_Selected(Object sender, TabControlEventArgs e) 
        {
            if (e.TabPage == homeTabPage)
            {
                calcStats();
            }
        }

        private void calcStats()
        {
            Module.YearScore yr1 = Module.scoreForYear(1);
            Module.YearScore yr2 = Module.scoreForYear(2);
            Module.YearScore yr3 = Module.scoreForYear(3);

            yr1ModCountLabel.Text = yr1.moduleCount.Value.ToString();
            yr1AvgScoreLabel.Text = (yr1.averageModulePercentage != null) ? yr1.averageModulePercentage.Value.ToString() : "No assessments attempted";
            if (yr1.bestModule != null)
            {
                yr1BestModLabel.Text = yr1.bestModule.Value.module.name;
                yr1BestModScoreLabel.Text = yr1.bestModule.Value.percentageScore.ToString();
            }

            yr2ModCountLabel.Text = yr2.moduleCount.Value.ToString();
            yr2AvgScoreLabel.Text = yr2.averageModulePercentage.ToString();
            if (yr2.bestModule != null)
            {
                yr2BestModLabel.Text = yr2.bestModule.Value.module.name;
                yr2BestModScoreLabel.Text = yr2.bestModule.Value.percentageScore.ToString();
            }

            yr3ModCountLabel.Text = yr3.moduleCount.Value.ToString();
            yr3AvgScoreLabel.Text = yr3.averageModulePercentage.ToString();
            if (yr3.bestModule != null)
            {
                yr3BestModLabel.Text = yr3.bestModule.Value.module.name;
                yr3BestModScoreLabel.Text = yr3.bestModule.Value.percentageScore.ToString();
            }

            String classification;
            if (yr2.averageModulePercentage > 60 && yr3.averageModulePercentage > 70)
            {
                classification = "1st";
            }
            else if (yr2.averageModulePercentage > 50 && yr3.averageModulePercentage > 60)
            {
                classification = "2:1";
            }
            else if (yr2.averageModulePercentage > 40 && yr3.averageModulePercentage > 50)
            {
                classification = "2:2";
            }
            else if (yr2.averageModulePercentage > 40 && yr3.averageModulePercentage > 40)
            {
                classification = "3rd";
            }
            else
            {
                classification = "Fail";
            }
            degClassLabel.Text = classification;

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
        }

        private void addModuleButton_Click(object sender, EventArgs e)
        {
            this.Controls.Add(addEditModView);
            addEditModView.Size = new Size(this.Size.Width, this.Size.Height);
            addEditModView.BringToFront();
        }

        private void predictOnButton_Click(object sender, EventArgs e)
        {

        }
    }
}
