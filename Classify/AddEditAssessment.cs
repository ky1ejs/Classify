using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            int.TryParse(weightTF.Text, out weight);
            int result;
            int.TryParse(resultTF.Text, out result);
            Assessment newAssessment = Assessment.create(title, Convert.ToInt16(weight), type, Convert.ToInt16(result), module.id);
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
