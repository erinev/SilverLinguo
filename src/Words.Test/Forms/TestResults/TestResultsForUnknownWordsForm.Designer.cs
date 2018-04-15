namespace Words.Test.Forms.TestResults
{
    partial class TestResultsForUnknownWordsForm
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
            this.LearnedWordsStatsHeaderLabel = new System.Windows.Forms.Label();
            this.LearnedWordsStatsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // LearnedWordsStatsHeaderLabel
            // 
            this.LearnedWordsStatsHeaderLabel.AutoSize = true;
            this.LearnedWordsStatsHeaderLabel.Location = new System.Drawing.Point(519, 40);
            this.LearnedWordsStatsHeaderLabel.Name = "LearnedWordsStatsHeaderLabel";
            this.LearnedWordsStatsHeaderLabel.Size = new System.Drawing.Size(95, 16);
            this.LearnedWordsStatsHeaderLabel.TabIndex = 6;
            this.LearnedWordsStatsHeaderLabel.Text = "Išmokti žodžiai:";
            // 
            // LearnedWordsStatsLinkLabel
            // 
            this.LearnedWordsStatsLinkLabel.AutoSize = true;
            this.LearnedWordsStatsLinkLabel.Location = new System.Drawing.Point(611, 40);
            this.LearnedWordsStatsLinkLabel.Name = "LearnedWordsStatsLinkLabel";
            this.LearnedWordsStatsLinkLabel.Size = new System.Drawing.Size(55, 16);
            this.LearnedWordsStatsLinkLabel.TabIndex = 8;
            this.LearnedWordsStatsLinkLabel.TabStop = true;
            this.LearnedWordsStatsLinkLabel.Text = "95 / 100";
            this.LearnedWordsStatsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LearnedWordsStatsLabel_LinkClicked);
            // 
            // UnknownWordsTestResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 243);
            this.ControlBox = false;
            this.Controls.Add(this.LearnedWordsStatsLinkLabel);
            this.Controls.Add(this.LearnedWordsStatsHeaderLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UnknownWordsTestResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nežinomų žodžių testo rezultatai:";
            this.Load += new System.EventHandler(this.TestResultsForUnknownWordsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LearnedWordsStatsHeaderLabel;
        private System.Windows.Forms.LinkLabel LearnedWordsStatsLinkLabel;
    }
}