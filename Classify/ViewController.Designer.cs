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
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.year1TabPage = new System.Windows.Forms.TabPage();
            this.year2TabPage = new System.Windows.Forms.TabPage();
            this.year3TabPage = new System.Windows.Forms.TabPage();
            this.addModuleButton = new System.Windows.Forms.Button();
            this.yr1ModCountLabel = new System.Windows.Forms.Label();
            this.yr1AvgScore = new System.Windows.Forms.Label();
            this.yr1BestMod = new System.Windows.Forms.Label();
            this.yr1BestModScore = new System.Windows.Forms.Label();
            this.yr2ModCountLabel = new System.Windows.Forms.Label();
            this.yr2AvgScore = new System.Windows.Forms.Label();
            this.yr2BestMod = new System.Windows.Forms.Label();
            this.yr2BestModScore = new System.Windows.Forms.Label();
            this.yr3ModCountLabel = new System.Windows.Forms.Label();
            this.yr3AvgScore = new System.Windows.Forms.Label();
            this.yr3BestMod = new System.Windows.Forms.Label();
            this.yr3BestModScore = new System.Windows.Forms.Label();
            this.degClassLabel = new System.Windows.Forms.Label();
            this.firstBestCredScoreLabel = new System.Windows.Forms.Label();
            this.secondBestCredScoreLabel = new System.Windows.Forms.Label();
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
            this.tabControl.Size = new System.Drawing.Size(541, 358);
            this.tabControl.TabIndex = 0;
            // 
            // homeTabPage
            // 
            this.homeTabPage.Controls.Add(this.secondBestCredScoreLabel);
            this.homeTabPage.Controls.Add(this.firstBestCredScoreLabel);
            this.homeTabPage.Controls.Add(this.degClassLabel);
            this.homeTabPage.Controls.Add(this.yr3BestModScore);
            this.homeTabPage.Controls.Add(this.yr3BestMod);
            this.homeTabPage.Controls.Add(this.yr3AvgScore);
            this.homeTabPage.Controls.Add(this.yr3ModCountLabel);
            this.homeTabPage.Controls.Add(this.yr2BestModScore);
            this.homeTabPage.Controls.Add(this.yr2BestMod);
            this.homeTabPage.Controls.Add(this.yr2AvgScore);
            this.homeTabPage.Controls.Add(this.yr2ModCountLabel);
            this.homeTabPage.Controls.Add(this.yr1BestModScore);
            this.homeTabPage.Controls.Add(this.yr1BestMod);
            this.homeTabPage.Controls.Add(this.yr1AvgScore);
            this.homeTabPage.Controls.Add(this.yr1ModCountLabel);
            this.homeTabPage.Controls.Add(this.label16);
            this.homeTabPage.Controls.Add(this.label17);
            this.homeTabPage.Controls.Add(this.label18);
            this.homeTabPage.Controls.Add(this.label19);
            this.homeTabPage.Controls.Add(this.label20);
            this.homeTabPage.Controls.Add(this.label9);
            this.homeTabPage.Controls.Add(this.label10);
            this.homeTabPage.Controls.Add(this.label12);
            this.homeTabPage.Controls.Add(this.label14);
            this.homeTabPage.Controls.Add(this.label15);
            this.homeTabPage.Controls.Add(this.label4);
            this.homeTabPage.Controls.Add(this.label5);
            this.homeTabPage.Controls.Add(this.label6);
            this.homeTabPage.Controls.Add(this.label8);
            this.homeTabPage.Controls.Add(this.label3);
            this.homeTabPage.Controls.Add(this.label13);
            this.homeTabPage.Controls.Add(this.label11);
            this.homeTabPage.Controls.Add(this.label7);
            this.homeTabPage.Controls.Add(this.label2);
            this.homeTabPage.Controls.Add(this.label1);
            this.homeTabPage.Location = new System.Drawing.Point(4, 22);
            this.homeTabPage.Name = "homeTabPage";
            this.homeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.homeTabPage.Size = new System.Drawing.Size(533, 332);
            this.homeTabPage.TabIndex = 0;
            this.homeTabPage.Text = "Home";
            this.homeTabPage.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(53, 268);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Best Module";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 221);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 16);
            this.label17.TabIndex = 26;
            this.label17.Text = "Year 3";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 281);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Best Module Score";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(41, 255);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "Average Score";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(52, 242);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "No. Modules";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Best Module";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Year 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 189);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Best Module Score";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Average Score";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(52, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "No. Modules";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "2nd Best 115 Credits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "1st Best 115 credits";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Estimated classification";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(238, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Degree";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(53, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Best Module";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Year 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Best Module Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Average Score";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Modules";
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
            this.addModuleButton.Location = new System.Drawing.Point(464, 2);
            this.addModuleButton.Name = "addModuleButton";
            this.addModuleButton.Size = new System.Drawing.Size(75, 23);
            this.addModuleButton.TabIndex = 1;
            this.addModuleButton.Text = "Add Module";
            this.addModuleButton.UseVisualStyleBackColor = true;
            this.addModuleButton.Click += new System.EventHandler(this.addModuleButton_Click);
            // 
            // yr1ModCountLabel
            // 
            this.yr1ModCountLabel.AutoSize = true;
            this.yr1ModCountLabel.Location = new System.Drawing.Point(125, 61);
            this.yr1ModCountLabel.Name = "yr1ModCountLabel";
            this.yr1ModCountLabel.Size = new System.Drawing.Size(41, 13);
            this.yr1ModCountLabel.TabIndex = 28;
            this.yr1ModCountLabel.Text = "label21";
            // 
            // yr1AvgScore
            // 
            this.yr1AvgScore.AutoSize = true;
            this.yr1AvgScore.Location = new System.Drawing.Point(125, 74);
            this.yr1AvgScore.Name = "yr1AvgScore";
            this.yr1AvgScore.Size = new System.Drawing.Size(41, 13);
            this.yr1AvgScore.TabIndex = 29;
            this.yr1AvgScore.Text = "label22";
            // 
            // yr1BestMod
            // 
            this.yr1BestMod.AutoSize = true;
            this.yr1BestMod.Location = new System.Drawing.Point(125, 87);
            this.yr1BestMod.Name = "yr1BestMod";
            this.yr1BestMod.Size = new System.Drawing.Size(41, 13);
            this.yr1BestMod.TabIndex = 30;
            this.yr1BestMod.Text = "label23";
            // 
            // yr1BestModScore
            // 
            this.yr1BestModScore.AutoSize = true;
            this.yr1BestModScore.Location = new System.Drawing.Point(125, 100);
            this.yr1BestModScore.Name = "yr1BestModScore";
            this.yr1BestModScore.Size = new System.Drawing.Size(41, 13);
            this.yr1BestModScore.TabIndex = 31;
            this.yr1BestModScore.Text = "label24";
            // 
            // yr2ModCountLabel
            // 
            this.yr2ModCountLabel.AutoSize = true;
            this.yr2ModCountLabel.Location = new System.Drawing.Point(125, 150);
            this.yr2ModCountLabel.Name = "yr2ModCountLabel";
            this.yr2ModCountLabel.Size = new System.Drawing.Size(41, 13);
            this.yr2ModCountLabel.TabIndex = 32;
            this.yr2ModCountLabel.Text = "label25";
            // 
            // yr2AvgScore
            // 
            this.yr2AvgScore.AutoSize = true;
            this.yr2AvgScore.Location = new System.Drawing.Point(125, 163);
            this.yr2AvgScore.Name = "yr2AvgScore";
            this.yr2AvgScore.Size = new System.Drawing.Size(41, 13);
            this.yr2AvgScore.TabIndex = 33;
            this.yr2AvgScore.Text = "label26";
            // 
            // yr2BestMod
            // 
            this.yr2BestMod.AutoSize = true;
            this.yr2BestMod.Location = new System.Drawing.Point(125, 176);
            this.yr2BestMod.Name = "yr2BestMod";
            this.yr2BestMod.Size = new System.Drawing.Size(41, 13);
            this.yr2BestMod.TabIndex = 34;
            this.yr2BestMod.Text = "label27";
            // 
            // yr2BestModScore
            // 
            this.yr2BestModScore.AutoSize = true;
            this.yr2BestModScore.Location = new System.Drawing.Point(125, 189);
            this.yr2BestModScore.Name = "yr2BestModScore";
            this.yr2BestModScore.Size = new System.Drawing.Size(41, 13);
            this.yr2BestModScore.TabIndex = 35;
            this.yr2BestModScore.Text = "label28";
            // 
            // yr3ModCountLabel
            // 
            this.yr3ModCountLabel.AutoSize = true;
            this.yr3ModCountLabel.Location = new System.Drawing.Point(125, 242);
            this.yr3ModCountLabel.Name = "yr3ModCountLabel";
            this.yr3ModCountLabel.Size = new System.Drawing.Size(41, 13);
            this.yr3ModCountLabel.TabIndex = 36;
            this.yr3ModCountLabel.Text = "label29";
            // 
            // yr3AvgScore
            // 
            this.yr3AvgScore.AutoSize = true;
            this.yr3AvgScore.Location = new System.Drawing.Point(125, 255);
            this.yr3AvgScore.Name = "yr3AvgScore";
            this.yr3AvgScore.Size = new System.Drawing.Size(41, 13);
            this.yr3AvgScore.TabIndex = 37;
            this.yr3AvgScore.Text = "label30";
            // 
            // yr3BestMod
            // 
            this.yr3BestMod.AutoSize = true;
            this.yr3BestMod.Location = new System.Drawing.Point(125, 268);
            this.yr3BestMod.Name = "yr3BestMod";
            this.yr3BestMod.Size = new System.Drawing.Size(41, 13);
            this.yr3BestMod.TabIndex = 38;
            this.yr3BestMod.Text = "label31";
            // 
            // yr3BestModScore
            // 
            this.yr3BestModScore.AutoSize = true;
            this.yr3BestModScore.Location = new System.Drawing.Point(125, 281);
            this.yr3BestModScore.Name = "yr3BestModScore";
            this.yr3BestModScore.Size = new System.Drawing.Size(41, 13);
            this.yr3BestModScore.TabIndex = 39;
            this.yr3BestModScore.Text = "label32";
            // 
            // degClassLabel
            // 
            this.degClassLabel.AutoSize = true;
            this.degClassLabel.Location = new System.Drawing.Point(391, 61);
            this.degClassLabel.Name = "degClassLabel";
            this.degClassLabel.Size = new System.Drawing.Size(41, 13);
            this.degClassLabel.TabIndex = 40;
            this.degClassLabel.Text = "label33";
            // 
            // firstBestCredScoreLabel
            // 
            this.firstBestCredScoreLabel.AutoSize = true;
            this.firstBestCredScoreLabel.Location = new System.Drawing.Point(391, 74);
            this.firstBestCredScoreLabel.Name = "firstBestCredScoreLabel";
            this.firstBestCredScoreLabel.Size = new System.Drawing.Size(41, 13);
            this.firstBestCredScoreLabel.TabIndex = 41;
            this.firstBestCredScoreLabel.Text = "label34";
            // 
            // secondBestCredScoreLabel
            // 
            this.secondBestCredScoreLabel.AutoSize = true;
            this.secondBestCredScoreLabel.Location = new System.Drawing.Point(391, 87);
            this.secondBestCredScoreLabel.Name = "secondBestCredScoreLabel";
            this.secondBestCredScoreLabel.Size = new System.Drawing.Size(41, 13);
            this.secondBestCredScoreLabel.TabIndex = 42;
            this.secondBestCredScoreLabel.Text = "label35";
            // 
            // ViewController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 382);
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label secondBestCredScoreLabel;
        private System.Windows.Forms.Label firstBestCredScoreLabel;
        private System.Windows.Forms.Label degClassLabel;
        private System.Windows.Forms.Label yr3BestModScore;
        private System.Windows.Forms.Label yr3BestMod;
        private System.Windows.Forms.Label yr3AvgScore;
        private System.Windows.Forms.Label yr3ModCountLabel;
        private System.Windows.Forms.Label yr2BestModScore;
        private System.Windows.Forms.Label yr2BestMod;
        private System.Windows.Forms.Label yr2AvgScore;
        private System.Windows.Forms.Label yr2ModCountLabel;
        private System.Windows.Forms.Label yr1BestModScore;
        private System.Windows.Forms.Label yr1BestMod;
        private System.Windows.Forms.Label yr1AvgScore;
        private System.Windows.Forms.Label yr1ModCountLabel;
    }
}

