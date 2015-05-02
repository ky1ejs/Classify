namespace Classify
{
    partial class AddEditModuleView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameTF = new System.Windows.Forms.TextBox();
            this.codeTF = new System.Windows.Forms.TextBox();
            this.yearTF = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTF
            // 
            this.nameTF.Location = new System.Drawing.Point(54, 39);
            this.nameTF.Name = "nameTF";
            this.nameTF.Size = new System.Drawing.Size(100, 20);
            this.nameTF.TabIndex = 0;
            // 
            // codeTF
            // 
            this.codeTF.Location = new System.Drawing.Point(54, 84);
            this.codeTF.Name = "codeTF";
            this.codeTF.Size = new System.Drawing.Size(100, 20);
            this.codeTF.TabIndex = 1;
            // 
            // yearTF
            // 
            this.yearTF.Location = new System.Drawing.Point(54, 125);
            this.yearTF.Name = "yearTF";
            this.yearTF.Size = new System.Drawing.Size(100, 20);
            this.yearTF.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddEditModuleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.yearTF);
            this.Controls.Add(this.codeTF);
            this.Controls.Add(this.nameTF);
            this.Name = "AddEditModuleView";
            this.Size = new System.Drawing.Size(214, 208);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTF;
        private System.Windows.Forms.TextBox codeTF;
        private System.Windows.Forms.TextBox yearTF;
        private System.Windows.Forms.Button button1;
    }
}
