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
            this.saveButton = new System.Windows.Forms.Button();
            this.yr1Button = new System.Windows.Forms.Button();
            this.yr2Button = new System.Windows.Forms.Button();
            this.yr3Button = new System.Windows.Forms.Button();
            this.creditsTF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTF
            // 
            this.nameTF.Location = new System.Drawing.Point(99, 16);
            this.nameTF.Name = "nameTF";
            this.nameTF.Size = new System.Drawing.Size(100, 20);
            this.nameTF.TabIndex = 0;
            // 
            // codeTF
            // 
            this.codeTF.Location = new System.Drawing.Point(99, 68);
            this.codeTF.Name = "codeTF";
            this.codeTF.Size = new System.Drawing.Size(100, 20);
            this.codeTF.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(150, 239);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // yr1Button
            // 
            this.yr1Button.Location = new System.Drawing.Point(61, 122);
            this.yr1Button.Name = "yr1Button";
            this.yr1Button.Size = new System.Drawing.Size(55, 23);
            this.yr1Button.TabIndex = 0;
            this.yr1Button.Text = "1";
            this.yr1Button.UseVisualStyleBackColor = true;
            this.yr1Button.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // yr2Button
            // 
            this.yr2Button.Location = new System.Drawing.Point(122, 122);
            this.yr2Button.Name = "yr2Button";
            this.yr2Button.Size = new System.Drawing.Size(55, 23);
            this.yr2Button.TabIndex = 0;
            this.yr2Button.Text = "2";
            this.yr2Button.UseVisualStyleBackColor = true;
            this.yr2Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // yr3Button
            // 
            this.yr3Button.Location = new System.Drawing.Point(183, 122);
            this.yr3Button.Name = "yr3Button";
            this.yr3Button.Size = new System.Drawing.Size(55, 23);
            this.yr3Button.TabIndex = 0;
            this.yr3Button.Text = "3";
            this.yr3Button.UseVisualStyleBackColor = true;
            this.yr3Button.Click += new System.EventHandler(this.button3_Click);
            // 
            // creditsTF
            // 
            this.creditsTF.Location = new System.Drawing.Point(99, 176);
            this.creditsTF.Name = "creditsTF";
            this.creditsTF.Size = new System.Drawing.Size(100, 20);
            this.creditsTF.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Credits";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(69, 239);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddEditModuleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.creditsTF);
            this.Controls.Add(this.yr3Button);
            this.Controls.Add(this.yr2Button);
            this.Controls.Add(this.yr1Button);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.codeTF);
            this.Controls.Add(this.nameTF);
            this.Name = "AddEditModuleView";
            this.Size = new System.Drawing.Size(292, 293);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTF;
        private System.Windows.Forms.TextBox codeTF;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button yr1Button;
        private System.Windows.Forms.Button yr2Button;
        private System.Windows.Forms.Button yr3Button;
        private System.Windows.Forms.TextBox creditsTF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelButton;
    }
}
