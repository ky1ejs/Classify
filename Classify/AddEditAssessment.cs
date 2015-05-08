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
    public partial class AddEditAssessment : UserControl
    {
        private WeakReference<AddEditAssessmentDelegate> del;
        private Module module;
        public AddEditAssessment(AddEditAssessmentDelegate aDelegate, Module module)
        {
            InitializeComponent();
            this.del = new WeakReference<AddEditAssessmentDelegate>(aDelegate);
            this.module = module;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String title = titleTF.Text;
            String type = typeTF.Text;
            int weight;
            Boolean weightParsed = int.TryParse(weightTF.Text, out weight);
            int resultInt;
            Int64? result = null;
            Boolean resultParsed;
            if (resultTF.Text.Length > 0)
            {
                resultParsed = int.TryParse(resultTF.Text, out resultInt);
                if (resultParsed) result = Convert.ToInt64(resultInt);
            }
            else
            {
                resultParsed = true;
            }
            

            String mbMessage = null;
            if (title.Length == 0)
            {
                mbMessage = "- Please enter a title";
            }
            if (type.Length == 0)
            {
                if (mbMessage == null) mbMessage = "";
                mbMessage += "\n- Please enter an assessment type";
            }
            if (!resultParsed)
            {
                if (mbMessage == null) mbMessage = "";
                mbMessage = "\n- Please enter a valid result percentage";
            }
            if (!weightParsed)
            {
                if (mbMessage == null) mbMessage = "";
                mbMessage = "\n- PPlease enter a valid weight percentage";
            }
            if (mbMessage != null)
            {
                MessageBox.Show(mbMessage, "Missing or invalid details");
                return;
            }

            if (weight > 100)
            {
                MessageBox.Show("A module's weight can not be above 100", "Missing or invalid details");
            }
            else
            {
                String stm = "SELECT SUM(weight) AS total_weight FROM Assessments WHERE module_id = @id";
                SQLiteCommand cm = new SQLiteCommand(stm, DBSchema.connection());
                cm.Parameters.Add(new SQLiteParameter("@id", module.id));
                SQLiteDataReader dr = cm.ExecuteReader();
                dr.Read();
                Int64? totalCreditsForYear = dr["total_weight"] as Int64?;
                if (totalCreditsForYear != null && totalCreditsForYear.Value + weight > 100)
                {
                    MessageBox.Show(String.Format("You may only have 100% in assessment weight per module. There are already {0}% worth of weight in this module. You have entered {1}%.", totalCreditsForYear, weight), "Missing or invalid details");
                    return;
                }
            }
            

            Assessment newAssessment;
            if (result != null)
            {
                newAssessment = Assessment.create(title, Convert.ToInt64(weight), type, result.Value, module.id);
            }
            else
            {
                newAssessment = Assessment.create(title, Convert.ToInt64(weight), type, module.id);
            }
            if (del != null)
            {
                AddEditAssessmentDelegate delObject;
                del.TryGetTarget(out delObject);
                if (delObject != null) delObject.newAssessmentCreated(newAssessment);
            }
            this.Parent.Controls.Remove(this);
        }
    }

    public interface AddEditAssessmentDelegate
    {
        void newAssessmentCreated(Assessment assessment);
    }
}
