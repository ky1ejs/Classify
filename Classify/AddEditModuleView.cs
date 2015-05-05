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

        private void button1_Click(object sender, EventArgs e)
        {
            String name = nameTF.Text;
            String code = codeTF.Text;
            int year;
            int.TryParse(selectedYearButton.Text, out year);
            int credits;
            int.TryParse(creditsTF.Text, out credits);
            Module newModule = Module.create(name, code, Convert.ToInt32(year), Convert.ToInt32(credits));
            if (del != null) 
            {
                AddEditModuleViewDelegate delObject;
                del.TryGetTarget(out delObject);
                if (delObject != null) delObject.newModuleCreated(newModule);
            }
            this.Parent.Controls.Remove(this);
        }
        private void yearButtonSelected(Button selectedButton) 
        {
            if (this.selectedYearButton != null) this.selectedYearButton.BackColor = Color.Transparent;
            this.selectedYearButton = selectedButton;
            this.selectedYearButton.BackColor = Color.LightBlue;
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
        }

    }

    public interface AddEditModuleViewDelegate
    {
        void newModuleCreated(Module module);
    }
}
