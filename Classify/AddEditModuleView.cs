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
        private WeakReference<AddEditModuleViewDelegate> del;
        private Button selectedYearButton;
        public AddEditModuleView(AddEditModuleViewDelegate aDelegate)
        {
            InitializeComponent();
            foreach (Control con in this.Controls)
            {
                con.Anchor = AnchorStyles.None;
            }
            this.del = new WeakReference<AddEditModuleViewDelegate>(aDelegate);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String name = nameTF.Text;
            String code = codeTF.Text;
            int year = 0;
            Boolean yearParsed;
            if (selectedYearButton == null) yearParsed = false;
            else yearParsed = int.TryParse(selectedYearButton.Text, out year);
            int credits;
            Boolean creditsParsed = int.TryParse(creditsTF.Text, out credits);

            String mbMessage = null;
            if (name.Length == 0)
            {
                mbMessage = "- Please enter a name";
            }
            if (code.Length == 0)
            {
                if (mbMessage == null) mbMessage = "";
                mbMessage += "\n- Please enter a code";
            }
            if (!yearParsed)
            {
                if (mbMessage == null) mbMessage = "";
                mbMessage = "\n- Please select a year";
            }
            if (!creditsParsed)
            {
                if (mbMessage == null) mbMessage = "";
                mbMessage = "\n- Please enter a valid number of credits";
            }
            if (mbMessage != null)
            {
                MessageBox.Show(mbMessage, "Missing or invalid details");
                return;
            }

            if (credits > 120)
            {
                MessageBox.Show("A year can be no bigger than 120 credits, therefore a module can be no bigger than 120 credits.", "Missing or invalid details");
                return;
            }
            else
            {
                String stm = "SELECT SUM(credits) AS total_credits FROM Modules WHERE year = @year";
                SQLiteCommand cm = new SQLiteCommand(stm, DBSchema.connection());
                cm.Parameters.Add(new SQLiteParameter("@year", year));
                SQLiteDataReader dr = cm.ExecuteReader();
                dr.Read();
                Int64? totalCreditsForYear = dr["total_credits"] as Int64?;
                if (totalCreditsForYear != null && totalCreditsForYear.Value + credits > 120)
                {
                    MessageBox.Show(String.Format("You may only have 120 per year. There are already {0} credits in this year. You have entered {1}.", totalCreditsForYear, credits), "Missing or invalid details");
                    return;
                }
            }

            Module newModule = Module.create(name, code, Convert.ToInt64(year), Convert.ToInt64(credits));
            if (del != null) 
            {
                AddEditModuleViewDelegate delObject;
                del.TryGetTarget(out delObject);
                if (delObject != null) delObject.newModuleCreated(newModule);
            }
            this.Parent.Controls.Remove(this);
            clearTextFields();
        }

        private void clearTextFields()
        {
            nameTF.Text = "";
            codeTF.Text = "";
            creditsTF.Text = "";
        }
        public void setSelectedYearButton(Int64 year)
        {
            switch (year)
            {
                case 1:
                    yearButtonSelected(yr1Button);
                    break;
                case 2:
                    yearButtonSelected(yr2Button);
                    break;
                case 3:
                    yearButtonSelected(yr3Button);
                    break;
                default:
                    yearButtonSelected(null);
                    break;
            }
        }
        private void yearButtonSelected(Button selectedButton) 
        {
            if (this.selectedYearButton != null) this.selectedYearButton.BackColor = Color.Transparent;
            this.selectedYearButton = selectedButton;
            if (this.selectedYearButton != null) this.selectedYearButton.BackColor = Color.LightBlue;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            yearButtonSelected(sender as Button);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yearButtonSelected(sender as Button);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yearButtonSelected(sender as Button);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            clearTextFields();
        }

    }

    public interface AddEditModuleViewDelegate
    {
        void newModuleCreated(Module module);
    }
}
