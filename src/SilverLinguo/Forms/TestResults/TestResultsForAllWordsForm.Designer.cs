using System.Windows.Forms;

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
            this.TestUnknownWordsButton = new System.Windows.Forms.Button();
            this.TestNewUnknownWordsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KnownWordsCountLinkLabel
            // 
            this.KnownWordsCountLinkLabel.AutoSize = true;
            this.KnownWordsCountLinkLabel.Location = new System.Drawing.Point(608, 132);
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
            this.KnownWordsCountHeaderLabel.Location = new System.Drawing.Point(519, 132);
            this.KnownWordsCountHeaderLabel.Name = "KnownWordsCountHeaderLabel";
            this.KnownWordsCountHeaderLabel.Size = new System.Drawing.Size(96, 16);
            this.KnownWordsCountHeaderLabel.TabIndex = 80;
            this.KnownWordsCountHeaderLabel.Text = "Žinomi žodžiai: ";
            // 
            // LearnedWordsCountLinkLabel
            // 
            this.LearnedWordsCountLinkLabel.AutoSize = true;
            this.LearnedWordsCountLinkLabel.Location = new System.Drawing.Point(642, 106);
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
            this.LearnedWordsCountHeaderLabel.Location = new System.Drawing.Point(519, 106);
            this.LearnedWordsCountHeaderLabel.Name = "LearnedWordsCountHeaderLabel";
            this.LearnedWordsCountHeaderLabel.Size = new System.Drawing.Size(130, 16);
            this.LearnedWordsCountHeaderLabel.TabIndex = 78;
            this.LearnedWordsCountHeaderLabel.Text = "Nauji išmokti žodžiai: ";
            // 
            // UnknownWordsCountLinkLabel
            // 
            this.UnknownWordsCountLinkLabel.AutoSize = true;
            this.UnknownWordsCountLinkLabel.Location = new System.Drawing.Point(663, 56);
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
            this.UnknownWordsCountHeaderLabel.Location = new System.Drawing.Point(519, 56);
            this.UnknownWordsCountHeaderLabel.Name = "UnknownWordsCountHeaderLabel";
            this.UnknownWordsCountHeaderLabel.Size = new System.Drawing.Size(150, 16);
            this.UnknownWordsCountHeaderLabel.TabIndex = 76;
            this.UnknownWordsCountHeaderLabel.Text = "Vis dar nežinomi žodžiai: ";
            // 
            // NewUnknownWordsCountLinkLabel
            // 
            this.NewUnknownWordsCountLinkLabel.AutoSize = true;
            this.NewUnknownWordsCountLinkLabel.Location = new System.Drawing.Point(652, 7);
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
            this.NewUnknownWordsCountHeaderLabel.Location = new System.Drawing.Point(519, 7);
            this.NewUnknownWordsCountHeaderLabel.Name = "NewUnknownWordsCountHeaderLabel";
            this.NewUnknownWordsCountHeaderLabel.Size = new System.Drawing.Size(140, 16);
            this.NewUnknownWordsCountHeaderLabel.TabIndex = 74;
            this.NewUnknownWordsCountHeaderLabel.Text = "Nauji nežinomi žodžiai: ";
            // 
            // TestProgressHeaderLabel
            // 
            this.TestProgressHeaderLabel.AutoSize = true;
            this.TestProgressHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TestProgressHeaderLabel.Location = new System.Drawing.Point(519, 158);
            this.TestProgressHeaderLabel.Name = "TestProgressHeaderLabel";
            this.TestProgressHeaderLabel.Size = new System.Drawing.Size(101, 16);
            this.TestProgressHeaderLabel.TabIndex = 82;
            this.TestProgressHeaderLabel.Text = "Testo progresas:";
            // 
            // TestProgressLabel
            // 
            this.TestProgressLabel.AutoSize = true;
            this.TestProgressLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TestProgressLabel.Location = new System.Drawing.Point(617, 158);
            this.TestProgressLabel.Name = "TestProgressLabel";
            this.TestProgressLabel.Size = new System.Drawing.Size(62, 16);
            this.TestProgressLabel.TabIndex = 84;
            this.TestProgressLabel.Text = "100 / 100";
            // 
            // TestUnknownWordsButton
            // 
            this.TestUnknownWordsButton.BackColor = System.Drawing.Color.Yellow;
            this.TestUnknownWordsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TestUnknownWordsButton.Enabled = false;
            this.TestUnknownWordsButton.Location = new System.Drawing.Point(522, 75);
            this.TestUnknownWordsButton.Name = "TestUnknownWordsButton";
            this.TestUnknownWordsButton.Size = new System.Drawing.Size(40, 25);
            this.TestUnknownWordsButton.TabIndex = 85;
            this.TestUnknownWordsButton.Text = "Test";
            this.TestUnknownWordsButton.UseVisualStyleBackColor = false;
            this.TestUnknownWordsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TestUnknownWordsButton_MouseClick);
            // 
            // TestNewUnknownWordsButton
            // 
            this.TestNewUnknownWordsButton.BackColor = System.Drawing.Color.YellowGreen;
            this.TestNewUnknownWordsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TestNewUnknownWordsButton.Enabled = false;
            this.TestNewUnknownWordsButton.Location = new System.Drawing.Point(522, 26);
            this.TestNewUnknownWordsButton.Name = "TestNewUnknownWordsButton";
            this.TestNewUnknownWordsButton.Size = new System.Drawing.Size(40, 25);
            this.TestNewUnknownWordsButton.TabIndex = 86;
            this.TestNewUnknownWordsButton.Text = "Test";
            this.TestNewUnknownWordsButton.UseVisualStyleBackColor = false;
            this.TestNewUnknownWordsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TestNewUnknownWordsButton_MouseClick);
            // 
            // TestResultsForAllWordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 243);
            this.ControlBox = false;
            this.Controls.Add(this.TestNewUnknownWordsButton);
            this.Controls.Add(this.TestUnknownWordsButton);
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
            this.Text = "SilverLinguo™ - Visų žodžių testo rezultatai:";
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
        private System.Windows.Forms.Button TestUnknownWordsButton;
        private System.Windows.Forms.Button TestNewUnknownWordsButton;
    }
}