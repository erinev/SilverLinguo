using System;
using System.Windows.Forms;

namespace SilverLinguo
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
            this.AllWordListSelectionButton = new System.Windows.Forms.Button();
            this.UnknownWordListLabel = new System.Windows.Forms.Label();
            this.UnknownWordsListSelectionButton = new System.Windows.Forms.Button();
            this.UnknownWordsPanel = new System.Windows.Forms.Panel();
            this.UnknownWordsCountLabel = new System.Windows.Forms.Label();
            this.AllWordsPanel = new System.Windows.Forms.Panel();
            this.WordsCountLabel = new System.Windows.Forms.Label();
            this.EndProgramButton = new System.Windows.Forms.Button();
            this.LithuanianLanguageRadioButton = new System.Windows.Forms.RadioButton();
            this.EnglishRadioButton = new System.Windows.Forms.RadioButton();
            this.RandomRadioButton = new System.Windows.Forms.RadioButton();
            this.ShouldCheckGrammarCheckBox = new System.Windows.Forms.CheckBox();
            this.AdminPanelButton = new System.Windows.Forms.Button();
            this.LimitOfNewlyCreatedWordsLabel = new System.Windows.Forms.Label();
            this.CreatedAtLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CreatedAtLimitEnablingCheckBox = new System.Windows.Forms.CheckBox();
            this.UnknownWordsPanel.SuspendLayout();
            this.AllWordsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedAtLimitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TestSelectionLabel
            // 
            this.TestSelectionLabel.AutoSize = true;
            this.TestSelectionLabel.Location = new System.Drawing.Point(228, 9);
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
            // AllWordListSelectionButton
            // 
            this.AllWordListSelectionButton.BackColor = System.Drawing.Color.YellowGreen;
            this.AllWordListSelectionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AllWordListSelectionButton.Location = new System.Drawing.Point(6, 38);
            this.AllWordListSelectionButton.Name = "AllWordListSelectionButton";
            this.AllWordListSelectionButton.Padding = new System.Windows.Forms.Padding(2);
            this.AllWordListSelectionButton.Size = new System.Drawing.Size(75, 32);
            this.AllWordListSelectionButton.TabIndex = 2;
            this.AllWordListSelectionButton.Text = "Pradėti";
            this.AllWordListSelectionButton.UseVisualStyleBackColor = false;
            this.AllWordListSelectionButton.Click += new System.EventHandler(this.AllWordListSelectionButton_Click);
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
            this.UnknownWordsPanel.Location = new System.Drawing.Point(360, 152);
            this.UnknownWordsPanel.Name = "UnknownWordsPanel";
            this.UnknownWordsPanel.Size = new System.Drawing.Size(236, 77);
            this.UnknownWordsPanel.TabIndex = 5;
            this.UnknownWordsPanel.Visible = false;
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
            // AllWordsPanel
            // 
            this.AllWordsPanel.Controls.Add(this.WordsCountLabel);
            this.AllWordsPanel.Controls.Add(this.WordListLabel);
            this.AllWordsPanel.Controls.Add(this.AllWordListSelectionButton);
            this.AllWordsPanel.Location = new System.Drawing.Point(144, 152);
            this.AllWordsPanel.Name = "AllWordsPanel";
            this.AllWordsPanel.Size = new System.Drawing.Size(214, 77);
            this.AllWordsPanel.TabIndex = 6;
            this.AllWordsPanel.Visible = false;
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
            this.EndProgramButton.Location = new System.Drawing.Point(225, 245);
            this.EndProgramButton.Name = "EndProgramButton";
            this.EndProgramButton.Padding = new System.Windows.Forms.Padding(4);
            this.EndProgramButton.Size = new System.Drawing.Size(145, 44);
            this.EndProgramButton.TabIndex = 7;
            this.EndProgramButton.Text = "Uždaryti programą";
            this.EndProgramButton.UseVisualStyleBackColor = false;
            this.EndProgramButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EndProgramButton_MouseClick);
            // 
            // LithuanianLanguageRadioButton
            // 
            this.LithuanianLanguageRadioButton.Image = global::SilverLinguo.Properties.Resources.LithuanianFlag;
            this.LithuanianLanguageRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LithuanianLanguageRadioButton.Location = new System.Drawing.Point(104, 50);
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
            this.EnglishRadioButton.Image = global::SilverLinguo.Properties.Resources.EnglishFlag;
            this.EnglishRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EnglishRadioButton.Location = new System.Drawing.Point(267, 50);
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
            this.RandomRadioButton.Location = new System.Drawing.Point(405, 50);
            this.RandomRadioButton.Name = "RandomRadioButton";
            this.RandomRadioButton.Size = new System.Drawing.Size(79, 21);
            this.RandomRadioButton.TabIndex = 10;
            this.RandomRadioButton.TabStop = true;
            this.RandomRadioButton.Tag = "SelectLanguage";
            this.RandomRadioButton.Text = "Maišytas";
            this.RandomRadioButton.UseVisualStyleBackColor = true;
            // 
            // ShouldCheckGrammarCheckBox
            // 
            this.ShouldCheckGrammarCheckBox.AutoSize = true;
            this.ShouldCheckGrammarCheckBox.Location = new System.Drawing.Point(88, 102);
            this.ShouldCheckGrammarCheckBox.Name = "ShouldCheckGrammarCheckBox";
            this.ShouldCheckGrammarCheckBox.Size = new System.Drawing.Size(145, 21);
            this.ShouldCheckGrammarCheckBox.TabIndex = 11;
            this.ShouldCheckGrammarCheckBox.Text = "Rašybos tikrinimas";
            this.ShouldCheckGrammarCheckBox.UseVisualStyleBackColor = true;
            // 
            // AdminPanelButton
            // 
            this.AdminPanelButton.BackColor = System.Drawing.Color.Orange;
            this.AdminPanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdminPanelButton.Location = new System.Drawing.Point(527, 2);
            this.AdminPanelButton.Name = "AdminPanelButton";
            this.AdminPanelButton.Padding = new System.Windows.Forms.Padding(2);
            this.AdminPanelButton.Size = new System.Drawing.Size(103, 32);
            this.AdminPanelButton.TabIndex = 14;
            this.AdminPanelButton.Text = "Redaktorius";
            this.AdminPanelButton.UseVisualStyleBackColor = false;
            this.AdminPanelButton.Click += new System.EventHandler(this.AdminPanelButton_Click);
            // 
            // LimitOfNewlyCreatedWordsLabel
            // 
            this.LimitOfNewlyCreatedWordsLabel.AutoSize = true;
            this.LimitOfNewlyCreatedWordsLabel.Location = new System.Drawing.Point(281, 100);
            this.LimitOfNewlyCreatedWordsLabel.Name = "LimitOfNewlyCreatedWordsLabel";
            this.LimitOfNewlyCreatedWordsLabel.Size = new System.Drawing.Size(0, 17);
            this.LimitOfNewlyCreatedWordsLabel.TabIndex = 15;
            // 
            // CreatedAtLimitNumericUpDown
            // 
            this.CreatedAtLimitNumericUpDown.Enabled = false;
            this.CreatedAtLimitNumericUpDown.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.CreatedAtLimitNumericUpDown.Location = new System.Drawing.Point(503, 100);
            this.CreatedAtLimitNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CreatedAtLimitNumericUpDown.Name = "CreatedAtLimitNumericUpDown";
            this.CreatedAtLimitNumericUpDown.Size = new System.Drawing.Size(58, 23);
            this.CreatedAtLimitNumericUpDown.TabIndex = 16;
            this.CreatedAtLimitNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CreatedAtLimitNumericUpDown.Leave += new System.EventHandler(this.CreatedAtLimitNumericUpDown_Leave);
            // 
            // CreatedAtLimitEnablingCheckBox
            // 
            this.CreatedAtLimitEnablingCheckBox.AutoSize = true;
            this.CreatedAtLimitEnablingCheckBox.Location = new System.Drawing.Point(253, 102);
            this.CreatedAtLimitEnablingCheckBox.Name = "CreatedAtLimitEnablingCheckBox";
            this.CreatedAtLimitEnablingCheckBox.Size = new System.Drawing.Size(250, 21);
            this.CreatedAtLimitEnablingCheckBox.TabIndex = 17;
            this.CreatedAtLimitEnablingCheckBox.Text = "Žodžių kiekis (pagal sukūrimo datą)";
            this.CreatedAtLimitEnablingCheckBox.UseVisualStyleBackColor = true;
            this.CreatedAtLimitEnablingCheckBox.CheckedChanged += new System.EventHandler(this.CreatedAtLimitEnablingCheckBox_CheckedChanged);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.EndProgramButton;
            this.ClientSize = new System.Drawing.Size(634, 301);
            this.ControlBox = false;
            this.Controls.Add(this.CreatedAtLimitEnablingCheckBox);
            this.Controls.Add(this.CreatedAtLimitNumericUpDown);
            this.Controls.Add(this.LimitOfNewlyCreatedWordsLabel);
            this.Controls.Add(this.AdminPanelButton);
            this.Controls.Add(this.ShouldCheckGrammarCheckBox);
            this.Controls.Add(this.RandomRadioButton);
            this.Controls.Add(this.EnglishRadioButton);
            this.Controls.Add(this.LithuanianLanguageRadioButton);
            this.Controls.Add(this.EndProgramButton);
            this.Controls.Add(this.AllWordsPanel);
            this.Controls.Add(this.UnknownWordsPanel);
            this.Controls.Add(this.TestSelectionLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Name = "StartupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SilverLinguo™";
            this.Load += new System.EventHandler(this.StartupForm_Load);
            this.UnknownWordsPanel.ResumeLayout(false);
            this.UnknownWordsPanel.PerformLayout();
            this.AllWordsPanel.ResumeLayout(false);
            this.AllWordsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedAtLimitNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TestSelectionLabel;
        private System.Windows.Forms.Label WordListLabel;
        private System.Windows.Forms.Button AllWordListSelectionButton;
        private System.Windows.Forms.Label UnknownWordListLabel;
        private System.Windows.Forms.Button UnknownWordsListSelectionButton;
        private System.Windows.Forms.Panel UnknownWordsPanel;
        private System.Windows.Forms.Label UnknownWordsCountLabel;
        private System.Windows.Forms.Panel AllWordsPanel;
        private System.Windows.Forms.Label WordsCountLabel;
        private System.Windows.Forms.Button EndProgramButton;
        private System.Windows.Forms.RadioButton LithuanianLanguageRadioButton;
        private System.Windows.Forms.RadioButton EnglishRadioButton;
        private System.Windows.Forms.RadioButton RandomRadioButton;
        private System.Windows.Forms.CheckBox ShouldCheckGrammarCheckBox;
        private System.Windows.Forms.Button AdminPanelButton;
        private Label LimitOfNewlyCreatedWordsLabel;
        private NumericUpDown CreatedAtLimitNumericUpDown;
        private CheckBox CreatedAtLimitEnablingCheckBox;
    }
}