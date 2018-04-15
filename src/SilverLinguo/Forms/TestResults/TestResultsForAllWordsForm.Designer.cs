namespace SilverLinguo.Forms.TestResults
{
    partial class TestResultsForAllWordsForm
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
            this.KnownWordsCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.KnownWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.LearnedWordsCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.LearnedWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.UnknownWordsCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.UnknownWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.NewUnknownWordsCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.NewUnknownWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.TestProgressHeaderLabel = new System.Windows.Forms.Label();
            this.TestProgressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KnownWordsCountLinkLabel
            // 
            this.KnownWordsCountLinkLabel.AutoSize = true;
            this.KnownWordsCountLinkLabel.Location = new System.Drawing.Point(608, 118);
            this.KnownWordsCountLinkLabel.Name = "KnownWordsCountLinkLabel";
            this.KnownWordsCountLinkLabel.Size = new System.Drawing.Size(55, 16);
            this.KnownWordsCountLinkLabel.TabIndex = 81;
            this.KnownWordsCountLinkLabel.TabStop = true;
            this.KnownWordsCountLinkLabel.Text = "63 / 100";
            this.KnownWordsCountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.KnownWordsCountLinkLabel_LinkClicked);
            // 
            // KnownWordsCountHeaderLabel
            // 
            this.KnownWordsCountHeaderLabel.AutoSize = true;
            this.KnownWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.KnownWordsCountHeaderLabel.Location = new System.Drawing.Point(519, 118);
            this.KnownWordsCountHeaderLabel.Name = "KnownWordsCountHeaderLabel";
            this.KnownWordsCountHeaderLabel.Size = new System.Drawing.Size(96, 16);
            this.KnownWordsCountHeaderLabel.TabIndex = 80;
            this.KnownWordsCountHeaderLabel.Text = "Žinomi žodžiai: ";
            // 
            // LearnedWordsCountLinkLabel
            // 
            this.LearnedWordsCountLinkLabel.AutoSize = true;
            this.LearnedWordsCountLinkLabel.Location = new System.Drawing.Point(642, 92);
            this.LearnedWordsCountLinkLabel.Name = "LearnedWordsCountLinkLabel";
            this.LearnedWordsCountLinkLabel.Size = new System.Drawing.Size(55, 16);
            this.LearnedWordsCountLinkLabel.TabIndex = 79;
            this.LearnedWordsCountLinkLabel.TabStop = true;
            this.LearnedWordsCountLinkLabel.Text = "20 / 100";
            this.LearnedWordsCountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LearnedWordsCountLinkLabel_LinkClicked);
            // 
            // LearnedWordsCountHeaderLabel
            // 
            this.LearnedWordsCountHeaderLabel.AutoSize = true;
            this.LearnedWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LearnedWordsCountHeaderLabel.Location = new System.Drawing.Point(519, 92);
            this.LearnedWordsCountHeaderLabel.Name = "LearnedWordsCountHeaderLabel";
            this.LearnedWordsCountHeaderLabel.Size = new System.Drawing.Size(130, 16);
            this.LearnedWordsCountHeaderLabel.TabIndex = 78;
            this.LearnedWordsCountHeaderLabel.Text = "Nauji išmokti žodžiai: ";
            // 
            // UnknownWordsCountLinkLabel
            // 
            this.UnknownWordsCountLinkLabel.AutoSize = true;
            this.UnknownWordsCountLinkLabel.Location = new System.Drawing.Point(663, 66);
            this.UnknownWordsCountLinkLabel.Name = "UnknownWordsCountLinkLabel";
            this.UnknownWordsCountLinkLabel.Size = new System.Drawing.Size(48, 16);
            this.UnknownWordsCountLinkLabel.TabIndex = 77;
            this.UnknownWordsCountLinkLabel.TabStop = true;
            this.UnknownWordsCountLinkLabel.Text = "8 / 100";
            this.UnknownWordsCountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UnknownWordsCountLinkLabel_LinkClicked);
            // 
            // UnknownWordsCountHeaderLabel
            // 
            this.UnknownWordsCountHeaderLabel.AutoSize = true;
            this.UnknownWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.UnknownWordsCountHeaderLabel.Location = new System.Drawing.Point(519, 66);
            this.UnknownWordsCountHeaderLabel.Name = "UnknownWordsCountHeaderLabel";
            this.UnknownWordsCountHeaderLabel.Size = new System.Drawing.Size(150, 16);
            this.UnknownWordsCountHeaderLabel.TabIndex = 76;
            this.UnknownWordsCountHeaderLabel.Text = "Vis dar nežinomi žodžiai: ";
            // 
            // NewUnknownWordsCountLinkLabel
            // 
            this.NewUnknownWordsCountLinkLabel.AutoSize = true;
            this.NewUnknownWordsCountLinkLabel.Location = new System.Drawing.Point(652, 40);
            this.NewUnknownWordsCountLinkLabel.Name = "NewUnknownWordsCountLinkLabel";
            this.NewUnknownWordsCountLinkLabel.Size = new System.Drawing.Size(48, 16);
            this.NewUnknownWordsCountLinkLabel.TabIndex = 75;
            this.NewUnknownWordsCountLinkLabel.TabStop = true;
            this.NewUnknownWordsCountLinkLabel.Text = "9 / 100";
            this.NewUnknownWordsCountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NewUnknownWordsCountLinkLabel_LinkClicked);
            // 
            // NewUnknownWordsCountHeaderLabel
            // 
            this.NewUnknownWordsCountHeaderLabel.AutoSize = true;
            this.NewUnknownWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.NewUnknownWordsCountHeaderLabel.Location = new System.Drawing.Point(519, 40);
            this.NewUnknownWordsCountHeaderLabel.Name = "NewUnknownWordsCountHeaderLabel";
            this.NewUnknownWordsCountHeaderLabel.Size = new System.Drawing.Size(140, 16);
            this.NewUnknownWordsCountHeaderLabel.TabIndex = 74;
            this.NewUnknownWordsCountHeaderLabel.Text = "Nauji nežinomi žodžiai: ";
            // 
            // TestProgressHeaderLabel
            // 
            this.TestProgressHeaderLabel.AutoSize = true;
            this.TestProgressHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TestProgressHeaderLabel.Location = new System.Drawing.Point(519, 144);
            this.TestProgressHeaderLabel.Name = "TestProgressHeaderLabel";
            this.TestProgressHeaderLabel.Size = new System.Drawing.Size(101, 16);
            this.TestProgressHeaderLabel.TabIndex = 82;
            this.TestProgressHeaderLabel.Text = "Testo progresas:";
            // 
            // TestProgressLabel
            // 
            this.TestProgressLabel.AutoSize = true;
            this.TestProgressLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TestProgressLabel.Location = new System.Drawing.Point(617, 144);
            this.TestProgressLabel.Name = "TestProgressLabel";
            this.TestProgressLabel.Size = new System.Drawing.Size(62, 16);
            this.TestProgressLabel.TabIndex = 84;
            this.TestProgressLabel.Text = "100 / 100";
            // 
            // TestResultsForAllWordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 243);
            this.ControlBox = false;
            this.Controls.Add(this.TestProgressLabel);
            this.Controls.Add(this.TestProgressHeaderLabel);
            this.Controls.Add(this.KnownWordsCountLinkLabel);
            this.Controls.Add(this.KnownWordsCountHeaderLabel);
            this.Controls.Add(this.LearnedWordsCountLinkLabel);
            this.Controls.Add(this.LearnedWordsCountHeaderLabel);
            this.Controls.Add(this.UnknownWordsCountLinkLabel);
            this.Controls.Add(this.UnknownWordsCountHeaderLabel);
            this.Controls.Add(this.NewUnknownWordsCountLinkLabel);
            this.Controls.Add(this.NewUnknownWordsCountHeaderLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TestResultsForAllWordsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visų žodžių testo rezultatai:";
            this.Load += new System.EventHandler(this.TestResultsForAllWordsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel KnownWordsCountLinkLabel;
        private System.Windows.Forms.Label KnownWordsCountHeaderLabel;
        private System.Windows.Forms.LinkLabel LearnedWordsCountLinkLabel;
        private System.Windows.Forms.Label LearnedWordsCountHeaderLabel;
        private System.Windows.Forms.LinkLabel UnknownWordsCountLinkLabel;
        private System.Windows.Forms.Label UnknownWordsCountHeaderLabel;
        private System.Windows.Forms.LinkLabel NewUnknownWordsCountLinkLabel;
        private System.Windows.Forms.Label NewUnknownWordsCountHeaderLabel;
        private System.Windows.Forms.Label TestProgressHeaderLabel;
        private System.Windows.Forms.Label TestProgressLabel;
    }
}