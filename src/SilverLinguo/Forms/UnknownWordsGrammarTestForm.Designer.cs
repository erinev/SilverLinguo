﻿using System.Windows.Forms;

namespace SilverLinguo.Forms
{
    partial class UnknownWordsGrammarTestForm
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
            this.FirstLanguageWordTextBox = new System.Windows.Forms.TextBox();
            this.SecondLanguageWordTextBox = new System.Windows.Forms.TextBox();
            this.LearnedWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.ProgressHeaderLabel = new System.Windows.Forms.Label();
            this.EndTestButton = new System.Windows.Forms.Button();
            this.EnHeaderLabel = new System.Windows.Forms.Label();
            this.LtHeaderLabel = new System.Windows.Forms.Label();
            this.NextWordButton = new System.Windows.Forms.Button();
            this.TestTimerLabel = new System.Windows.Forms.Label();
            this.LearnedWordsCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.CorrectWordTextBox = new System.Windows.Forms.TextBox();
            this.ValidateWordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstLanguageWordTextBox
            // 
            this.FirstLanguageWordTextBox.AcceptsReturn = true;
            this.FirstLanguageWordTextBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.FirstLanguageWordTextBox.Location = new System.Drawing.Point(29, 45);
            this.FirstLanguageWordTextBox.Multiline = true;
            this.FirstLanguageWordTextBox.Name = "FirstLanguageWordTextBox";
            this.FirstLanguageWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FirstLanguageWordTextBox.ShortcutsEnabled = false;
            this.FirstLanguageWordTextBox.Size = new System.Drawing.Size(356, 69);
            this.FirstLanguageWordTextBox.TabIndex = 38;
            // 
            // SecondLanguageWordTextBox
            // 
            this.SecondLanguageWordTextBox.AcceptsReturn = true;
            this.SecondLanguageWordTextBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.SecondLanguageWordTextBox.Location = new System.Drawing.Point(414, 45);
            this.SecondLanguageWordTextBox.Multiline = true;
            this.SecondLanguageWordTextBox.Name = "SecondLanguageWordTextBox";
            this.SecondLanguageWordTextBox.ReadOnly = true;
            this.SecondLanguageWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SecondLanguageWordTextBox.ShortcutsEnabled = false;
            this.SecondLanguageWordTextBox.Size = new System.Drawing.Size(356, 69);
            this.SecondLanguageWordTextBox.TabIndex = 37;
            // 
            // LearnedWordsCountHeaderLabel
            // 
            this.LearnedWordsCountHeaderLabel.AutoSize = true;
            this.LearnedWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LearnedWordsCountHeaderLabel.Location = new System.Drawing.Point(819, 69);
            this.LearnedWordsCountHeaderLabel.Name = "LearnedWordsCountHeaderLabel";
            this.LearnedWordsCountHeaderLabel.Size = new System.Drawing.Size(99, 16);
            this.LearnedWordsCountHeaderLabel.TabIndex = 33;
            this.LearnedWordsCountHeaderLabel.Text = "Išmokti žodžiai: ";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressLabel.Location = new System.Drawing.Point(819, 38);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(15, 17);
            this.ProgressLabel.TabIndex = 32;
            this.ProgressLabel.Text = "5";
            // 
            // ProgressHeaderLabel
            // 
            this.ProgressHeaderLabel.AutoSize = true;
            this.ProgressHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressHeaderLabel.Location = new System.Drawing.Point(819, 22);
            this.ProgressHeaderLabel.Name = "ProgressHeaderLabel";
            this.ProgressHeaderLabel.Size = new System.Drawing.Size(100, 16);
            this.ProgressHeaderLabel.TabIndex = 31;
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
            this.EndTestButton.Location = new System.Drawing.Point(392, 235);
            this.EndTestButton.Name = "EndTestButton";
            this.EndTestButton.Padding = new System.Windows.Forms.Padding(4);
            this.EndTestButton.Size = new System.Drawing.Size(145, 44);
            this.EndTestButton.TabIndex = 30;
            this.EndTestButton.Text = "Baigtį testą";
            this.EndTestButton.UseVisualStyleBackColor = false;
            this.EndTestButton.MouseClick += new MouseEventHandler(this.EndTestButton_MouseClick);
            // 
            // EnHeaderLabel
            // 
            this.EnHeaderLabel.AutoSize = true;
            this.EnHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EnHeaderLabel.Location = new System.Drawing.Point(411, 22);
            this.EnHeaderLabel.Name = "EnHeaderLabel";
            this.EnHeaderLabel.Size = new System.Drawing.Size(97, 16);
            this.EnHeaderLabel.TabIndex = 29;
            this.EnHeaderLabel.Text = "Angliškas žodis:";
            // 
            // LtHeaderLabel
            // 
            this.LtHeaderLabel.AutoSize = true;
            this.LtHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LtHeaderLabel.Location = new System.Drawing.Point(26, 22);
            this.LtHeaderLabel.Name = "LtHeaderLabel";
            this.LtHeaderLabel.Size = new System.Drawing.Size(106, 16);
            this.LtHeaderLabel.TabIndex = 28;
            this.LtHeaderLabel.Text = "Lietuviškas žodis:";
            // 
            // NextWordButton
            // 
            this.NextWordButton.BackColor = System.Drawing.Color.Yellow;
            this.NextWordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextWordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.NextWordButton.Location = new System.Drawing.Point(29, 120);
            this.NextWordButton.Name = "NextWordButton";
            this.NextWordButton.Padding = new System.Windows.Forms.Padding(2);
            this.NextWordButton.Size = new System.Drawing.Size(107, 39);
            this.NextWordButton.TabIndex = 40;
            this.NextWordButton.Text = "Kitas žodis";
            this.NextWordButton.UseVisualStyleBackColor = false;
            this.NextWordButton.Visible = false;
            this.NextWordButton.MouseClick += new MouseEventHandler(this.NextWordButton_MouseClick);
            // 
            // TestTimerLabel
            // 
            this.TestTimerLabel.AutoSize = true;
            this.TestTimerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TestTimerLabel.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TestTimerLabel.Location = new System.Drawing.Point(29, 252);
            this.TestTimerLabel.Name = "TestTimerLabel";
            this.TestTimerLabel.Size = new System.Drawing.Size(92, 27);
            this.TestTimerLabel.TabIndex = 42;
            this.TestTimerLabel.Text = "00:00:00";
            // 
            // LearnedWordsCountLinkLabel
            // 
            this.LearnedWordsCountLinkLabel.AutoSize = true;
            this.LearnedWordsCountLinkLabel.Location = new System.Drawing.Point(819, 85);
            this.LearnedWordsCountLinkLabel.Name = "LearnedWordsCountLinkLabel";
            this.LearnedWordsCountLinkLabel.Size = new System.Drawing.Size(15, 16);
            this.LearnedWordsCountLinkLabel.TabIndex = 43;
            this.LearnedWordsCountLinkLabel.TabStop = true;
            this.LearnedWordsCountLinkLabel.Text = "0";
            this.LearnedWordsCountLinkLabel.MouseClick += new MouseEventHandler(this.LearnedWordsCountLinkLabel_LinkMouseClicke);
            // 
            // CorrectWordTextBox
            // 
            this.CorrectWordTextBox.BackColor = System.Drawing.Color.YellowGreen;
            this.CorrectWordTextBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.CorrectWordTextBox.Location = new System.Drawing.Point(224, 120);
            this.CorrectWordTextBox.Multiline = true;
            this.CorrectWordTextBox.Name = "CorrectWordTextBox";
            this.CorrectWordTextBox.ReadOnly = true;
            this.CorrectWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CorrectWordTextBox.ShortcutsEnabled = false;
            this.CorrectWordTextBox.Size = new System.Drawing.Size(356, 69);
            this.CorrectWordTextBox.TabIndex = 44;
            this.CorrectWordTextBox.Visible = false;
            // 
            // ValidateWordButton
            // 
            this.ValidateWordButton.BackColor = System.Drawing.Color.YellowGreen;
            this.ValidateWordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ValidateWordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ValidateWordButton.Location = new System.Drawing.Point(663, 120);
            this.ValidateWordButton.Name = "ValidateWordButton";
            this.ValidateWordButton.Padding = new System.Windows.Forms.Padding(2);
            this.ValidateWordButton.Size = new System.Drawing.Size(107, 39);
            this.ValidateWordButton.TabIndex = 45;
            this.ValidateWordButton.Text = "Tikrinti";
            this.ValidateWordButton.UseVisualStyleBackColor = false;
            this.ValidateWordButton.MouseClick += new MouseEventHandler(this.ValidateWordButton_MouseClick);
            // 
            // UnknownWordsGrammarTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.EndTestButton;
            this.ClientSize = new System.Drawing.Size(930, 291);
            this.ControlBox = false;
            this.Controls.Add(this.ValidateWordButton);
            this.Controls.Add(this.CorrectWordTextBox);
            this.Controls.Add(this.LearnedWordsCountLinkLabel);
            this.Controls.Add(this.TestTimerLabel);
            this.Controls.Add(this.NextWordButton);
            this.Controls.Add(this.FirstLanguageWordTextBox);
            this.Controls.Add(this.SecondLanguageWordTextBox);
            this.Controls.Add(this.LearnedWordsCountHeaderLabel);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.ProgressHeaderLabel);
            this.Controls.Add(this.EndTestButton);
            this.Controls.Add(this.EnHeaderLabel);
            this.Controls.Add(this.LtHeaderLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.KeyPreview = true;
            this.Name = "UnknownWordsGrammarTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SilverLinguo™ - Nežinomų žodžių testas (raštu):";
            this.Load += new System.EventHandler(this.UnknownWordsGrammarTestForm_Load);
            this.Shown += new System.EventHandler(this.UnknownWordsGrammarTestForm_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UnknownWordsGrammarTestForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstLanguageWordTextBox;
        private System.Windows.Forms.TextBox SecondLanguageWordTextBox;
        private System.Windows.Forms.Label LearnedWordsCountHeaderLabel;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label ProgressHeaderLabel;
        private System.Windows.Forms.Button EndTestButton;
        private System.Windows.Forms.Label EnHeaderLabel;
        private System.Windows.Forms.Label LtHeaderLabel;
        private System.Windows.Forms.Button NextWordButton;
        private System.Windows.Forms.Label TestTimerLabel;
        private System.Windows.Forms.LinkLabel LearnedWordsCountLinkLabel;
        private System.Windows.Forms.TextBox CorrectWordTextBox;
        private Button ValidateWordButton;
    }
}