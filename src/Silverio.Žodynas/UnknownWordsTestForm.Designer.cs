﻿using System.Windows.Forms;

namespace Silverio.Žodynas
{
    partial class UnknownWordsTestForm
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
            this.LearnedWordsCountLabel = new System.Windows.Forms.Label();
            this.LearnedWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.ProgressHeaderLabel = new System.Windows.Forms.Label();
            this.EndTestButton = new System.Windows.Forms.Button();
            this.EnHeaderLabel = new System.Windows.Forms.Label();
            this.LtHeaderLabel = new System.Windows.Forms.Label();
            this.IDontKnowTheWordButton = new System.Windows.Forms.Button();
            this.NextWordButton = new System.Windows.Forms.Button();
            this.EnWordTextBox = new System.Windows.Forms.TextBox();
            this.LtWordTextBox = new System.Windows.Forms.TextBox();
            this.ShowLearnedWordsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LearnedWordsCountLabel
            // 
            this.LearnedWordsCountLabel.AutoSize = true;
            this.LearnedWordsCountLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LearnedWordsCountLabel.Location = new System.Drawing.Point(818, 123);
            this.LearnedWordsCountLabel.Name = "LearnedWordsCountLabel";
            this.LearnedWordsCountLabel.Size = new System.Drawing.Size(15, 17);
            this.LearnedWordsCountLabel.TabIndex = 23;
            this.LearnedWordsCountLabel.Text = "0";
            // 
            // LearnedWordsCountHeaderLabel
            // 
            this.LearnedWordsCountHeaderLabel.AutoSize = true;
            this.LearnedWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LearnedWordsCountHeaderLabel.Location = new System.Drawing.Point(818, 105);
            this.LearnedWordsCountHeaderLabel.Name = "LearnedWordsCountHeaderLabel";
            this.LearnedWordsCountHeaderLabel.Size = new System.Drawing.Size(99, 16);
            this.LearnedWordsCountHeaderLabel.TabIndex = 22;
            this.LearnedWordsCountHeaderLabel.Text = "Išmokti žodžiai: ";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressLabel.Location = new System.Drawing.Point(818, 48);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(15, 17);
            this.ProgressLabel.TabIndex = 21;
            this.ProgressLabel.Text = "5";
            // 
            // ProgressHeaderLabel
            // 
            this.ProgressHeaderLabel.AutoSize = true;
            this.ProgressHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressHeaderLabel.Location = new System.Drawing.Point(818, 32);
            this.ProgressHeaderLabel.Name = "ProgressHeaderLabel";
            this.ProgressHeaderLabel.Size = new System.Drawing.Size(100, 16);
            this.ProgressHeaderLabel.TabIndex = 20;
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
            this.EndTestButton.TabIndex = 18;
            this.EndTestButton.Text = "Baigtį testą";
            this.EndTestButton.UseVisualStyleBackColor = false;
            this.EndTestButton.Click += new System.EventHandler(this.EndTestButton_Click);
            // 
            // EnHeaderLabel
            // 
            this.EnHeaderLabel.AutoSize = true;
            this.EnHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EnHeaderLabel.Location = new System.Drawing.Point(410, 32);
            this.EnHeaderLabel.Name = "EnHeaderLabel";
            this.EnHeaderLabel.Size = new System.Drawing.Size(97, 16);
            this.EnHeaderLabel.TabIndex = 13;
            this.EnHeaderLabel.Text = "Angliškas žodis:";
            // 
            // LtHeaderLabel
            // 
            this.LtHeaderLabel.AutoSize = true;
            this.LtHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LtHeaderLabel.Location = new System.Drawing.Point(25, 32);
            this.LtHeaderLabel.Name = "LtHeaderLabel";
            this.LtHeaderLabel.Size = new System.Drawing.Size(106, 16);
            this.LtHeaderLabel.TabIndex = 12;
            this.LtHeaderLabel.Text = "Lietuviškas žodis:";
            // 
            // IDontKnowTheWordButton
            // 
            this.IDontKnowTheWordButton.BackColor = System.Drawing.Color.Yellow;
            this.IDontKnowTheWordButton.Cursor = System.Windows.Forms.Cursors.Help;
            this.IDontKnowTheWordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.IDontKnowTheWordButton.Location = new System.Drawing.Point(636, 138);
            this.IDontKnowTheWordButton.Name = "IDontKnowTheWordButton";
            this.IDontKnowTheWordButton.Padding = new System.Windows.Forms.Padding(2);
            this.IDontKnowTheWordButton.Size = new System.Drawing.Size(133, 39);
            this.IDontKnowTheWordButton.TabIndex = 25;
            this.IDontKnowTheWordButton.Text = "Nežinau žodžio";
            this.IDontKnowTheWordButton.UseVisualStyleBackColor = false;
            this.IDontKnowTheWordButton.Click += new System.EventHandler(this.IDontKnowTheWordButton_Click);
            // 
            // NextWordButton
            // 
            this.NextWordButton.BackColor = System.Drawing.Color.YellowGreen;
            this.NextWordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextWordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.NextWordButton.Location = new System.Drawing.Point(28, 138);
            this.NextWordButton.Name = "NextWordButton";
            this.NextWordButton.Padding = new System.Windows.Forms.Padding(2);
            this.NextWordButton.Size = new System.Drawing.Size(107, 39);
            this.NextWordButton.TabIndex = 24;
            this.NextWordButton.Text = "Kitas žodis";
            this.NextWordButton.UseVisualStyleBackColor = false;
            this.NextWordButton.Click += new System.EventHandler(this.NextWordButton_Click);
            // 
            // EnWordTextBox
            // 
            this.EnWordTextBox.AcceptsReturn = true;
            this.EnWordTextBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EnWordTextBox.Location = new System.Drawing.Point(413, 55);
            this.EnWordTextBox.Multiline = true;
            this.EnWordTextBox.Name = "EnWordTextBox";
            this.EnWordTextBox.ReadOnly = true;
            this.EnWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EnWordTextBox.Size = new System.Drawing.Size(356, 69);
            this.EnWordTextBox.TabIndex = 26;
            // 
            // LtWordTextBox
            // 
            this.LtWordTextBox.AcceptsReturn = true;
            this.LtWordTextBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LtWordTextBox.Location = new System.Drawing.Point(28, 55);
            this.LtWordTextBox.Multiline = true;
            this.LtWordTextBox.Name = "LtWordTextBox";
            this.LtWordTextBox.ReadOnly = true;
            this.LtWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LtWordTextBox.Size = new System.Drawing.Size(356, 69);
            this.LtWordTextBox.TabIndex = 27;
            // 
            // ShowLearnedWordsButton
            // 
            this.ShowLearnedWordsButton.Location = new System.Drawing.Point(821, 146);
            this.ShowLearnedWordsButton.Name = "ShowLearnedWordsButton";
            this.ShowLearnedWordsButton.Size = new System.Drawing.Size(75, 23);
            this.ShowLearnedWordsButton.TabIndex = 40;
            this.ShowLearnedWordsButton.Text = "Rodyti";
            this.ShowLearnedWordsButton.UseVisualStyleBackColor = true;
            this.ShowLearnedWordsButton.Click += new System.EventHandler(this.ShowLearnedWordsButton_Click);
            // 
            // UnknownWordsTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.EndTestButton;
            this.ClientSize = new System.Drawing.Size(930, 291);
            this.ControlBox = false;
            this.Controls.Add(this.ShowLearnedWordsButton);
            this.Controls.Add(this.LtWordTextBox);
            this.Controls.Add(this.EnWordTextBox);
            this.Controls.Add(this.IDontKnowTheWordButton);
            this.Controls.Add(this.NextWordButton);
            this.Controls.Add(this.LearnedWordsCountLabel);
            this.Controls.Add(this.LearnedWordsCountHeaderLabel);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.ProgressHeaderLabel);
            this.Controls.Add(this.EndTestButton);
            this.Controls.Add(this.EnHeaderLabel);
            this.Controls.Add(this.LtHeaderLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Name = "UnknownWordsTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nežinomu žodžiu testas";
            this.Load += new System.EventHandler(this.UnknownWordsTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LearnedWordsCountLabel;
        private System.Windows.Forms.Label LearnedWordsCountHeaderLabel;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label ProgressHeaderLabel;
        private System.Windows.Forms.Button EndTestButton;
        private System.Windows.Forms.Label EnHeaderLabel;
        private System.Windows.Forms.Label LtHeaderLabel;
        private System.Windows.Forms.Button IDontKnowTheWordButton;
        private System.Windows.Forms.Button NextWordButton;
        private System.Windows.Forms.TextBox EnWordTextBox;
        private System.Windows.Forms.TextBox LtWordTextBox;
        private Button ShowLearnedWordsButton;
    }
}