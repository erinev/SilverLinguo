namespace Silverio.Žodynas
{
    partial class StartupForm
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
            this.TestSelectionLabel = new System.Windows.Forms.Label();
            this.WordListLabel = new System.Windows.Forms.Label();
            this.WordListSelectionButton = new System.Windows.Forms.Button();
            this.UnknownWordListLabel = new System.Windows.Forms.Label();
            this.UnknownWordsListSelectionButton = new System.Windows.Forms.Button();
            this.UnknownWordsPanel = new System.Windows.Forms.Panel();
            this.UnknownWordsCountLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.WordsCountLabel = new System.Windows.Forms.Label();
            this.EndProgramButton = new System.Windows.Forms.Button();
            this.LithuanianLanguageRadioButton = new System.Windows.Forms.RadioButton();
            this.EnglishRadioButton = new System.Windows.Forms.RadioButton();
            this.RandomRadioButton = new System.Windows.Forms.RadioButton();
            this.ShouldCheckGrammarCheckBox = new System.Windows.Forms.CheckBox();
            this.UnknownWordsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestSelectionLabel
            // 
            this.TestSelectionLabel.AutoSize = true;
            this.TestSelectionLabel.Location = new System.Drawing.Point(309, 9);
            this.TestSelectionLabel.Name = "TestSelectionLabel";
            this.TestSelectionLabel.Size = new System.Drawing.Size(129, 17);
            this.TestSelectionLabel.TabIndex = 0;
            this.TestSelectionLabel.Text = "Testo pasirinkimas:";
            // 
            // WordListLabel
            // 
            this.WordListLabel.AutoSize = true;
            this.WordListLabel.Location = new System.Drawing.Point(3, 9);
            this.WordListLabel.Name = "WordListLabel";
            this.WordListLabel.Size = new System.Drawing.Size(101, 17);
            this.WordListLabel.TabIndex = 1;
            this.WordListLabel.Text = "Žodžių sąrašas:";
            // 
            // WordListSelectionButton
            // 
            this.WordListSelectionButton.BackColor = System.Drawing.Color.YellowGreen;
            this.WordListSelectionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WordListSelectionButton.Location = new System.Drawing.Point(6, 38);
            this.WordListSelectionButton.Name = "WordListSelectionButton";
            this.WordListSelectionButton.Padding = new System.Windows.Forms.Padding(2);
            this.WordListSelectionButton.Size = new System.Drawing.Size(75, 32);
            this.WordListSelectionButton.TabIndex = 2;
            this.WordListSelectionButton.Text = "Pradėti";
            this.WordListSelectionButton.UseVisualStyleBackColor = false;
            this.WordListSelectionButton.Visible = false;
            this.WordListSelectionButton.Click += new System.EventHandler(this.WordListSelectionButton_Click);
            // 
            // UnknownWordListLabel
            // 
            this.UnknownWordListLabel.AutoSize = true;
            this.UnknownWordListLabel.Location = new System.Drawing.Point(3, 9);
            this.UnknownWordListLabel.Name = "UnknownWordListLabel";
            this.UnknownWordListLabel.Size = new System.Drawing.Size(164, 17);
            this.UnknownWordListLabel.TabIndex = 3;
            this.UnknownWordListLabel.Text = "Nežinomų žodžių sąrašas:";
            // 
            // UnknownWordsListSelectionButton
            // 
            this.UnknownWordsListSelectionButton.BackColor = System.Drawing.Color.Yellow;
            this.UnknownWordsListSelectionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UnknownWordsListSelectionButton.Location = new System.Drawing.Point(6, 38);
            this.UnknownWordsListSelectionButton.Name = "UnknownWordsListSelectionButton";
            this.UnknownWordsListSelectionButton.Padding = new System.Windows.Forms.Padding(2);
            this.UnknownWordsListSelectionButton.Size = new System.Drawing.Size(75, 32);
            this.UnknownWordsListSelectionButton.TabIndex = 4;
            this.UnknownWordsListSelectionButton.Text = "Pradėti";
            this.UnknownWordsListSelectionButton.UseVisualStyleBackColor = false;
            this.UnknownWordsListSelectionButton.Click += new System.EventHandler(this.UnknownWordsListSelectionButton_Click);
            // 
            // UnknownWordsPanel
            // 
            this.UnknownWordsPanel.Controls.Add(this.UnknownWordsCountLabel);
            this.UnknownWordsPanel.Controls.Add(this.UnknownWordListLabel);
            this.UnknownWordsPanel.Controls.Add(this.UnknownWordsListSelectionButton);
            this.UnknownWordsPanel.Location = new System.Drawing.Point(466, 152);
            this.UnknownWordsPanel.Name = "UnknownWordsPanel";
            this.UnknownWordsPanel.Size = new System.Drawing.Size(236, 77);
            this.UnknownWordsPanel.TabIndex = 5;
            // 
            // UnknownWordsCountLabel
            // 
            this.UnknownWordsCountLabel.AutoSize = true;
            this.UnknownWordsCountLabel.Location = new System.Drawing.Point(164, 9);
            this.UnknownWordsCountLabel.Name = "UnknownWordsCountLabel";
            this.UnknownWordsCountLabel.Size = new System.Drawing.Size(25, 17);
            this.UnknownWordsCountLabel.TabIndex = 5;
            this.UnknownWordsCountLabel.Text = "(3)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.WordsCountLabel);
            this.panel1.Controls.Add(this.WordListLabel);
            this.panel1.Controls.Add(this.WordListSelectionButton);
            this.panel1.Location = new System.Drawing.Point(202, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 77);
            this.panel1.TabIndex = 6;
            // 
            // WordsCountLabel
            // 
            this.WordsCountLabel.AutoSize = true;
            this.WordsCountLabel.Location = new System.Drawing.Point(101, 9);
            this.WordsCountLabel.Name = "WordsCountLabel";
            this.WordsCountLabel.Size = new System.Drawing.Size(32, 17);
            this.WordsCountLabel.TabIndex = 6;
            this.WordsCountLabel.Text = "(10)";
            // 
            // EndProgramButton
            // 
            this.EndProgramButton.BackColor = System.Drawing.Color.Red;
            this.EndProgramButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EndProgramButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.EndProgramButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EndProgramButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EndProgramButton.Location = new System.Drawing.Point(326, 245);
            this.EndProgramButton.Name = "EndProgramButton";
            this.EndProgramButton.Padding = new System.Windows.Forms.Padding(4);
            this.EndProgramButton.Size = new System.Drawing.Size(145, 44);
            this.EndProgramButton.TabIndex = 7;
            this.EndProgramButton.Text = "Uždaryti programą";
            this.EndProgramButton.UseVisualStyleBackColor = false;
            this.EndProgramButton.Click += new System.EventHandler(this.EndProgramButton_Click);
            // 
            // LithuanianLanguageRadioButton
            // 
            this.LithuanianLanguageRadioButton.Image = global::Silverio.Žodynas.Properties.Resources.LithuanianFlag;
            this.LithuanianLanguageRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LithuanianLanguageRadioButton.Location = new System.Drawing.Point(208, 55);
            this.LithuanianLanguageRadioButton.Name = "LithuanianLanguageRadioButton";
            this.LithuanianLanguageRadioButton.Size = new System.Drawing.Size(132, 21);
            this.LithuanianLanguageRadioButton.TabIndex = 8;
            this.LithuanianLanguageRadioButton.TabStop = true;
            this.LithuanianLanguageRadioButton.Tag = "SelectLanguage";
            this.LithuanianLanguageRadioButton.Text = "Lietuvių kalba";
            this.LithuanianLanguageRadioButton.UseVisualStyleBackColor = true;
            // 
            // EnglishRadioButton
            // 
            this.EnglishRadioButton.Image = global::Silverio.Žodynas.Properties.Resources.EnglishFlag;
            this.EnglishRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EnglishRadioButton.Location = new System.Drawing.Point(371, 55);
            this.EnglishRadioButton.Name = "EnglishRadioButton";
            this.EnglishRadioButton.Size = new System.Drawing.Size(115, 21);
            this.EnglishRadioButton.TabIndex = 9;
            this.EnglishRadioButton.TabStop = true;
            this.EnglishRadioButton.Tag = "SelectLanguage";
            this.EnglishRadioButton.Text = "Anglų kalba";
            this.EnglishRadioButton.UseVisualStyleBackColor = true;
            // 
            // RandomRadioButton
            // 
            this.RandomRadioButton.AutoSize = true;
            this.RandomRadioButton.Location = new System.Drawing.Point(509, 55);
            this.RandomRadioButton.Name = "RandomRadioButton";
            this.RandomRadioButton.Size = new System.Drawing.Size(96, 21);
            this.RandomRadioButton.TabIndex = 10;
            this.RandomRadioButton.TabStop = true;
            this.RandomRadioButton.Tag = "SelectLanguage";
            this.RandomRadioButton.Text = "Atsitiktinis";
            this.RandomRadioButton.UseVisualStyleBackColor = true;
            // 
            // ShouldCheckGrammarCheckBox
            // 
            this.ShouldCheckGrammarCheckBox.AutoSize = true;
            this.ShouldCheckGrammarCheckBox.Location = new System.Drawing.Point(341, 98);
            this.ShouldCheckGrammarCheckBox.Name = "ShouldCheckGrammarCheckBox";
            this.ShouldCheckGrammarCheckBox.Size = new System.Drawing.Size(145, 21);
            this.ShouldCheckGrammarCheckBox.TabIndex = 11;
            this.ShouldCheckGrammarCheckBox.Text = "Rašybos tikrinimas";
            this.ShouldCheckGrammarCheckBox.UseVisualStyleBackColor = true;
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.EndProgramButton;
            this.ClientSize = new System.Drawing.Size(814, 301);
            this.ControlBox = false;
            this.Controls.Add(this.ShouldCheckGrammarCheckBox);
            this.Controls.Add(this.RandomRadioButton);
            this.Controls.Add(this.EnglishRadioButton);
            this.Controls.Add(this.LithuanianLanguageRadioButton);
            this.Controls.Add(this.EndProgramButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UnknownWordsPanel);
            this.Controls.Add(this.TestSelectionLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Name = "StartupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testo pasirinkimas:";
            this.Load += new System.EventHandler(this.StartupForm_Load);
            this.UnknownWordsPanel.ResumeLayout(false);
            this.UnknownWordsPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TestSelectionLabel;
        private System.Windows.Forms.Label WordListLabel;
        private System.Windows.Forms.Button WordListSelectionButton;
        private System.Windows.Forms.Label UnknownWordListLabel;
        private System.Windows.Forms.Button UnknownWordsListSelectionButton;
        private System.Windows.Forms.Panel UnknownWordsPanel;
        private System.Windows.Forms.Label UnknownWordsCountLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label WordsCountLabel;
        private System.Windows.Forms.Button EndProgramButton;
        private System.Windows.Forms.RadioButton LithuanianLanguageRadioButton;
        private System.Windows.Forms.RadioButton EnglishRadioButton;
        private System.Windows.Forms.RadioButton RandomRadioButton;
        private System.Windows.Forms.CheckBox ShouldCheckGrammarCheckBox;
    }
}