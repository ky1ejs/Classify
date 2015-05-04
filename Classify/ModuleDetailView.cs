﻿using System;
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
    public partial class ModuleDetailView : UserControl
    {
        private Module module;

        public ModuleDetailView(Module module)
        {
            this.module = module;
            InitializeComponent();

            nameLabel.Text = module.name;
            codeLabel.Text = module.code;
            yearLabel.Text = module.year.ToString();
            creditsLabel.Text = module.credits.ToString();

            assessmentTable.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            assessmentTable.RowHeadersVisible = false;
            assessmentTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            assessmentTable.MultiSelect = false;
            String stm = "SELECT title, weight, type, result FROM Assessments WHERE module_id = @module_id";
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(stm, DBSchema.connection());
            adapt.SelectCommand.Parameters.Add(new SQLiteParameter("@module_id", module.id));
            DataSet ds = new DataSet();
            adapt.Fill(ds, "Assessments");
            assessmentTable.DataSource = ds.Tables["Assessments"];
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
