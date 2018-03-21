namespace Silverio.Žodynas.Forms
{
    partial class TestResultsForm
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
            this.ElapsedTimeHeaderLabel = new System.Windows.Forms.Label();
            this.ElapsedTimeLabel = new System.Windows.Forms.Label();
            this.SelectedLanguageHeaderLabel = new System.Windows.Forms.Label();
            this.SelectedLanguageLabel = new System.Windows.Forms.Label();
            this.SelectedTestTypeHeaderLabel = new System.Windows.Forms.Label();
            this.SelectedTestTypeLabel = new System.Windows.Forms.Label();
            this.LearnedWordsStatsHeaderLabel = new System.Windows.Forms.Label();
            this.LearnedWordsStatsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.StartDifferentTestButton = new System.Windows.Forms.Button();
            this.EndProgramButton = new System.Windows.Forms.Button();
            this.UnknownWordsStatsHeaderLabel = new System.Windows.Forms.Label();
            this.UnknownWordsStatsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.WordsTypeHeaderLabel = new System.Windows.Forms.Label();
            this.WordsTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ElapsedTimeHeaderLabel
            // 
            this.ElapsedTimeHeaderLabel.AutoSize = true;
            this.ElapsedTimeHeaderLabel.Location = new System.Drawing.Point(272, 25);
            this.ElapsedTimeHeaderLabel.Name = "ElapsedTimeHeaderLabel";
            this.ElapsedTimeHeaderLabel.Size = new System.Drawing.Size(86, 16);
            this.ElapsedTimeHeaderLabel.TabIndex = 0;
            this.ElapsedTimeHeaderLabel.Text = "Testo trukmė:";
            // 
            // ElapsedTimeLabel
            // 
            this.ElapsedTimeLabel.AutoSize = true;
            this.ElapsedTimeLabel.Location = new System.Drawing.Point(355, 25);
            this.ElapsedTimeLabel.Name = "ElapsedTimeLabel";
            this.ElapsedTimeLabel.Size = new System.Drawing.Size(75, 16);
            this.ElapsedTimeLabel.TabIndex = 1;
            this.ElapsedTimeLabel.Text = "0h 12m 15s";
            // 
            // SelectedLanguageHeaderLabel
            // 
            this.SelectedLanguageHeaderLabel.AutoSize = true;
            this.SelectedLanguageHeaderLabel.Location = new System.Drawing.Point(26, 25);
            this.SelectedLanguageHeaderLabel.Name = "SelectedLanguageHeaderLabel";
            this.SelectedLanguageHeaderLabel.Size = new System.Drawing.Size(100, 16);
            this.SelectedLanguageHeaderLabel.TabIndex = 2;
            this.SelectedLanguageHeaderLabel.Text = "Pasrinkta kalba: ";
            // 
            // SelectedLanguageLabel
            // 
            this.SelectedLanguageLabel.AutoSize = true;
            this.SelectedLanguageLabel.Location = new System.Drawing.Point(120, 25);
            this.SelectedLanguageLabel.Name = "SelectedLanguageLabel";
            this.SelectedLanguageLabel.Size = new System.Drawing.Size(53, 16);
            this.SelectedLanguageLabel.TabIndex = 3;
            this.SelectedLanguageLabel.Text = "Lietuvių";
            // 
            // SelectedTestTypeHeaderLabel
            // 
            this.SelectedTestTypeHeaderLabel.AutoSize = true;
            this.SelectedTestTypeHeaderLabel.Location = new System.Drawing.Point(26, 55);
            this.SelectedTestTypeHeaderLabel.Name = "SelectedTestTypeHeaderLabel";
            this.SelectedTestTypeHeaderLabel.Size = new System.Drawing.Size(76, 16);
            this.SelectedTestTypeHeaderLabel.TabIndex = 4;
            this.SelectedTestTypeHeaderLabel.Text = "Testo tipas: ";
            // 
            // SelectedTestTypeLabel
            // 
            this.SelectedTestTypeLabel.AutoSize = true;
            this.SelectedTestTypeLabel.Location = new System.Drawing.Point(95, 55);
            this.SelectedTestTypeLabel.Name = "SelectedTestTypeLabel";
            this.SelectedTestTypeLabel.Size = new System.Drawing.Size(39, 16);
            this.SelectedTestTypeLabel.TabIndex = 5;
            this.SelectedTestTypeLabel.Text = "Raštu";
            // 
            // LearnedWordsStatsHeaderLabel
            // 
            this.LearnedWordsStatsHeaderLabel.AutoSize = true;
            this.LearnedWordsStatsHeaderLabel.Location = new System.Drawing.Point(532, 25);
            this.LearnedWordsStatsHeaderLabel.Name = "LearnedWordsStatsHeaderLabel";
            this.LearnedWordsStatsHeaderLabel.Size = new System.Drawing.Size(126, 16);
            this.LearnedWordsStatsHeaderLabel.TabIndex = 6;
            this.LearnedWordsStatsHeaderLabel.Text = "Nauji išmokti žodžiai:";
            this.LearnedWordsStatsHeaderLabel.Visible = false;
            // 
            // LearnedWordsStatsLinkLabel
            // 
            this.LearnedWordsStatsLinkLabel.AutoSize = true;
            this.LearnedWordsStatsLinkLabel.Location = new System.Drawing.Point(656, 25);
            this.LearnedWordsStatsLinkLabel.Name = "LearnedWordsStatsLinkLabel";
            this.LearnedWordsStatsLinkLabel.Size = new System.Drawing.Size(55, 16);
            this.LearnedWordsStatsLinkLabel.TabIndex = 8;
            this.LearnedWordsStatsLinkLabel.TabStop = true;
            this.LearnedWordsStatsLinkLabel.Text = "95 / 100";
            this.LearnedWordsStatsLinkLabel.Visible = false;
            this.LearnedWordsStatsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LearnedWordsStatsLabel_LinkClicked);
            // 
            // StartDifferentTestButton
            // 
            this.StartDifferentTestButton.BackColor = System.Drawing.Color.YellowGreen;
            this.StartDifferentTestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartDifferentTestButton.Location = new System.Drawing.Point(195, 152);
            this.StartDifferentTestButton.Name = "StartDifferentTestButton";
            this.StartDifferentTestButton.Padding = new System.Windows.Forms.Padding(2);
            this.StartDifferentTestButton.Size = new System.Drawing.Size(138, 32);
            this.StartDifferentTestButton.TabIndex = 9;
            this.StartDifferentTestButton.Text = "Pasirinkti kitą testą";
            this.StartDifferentTestButton.UseVisualStyleBackColor = false;
            this.StartDifferentTestButton.Click += new System.EventHandler(this.StartDifferentTestButton_Click);
            // 
            // EndProgramButton
            // 
            this.EndProgramButton.BackColor = System.Drawing.Color.Red;
            this.EndProgramButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EndProgramButton.Location = new System.Drawing.Point(414, 152);
            this.EndProgramButton.Name = "EndProgramButton";
            this.EndProgramButton.Padding = new System.Windows.Forms.Padding(2);
            this.EndProgramButton.Size = new System.Drawing.Size(138, 32);
            this.EndProgramButton.TabIndex = 10;
            this.EndProgramButton.Text = "Uždaryti programą";
            this.EndProgramButton.UseVisualStyleBackColor = false;
            this.EndProgramButton.Click += new System.EventHandler(this.EndProgramButton_Click);
            // 
            // UnknownWordsStatsHeaderLabel
            // 
            this.UnknownWordsStatsHeaderLabel.AutoSize = true;
            this.UnknownWordsStatsHeaderLabel.Location = new System.Drawing.Point(532, 55);
            this.UnknownWordsStatsHeaderLabel.Name = "UnknownWordsStatsHeaderLabel";
            this.UnknownWordsStatsHeaderLabel.Size = new System.Drawing.Size(136, 16);
            this.UnknownWordsStatsHeaderLabel.TabIndex = 11;
            this.UnknownWordsStatsHeaderLabel.Text = "Nauji nežinomi žodžiai:";
            this.UnknownWordsStatsHeaderLabel.Visible = false;
            // 
            // UnknownWordsStatsLinkLabel
            // 
            this.UnknownWordsStatsLinkLabel.AutoSize = true;
            this.UnknownWordsStatsLinkLabel.Location = new System.Drawing.Point(666, 55);
            this.UnknownWordsStatsLinkLabel.Name = "UnknownWordsStatsLinkLabel";
            this.UnknownWordsStatsLinkLabel.Size = new System.Drawing.Size(48, 16);
            this.UnknownWordsStatsLinkLabel.TabIndex = 12;
            this.UnknownWordsStatsLinkLabel.TabStop = true;
            this.UnknownWordsStatsLinkLabel.Text = "5 / 100";
            this.UnknownWordsStatsLinkLabel.Visible = false;
            this.UnknownWordsStatsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // WordsTypeHeaderLabel
            // 
            this.WordsTypeHeaderLabel.AutoSize = true;
            this.WordsTypeHeaderLabel.Location = new System.Drawing.Point(272, 55);
            this.WordsTypeHeaderLabel.Name = "WordsTypeHeaderLabel";
            this.WordsTypeHeaderLabel.Size = new System.Drawing.Size(83, 16);
            this.WordsTypeHeaderLabel.TabIndex = 13;
            this.WordsTypeHeaderLabel.Text = "Žodžių tipas: ";
            // 
            // WordsTypeLabel
            // 
            this.WordsTypeLabel.AutoSize = true;
            this.WordsTypeLabel.Location = new System.Drawing.Point(348, 55);
            this.WordsTypeLabel.Name = "WordsTypeLabel";
            this.WordsTypeLabel.Size = new System.Drawing.Size(28, 16);
            this.WordsTypeLabel.TabIndex = 14;
            this.WordsTypeLabel.Text = "Visi";
            // 
            // TestResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 291);
            this.ControlBox = false;
            this.Controls.Add(this.WordsTypeLabel);
            this.Controls.Add(this.WordsTypeHeaderLabel);
            this.Controls.Add(this.UnknownWordsStatsLinkLabel);
            this.Controls.Add(this.UnknownWordsStatsHeaderLabel);
            this.Controls.Add(this.EndProgramButton);
            this.Controls.Add(this.StartDifferentTestButton);
            this.Controls.Add(this.LearnedWordsStatsLinkLabel);
            this.Controls.Add(this.LearnedWordsStatsHeaderLabel);
            this.Controls.Add(this.SelectedTestTypeLabel);
            this.Controls.Add(this.SelectedTestTypeHeaderLabel);
            this.Controls.Add(this.SelectedLanguageLabel);
            this.Controls.Add(this.SelectedLanguageHeaderLabel);
            this.Controls.Add(this.ElapsedTimeLabel);
            this.Controls.Add(this.ElapsedTimeHeaderLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TestResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testo rezultatai:";
            this.Load += new System.EventHandler(this.TestResultsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ElapsedTimeHeaderLabel;
        private System.Windows.Forms.Label ElapsedTimeLabel;
        private System.Windows.Forms.Label SelectedLanguageHeaderLabel;
        private System.Windows.Forms.Label SelectedLanguageLabel;
        private System.Windows.Forms.Label SelectedTestTypeHeaderLabel;
        private System.Windows.Forms.Label SelectedTestTypeLabel;
        private System.Windows.Forms.Label LearnedWordsStatsHeaderLabel;
        private System.Windows.Forms.LinkLabel LearnedWordsStatsLinkLabel;
        private System.Windows.Forms.Button StartDifferentTestButton;
        private System.Windows.Forms.Button EndProgramButton;
        private System.Windows.Forms.Label UnknownWordsStatsHeaderLabel;
        private System.Windows.Forms.LinkLabel UnknownWordsStatsLinkLabel;
        private System.Windows.Forms.Label WordsTypeHeaderLabel;
        private System.Windows.Forms.Label WordsTypeLabel;
    }
}