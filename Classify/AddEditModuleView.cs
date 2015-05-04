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
        public AddEditModuleView(AddEditModuleViewDelegate aDelegate)
        {
            InitializeComponent();
            this.del = new WeakReference<AddEditModuleViewDelegate>(aDelegate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = nameTF.Text;
            String code = codeTF.Text;
            int year;
            int.TryParse(yearTF.Text, out year);
            int credits;
            int.TryParse(creditsTF.Text, out credits);
            Module newModule = Module.create(name, code, Convert.ToInt16(year), Convert.ToInt16(credits));
            if (del != null) 
            {
                AddEditModuleViewDelegate delObject;
                del.TryGetTarget(out delObject);
                if (delObject != null) delObject.newModuleCreated(newModule);
            }
        }
    }

    public interface AddEditModuleViewDelegate
    {
        void newModuleCreated(Module module);
    }
}
