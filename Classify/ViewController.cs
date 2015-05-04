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

            calcStats();
        }

        private void calcStats()
        {
            List<Module> yr1 = modulesForYear(1);
            List<Module> yr2 = modulesForYear(2);
            List<Module> yr3 = modulesForYear(3);

            yr1ModCountLabel.Text = yr1.Count.ToString();
            yr1AvgScore.Text = averageScore(yr1).ToString();
            Module mod1 = bestModule(yr1);
            if (mod1 != null)
            {
                yr1BestMod.Text = mod1.name;
                yr1BestModScore.Text = mod1.averageScore().ToString();
            }
            else
            {
                yr1BestMod.Text = "No scores entered";
                yr1BestModScore.Text = "No scores entered";
            }

            Int16 yr2Average = averageScore(yr2);
            yr2ModCountLabel.Text = yr2.Count.ToString();
            yr2AvgScore.Text = yr2Average.ToString();
            Module mod2 = bestModule(yr2);
            if (mod2 != null)
            {
                yr2BestMod.Text = mod2.name;
                yr2BestModScore.Text = mod2.averageScore().ToString();
            }
            else
            {
                yr2BestMod.Text = "No scores entered";
                yr2BestModScore.Text = "No scores entered";
            }

            Int16 yr3Average = averageScore(yr3);
            yr3ModCountLabel.Text = yr3.Count.ToString();
            yr3AvgScore.Text = yr3Average.ToString();
            Module mod3 = bestModule(yr3);
            if (mod3 != null)
            {
                yr3BestMod.Text = mod3.name;
                yr3BestModScore.Text = mod3.averageScore().ToString();
            }
            else
            {
                yr3BestMod.Text = "No scores entered";
                yr3BestModScore.Text = "No scores entered";
            }

            String classification;
            if (yr2Average > 60 && yr3Average > 70)
            {
                classification = "1st";
            }
            else if (yr2Average > 50 && yr3Average > 60)
            {
                classification = "2:1";
            }
            else if (yr2Average > 40 && yr3Average > 60)
            {
                classification = "2:2";
            }
            else if (yr2Average > 40 && yr3Average > 40)
            {
                classification = "3rd";
            }
            else
            {
                classification = "Fail";
            }
            degClassLabel.Text = classification;

        }

        private List<Module> modulesForYear(Int16 year)
        {
            List<Module> results = new List<Module>();
            String stm = "SELECT * FROM Modules WHERE year = @yr";
            SQLiteCommand cm = new SQLiteCommand(stm, DBSchema.connection());
            cm.Parameters.Add(new SQLiteParameter("@yr", year));
            SQLiteDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                results.Add(new Module(dr));
            }
            return results;
        }

        private Int16 averageScore(List<Module> year)
        {
            Int16 i = 0;
            Int16 total = 0;
            foreach (Module mod in year)
            {
                total += mod.averageScore();
                i++;
            }
            return Convert.ToInt16((i > 0) ? total / i : 0);
        }

        private Module bestModule(List<Module> year) {
            Module best = null;
            foreach (Module mod in year) 
            {
                if (best == null || mod.averageScore() > best.averageScore()) best = mod;
            }
            return best;
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
    }
}
