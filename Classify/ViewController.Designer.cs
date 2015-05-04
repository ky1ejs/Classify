namespace Classify
{
    partial class ViewController
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.homeTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.year1TabPage = new System.Windows.Forms.TabPage();
            this.year2TabPage = new System.Windows.Forms.TabPage();
            this.year3TabPage = new System.Windows.Forms.TabPage();
            this.addModuleButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.homeTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.homeTabPage);
            this.tabControl.Controls.Add(this.year1TabPage);
            this.tabControl.Controls.Add(this.year2TabPage);
            this.tabControl.Controls.Add(this.year3TabPage);
            this.tabControl.Location = new System.Drawing.Point(3, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(452, 334);
            this.tabControl.TabIndex = 0;
            // 
            // homeTabPage
            // 
            this.homeTabPage.Controls.Add(this.label1);
            this.homeTabPage.Location = new System.Drawing.Point(4, 22);
            this.homeTabPage.Name = "homeTabPage";
            this.homeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.homeTabPage.Size = new System.Drawing.Size(444, 308);
            this.homeTabPage.TabIndex = 0;
            this.homeTabPage.Text = "Home";
            this.homeTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // year1TabPage
            // 
            this.year1TabPage.Location = new System.Drawing.Point(4, 22);
            this.year1TabPage.Name = "year1TabPage";
            this.year1TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.year1TabPage.Size = new System.Drawing.Size(444, 308);
            this.year1TabPage.TabIndex = 1;
            this.year1TabPage.Text = "Year 1";
            this.year1TabPage.UseVisualStyleBackColor = true;
            // 
            // year2TabPage
            // 
            this.year2TabPage.Location = new System.Drawing.Point(4, 22);
            this.year2TabPage.Name = "year2TabPage";
            this.year2TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.year2TabPage.Size = new System.Drawing.Size(444, 308);
            this.year2TabPage.TabIndex = 2;
            this.year2TabPage.Text = "Year 2";
            this.year2TabPage.UseVisualStyleBackColor = true;
            // 
            // year3TabPage
            // 
            this.year3TabPage.Location = new System.Drawing.Point(4, 22);
            this.year3TabPage.Name = "year3TabPage";
            this.year3TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.year3TabPage.Size = new System.Drawing.Size(444, 308);
            this.year3TabPage.TabIndex = 3;
            this.year3TabPage.Text = "Year 3";
            this.year3TabPage.UseVisualStyleBackColor = true;
            // 
            // addModuleButton
            // 
            this.addModuleButton.Location = new System.Drawing.Point(376, 0);
            this.addModuleButton.Name = "addModuleButton";
            this.addModuleButton.Size = new System.Drawing.Size(75, 23);
            this.addModuleButton.TabIndex = 1;
            this.addModuleButton.Text = "Add Module";
            this.addModuleButton.UseVisualStyleBackColor = true;
            this.addModuleButton.Click += new System.EventHandler(this.addModuleButton_Click);
            // 
            // ViewController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 362);
            this.Controls.Add(this.addModuleButton);
            this.Controls.Add(this.tabControl);
            this.Name = "ViewController";
            this.Text = "Classify";
            this.tabControl.ResumeLayout(false);
            this.homeTabPage.ResumeLayout(false);
            this.homeTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage homeTabPage;
        private System.Windows.Forms.TabPage year1TabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage year2TabPage;
        private System.Windows.Forms.TabPage year3TabPage;
        private System.Windows.Forms.Button addModuleButton;
    }
}

