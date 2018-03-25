namespace Words.Test.Forms
{
    partial class AllWordsVerbalTestForm
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
            this.NewUnknownWordsCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.TestTimerLabel = new System.Windows.Forms.Label();
            this.FirstLanguageWordTextBox = new System.Windows.Forms.TextBox();
            this.SecondLanguageWordTextBox = new System.Windows.Forms.TextBox();
            this.IDontKnowTheWordButton = new System.Windows.Forms.Button();
            this.NextWordButton = new System.Windows.Forms.Button();
            this.NewUnknownWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.ProgressHeaderLabel = new System.Windows.Forms.Label();
            this.EndTestButton = new System.Windows.Forms.Button();
            this.EnHeaderLabel = new System.Windows.Forms.Label();
            this.LtHeaderLabel = new System.Windows.Forms.Label();
            this.UnknownWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.UnknownWordsCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.NewLearnedWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.NewLearnedWordsCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.KnownWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.KnownWordsCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // NewUnknownWordsCountLinkLabel
            // 
            this.NewUnknownWordsCountLinkLabel.AutoSize = true;
            this.NewUnknownWordsCountLinkLabel.Location = new System.Drawing.Point(812, 80);
            this.NewUnknownWordsCountLinkLabel.Name = "NewUnknownWordsCountLinkLabel";
            this.NewUnknownWordsCountLinkLabel.Size = new System.Drawing.Size(15, 16);
            this.NewUnknownWordsCountLinkLabel.TabIndex = 56;
            this.NewUnknownWordsCountLinkLabel.TabStop = true;
            this.NewUnknownWordsCountLinkLabel.Text = "0";
            // 
            // TestTimerLabel
            // 
            this.TestTimerLabel.AutoSize = true;
            this.TestTimerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TestTimerLabel.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TestTimerLabel.Location = new System.Drawing.Point(22, 247);
            this.TestTimerLabel.Name = "TestTimerLabel";
            this.TestTimerLabel.Size = new System.Drawing.Size(92, 27);
            this.TestTimerLabel.TabIndex = 55;
            this.TestTimerLabel.Text = "00:00:00";
            // 
            // FirstLanguageWordTextBox
            // 
            this.FirstLanguageWordTextBox.AcceptsReturn = true;
            this.FirstLanguageWordTextBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.FirstLanguageWordTextBox.Location = new System.Drawing.Point(22, 40);
            this.FirstLanguageWordTextBox.Multiline = true;
            this.FirstLanguageWordTextBox.Name = "FirstLanguageWordTextBox";
            this.FirstLanguageWordTextBox.ReadOnly = true;
            this.FirstLanguageWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FirstLanguageWordTextBox.ShortcutsEnabled = false;
            this.FirstLanguageWordTextBox.Size = new System.Drawing.Size(356, 69);
            this.FirstLanguageWordTextBox.TabIndex = 54;
            // 
            // SecondLanguageWordTextBox
            // 
            this.SecondLanguageWordTextBox.AcceptsReturn = true;
            this.SecondLanguageWordTextBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.SecondLanguageWordTextBox.Location = new System.Drawing.Point(407, 40);
            this.SecondLanguageWordTextBox.Multiline = true;
            this.SecondLanguageWordTextBox.Name = "SecondLanguageWordTextBox";
            this.SecondLanguageWordTextBox.ReadOnly = true;
            this.SecondLanguageWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SecondLanguageWordTextBox.ShortcutsEnabled = false;
            this.SecondLanguageWordTextBox.Size = new System.Drawing.Size(356, 69);
            this.SecondLanguageWordTextBox.TabIndex = 53;
            // 
            // IDontKnowTheWordButton
            // 
            this.IDontKnowTheWordButton.BackColor = System.Drawing.Color.Yellow;
            this.IDontKnowTheWordButton.Cursor = System.Windows.Forms.Cursors.Help;
            this.IDontKnowTheWordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.IDontKnowTheWordButton.Location = new System.Drawing.Point(630, 123);
            this.IDontKnowTheWordButton.Name = "IDontKnowTheWordButton";
            this.IDontKnowTheWordButton.Padding = new System.Windows.Forms.Padding(2);
            this.IDontKnowTheWordButton.Size = new System.Drawing.Size(133, 39);
            this.IDontKnowTheWordButton.TabIndex = 52;
            this.IDontKnowTheWordButton.Text = "Nežinau žodžio";
            this.IDontKnowTheWordButton.UseVisualStyleBackColor = false;
            this.IDontKnowTheWordButton.Click += new System.EventHandler(this.IDontKnowTheWordButton_Click);
            // 
            // NextWordButton
            // 
            this.NextWordButton.BackColor = System.Drawing.Color.YellowGreen;
            this.NextWordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextWordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.NextWordButton.Location = new System.Drawing.Point(22, 123);
            this.NextWordButton.Name = "NextWordButton";
            this.NextWordButton.Padding = new System.Windows.Forms.Padding(2);
            this.NextWordButton.Size = new System.Drawing.Size(107, 39);
            this.NextWordButton.TabIndex = 51;
            this.NextWordButton.Text = "Kitas žodis";
            this.NextWordButton.UseVisualStyleBackColor = false;
            this.NextWordButton.Click += new System.EventHandler(this.NextWordButton_Click);
            // 
            // NewUnknownWordsCountHeaderLabel
            // 
            this.NewUnknownWordsCountHeaderLabel.AutoSize = true;
            this.NewUnknownWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.NewUnknownWordsCountHeaderLabel.Location = new System.Drawing.Point(812, 64);
            this.NewUnknownWordsCountHeaderLabel.Name = "NewUnknownWordsCountHeaderLabel";
            this.NewUnknownWordsCountHeaderLabel.Size = new System.Drawing.Size(140, 16);
            this.NewUnknownWordsCountHeaderLabel.TabIndex = 50;
            this.NewUnknownWordsCountHeaderLabel.Text = "Nauji nežinomi žodžiai: ";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressLabel.Location = new System.Drawing.Point(812, 33);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(15, 17);
            this.ProgressLabel.TabIndex = 49;
            this.ProgressLabel.Text = "5";
            // 
            // ProgressHeaderLabel
            // 
            this.ProgressHeaderLabel.AutoSize = true;
            this.ProgressHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressHeaderLabel.Location = new System.Drawing.Point(812, 17);
            this.ProgressHeaderLabel.Name = "ProgressHeaderLabel";
            this.ProgressHeaderLabel.Size = new System.Drawing.Size(100, 16);
            this.ProgressHeaderLabel.TabIndex = 48;
            this.ProgressHeaderLabel.Text = "Kiek liko žodžių:";
            // 
            // EndTestButton
            // 
            this.EndTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EndTestButton.BackColor = System.Drawing.Color.Red;
            this.EndTestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EndTestButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.EndTestButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EndTestButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EndTestButton.Location = new System.Drawing.Point(407, 230);
            this.EndTestButton.Name = "EndTestButton";
            this.EndTestButton.Padding = new System.Windows.Forms.Padding(4);
            this.EndTestButton.Size = new System.Drawing.Size(149, 44);
            this.EndTestButton.TabIndex = 47;
            this.EndTestButton.Text = "Baigtį testą";
            this.EndTestButton.UseVisualStyleBackColor = false;
            this.EndTestButton.Click += new System.EventHandler(this.EndTestButton_Click);
            // 
            // EnHeaderLabel
            // 
            this.EnHeaderLabel.AutoSize = true;
            this.EnHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EnHeaderLabel.Location = new System.Drawing.Point(404, 17);
            this.EnHeaderLabel.Name = "EnHeaderLabel";
            this.EnHeaderLabel.Size = new System.Drawing.Size(97, 16);
            this.EnHeaderLabel.TabIndex = 46;
            this.EnHeaderLabel.Text = "Angliškas žodis:";
            // 
            // LtHeaderLabel
            // 
            this.LtHeaderLabel.AutoSize = true;
            this.LtHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LtHeaderLabel.Location = new System.Drawing.Point(19, 17);
            this.LtHeaderLabel.Name = "LtHeaderLabel";
            this.LtHeaderLabel.Size = new System.Drawing.Size(106, 16);
            this.LtHeaderLabel.TabIndex = 45;
            this.LtHeaderLabel.Text = "Lietuviškas žodis:";
            // 
            // UnknownWordsCountHeaderLabel
            // 
            this.UnknownWordsCountHeaderLabel.AutoSize = true;
            this.UnknownWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.UnknownWordsCountHeaderLabel.Location = new System.Drawing.Point(812, 113);
            this.UnknownWordsCountHeaderLabel.Name = "UnknownWordsCountHeaderLabel";
            this.UnknownWordsCountHeaderLabel.Size = new System.Drawing.Size(150, 16);
            this.UnknownWordsCountHeaderLabel.TabIndex = 57;
            this.UnknownWordsCountHeaderLabel.Text = "Vis dar nežinomi žodžiai: ";
            // 
            // UnknownWordsCountLinkLabel
            // 
            this.UnknownWordsCountLinkLabel.AutoSize = true;
            this.UnknownWordsCountLinkLabel.Location = new System.Drawing.Point(812, 129);
            this.UnknownWordsCountLinkLabel.Name = "UnknownWordsCountLinkLabel";
            this.UnknownWordsCountLinkLabel.Size = new System.Drawing.Size(15, 16);
            this.UnknownWordsCountLinkLabel.TabIndex = 58;
            this.UnknownWordsCountLinkLabel.TabStop = true;
            this.UnknownWordsCountLinkLabel.Text = "0";
            // 
            // NewLearnedWordsCountHeaderLabel
            // 
            this.NewLearnedWordsCountHeaderLabel.AutoSize = true;
            this.NewLearnedWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.NewLearnedWordsCountHeaderLabel.Location = new System.Drawing.Point(812, 161);
            this.NewLearnedWordsCountHeaderLabel.Name = "NewLearnedWordsCountHeaderLabel";
            this.NewLearnedWordsCountHeaderLabel.Size = new System.Drawing.Size(132, 16);
            this.NewLearnedWordsCountHeaderLabel.TabIndex = 59;
            this.NewLearnedWordsCountHeaderLabel.Text = "Nauji Išmokti žodžiai: ";
            // 
            // NewLearnedWordsCountLinkLabel
            // 
            this.NewLearnedWordsCountLinkLabel.AutoSize = true;
            this.NewLearnedWordsCountLinkLabel.Location = new System.Drawing.Point(812, 177);
            this.NewLearnedWordsCountLinkLabel.Name = "NewLearnedWordsCountLinkLabel";
            this.NewLearnedWordsCountLinkLabel.Size = new System.Drawing.Size(15, 16);
            this.NewLearnedWordsCountLinkLabel.TabIndex = 60;
            this.NewLearnedWordsCountLinkLabel.TabStop = true;
            this.NewLearnedWordsCountLinkLabel.Text = "0";
            // 
            // KnownWordsCountHeaderLabel
            // 
            this.KnownWordsCountHeaderLabel.AutoSize = true;
            this.KnownWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.KnownWordsCountHeaderLabel.Location = new System.Drawing.Point(812, 210);
            this.KnownWordsCountHeaderLabel.Name = "KnownWordsCountHeaderLabel";
            this.KnownWordsCountHeaderLabel.Size = new System.Drawing.Size(96, 16);
            this.KnownWordsCountHeaderLabel.TabIndex = 61;
            this.KnownWordsCountHeaderLabel.Text = "Žinomi žodžiai: ";
            // 
            // KnownWordsCountLinkLabel
            // 
            this.KnownWordsCountLinkLabel.AutoSize = true;
            this.KnownWordsCountLinkLabel.Location = new System.Drawing.Point(812, 227);
            this.KnownWordsCountLinkLabel.Name = "KnownWordsCountLinkLabel";
            this.KnownWordsCountLinkLabel.Size = new System.Drawing.Size(15, 16);
            this.KnownWordsCountLinkLabel.TabIndex = 62;
            this.KnownWordsCountLinkLabel.TabStop = true;
            this.KnownWordsCountLinkLabel.Text = "0";
            // 
            // AllWordsVerbalTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(969, 291);
            this.ControlBox = false;
            this.Controls.Add(this.KnownWordsCountLinkLabel);
            this.Controls.Add(this.KnownWordsCountHeaderLabel);
            this.Controls.Add(this.NewLearnedWordsCountLinkLabel);
            this.Controls.Add(this.NewLearnedWordsCountHeaderLabel);
            this.Controls.Add(this.UnknownWordsCountLinkLabel);
            this.Controls.Add(this.UnknownWordsCountHeaderLabel);
            this.Controls.Add(this.NewUnknownWordsCountLinkLabel);
            this.Controls.Add(this.TestTimerLabel);
            this.Controls.Add(this.FirstLanguageWordTextBox);
            this.Controls.Add(this.SecondLanguageWordTextBox);
            this.Controls.Add(this.IDontKnowTheWordButton);
            this.Controls.Add(this.NextWordButton);
            this.Controls.Add(this.NewUnknownWordsCountHeaderLabel);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.ProgressHeaderLabel);
            this.Controls.Add(this.EndTestButton);
            this.Controls.Add(this.EnHeaderLabel);
            this.Controls.Add(this.LtHeaderLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.KeyPreview = true;
            this.Name = "AllWordsVerbalTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visų žodžių testas (žodžiu):";
            this.Load += new System.EventHandler(this.AllWordsVerbalTestForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllWordsVerbalTestForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel NewUnknownWordsCountLinkLabel;
        private System.Windows.Forms.Label TestTimerLabel;
        private System.Windows.Forms.TextBox FirstLanguageWordTextBox;
        private System.Windows.Forms.TextBox SecondLanguageWordTextBox;
        private System.Windows.Forms.Button IDontKnowTheWordButton;
        private System.Windows.Forms.Button NextWordButton;
        private System.Windows.Forms.Label NewUnknownWordsCountHeaderLabel;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label ProgressHeaderLabel;
        private System.Windows.Forms.Button EndTestButton;
        private System.Windows.Forms.Label EnHeaderLabel;
        private System.Windows.Forms.Label LtHeaderLabel;
        private System.Windows.Forms.Label UnknownWordsCountHeaderLabel;
        private System.Windows.Forms.LinkLabel UnknownWordsCountLinkLabel;
        private System.Windows.Forms.Label NewLearnedWordsCountHeaderLabel;
        private System.Windows.Forms.LinkLabel NewLearnedWordsCountLinkLabel;
        private System.Windows.Forms.Label KnownWordsCountHeaderLabel;
        private System.Windows.Forms.LinkLabel KnownWordsCountLinkLabel;
    }
}

