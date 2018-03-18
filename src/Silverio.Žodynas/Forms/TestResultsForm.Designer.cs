﻿namespace Silverio.Žodynas.Forms
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
            this.WordsStatsHeaderLabel = new System.Windows.Forms.Label();
            this.WordsStatsLabel = new System.Windows.Forms.LinkLabel();
            this.StartDifferentTestButton = new System.Windows.Forms.Button();
            this.EndProgramButton = new System.Windows.Forms.Button();
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
            this.ElapsedTimeLabel.Location = new System.Drawing.Point(373, 25);
            this.ElapsedTimeLabel.Name = "ElapsedTimeLabel";
            this.ElapsedTimeLabel.Size = new System.Drawing.Size(56, 16);
            this.ElapsedTimeLabel.TabIndex = 1;
            this.ElapsedTimeLabel.Text = "00:05:29";
            // 
            // SelectedLanguageHeaderLabel
            // 
            this.SelectedLanguageHeaderLabel.AutoSize = true;
            this.SelectedLanguageHeaderLabel.Location = new System.Drawing.Point(12, 25);
            this.SelectedLanguageHeaderLabel.Name = "SelectedLanguageHeaderLabel";
            this.SelectedLanguageHeaderLabel.Size = new System.Drawing.Size(100, 16);
            this.SelectedLanguageHeaderLabel.TabIndex = 2;
            this.SelectedLanguageHeaderLabel.Text = "Pasrinkta kalba: ";
            // 
            // SelectedLanguageLabel
            // 
            this.SelectedLanguageLabel.AutoSize = true;
            this.SelectedLanguageLabel.Location = new System.Drawing.Point(118, 25);
            this.SelectedLanguageLabel.Name = "SelectedLanguageLabel";
            this.SelectedLanguageLabel.Size = new System.Drawing.Size(53, 16);
            this.SelectedLanguageLabel.TabIndex = 3;
            this.SelectedLanguageLabel.Text = "Lietuvių";
            // 
            // SelectedTestTypeHeaderLabel
            // 
            this.SelectedTestTypeHeaderLabel.AutoSize = true;
            this.SelectedTestTypeHeaderLabel.Location = new System.Drawing.Point(12, 55);
            this.SelectedTestTypeHeaderLabel.Name = "SelectedTestTypeHeaderLabel";
            this.SelectedTestTypeHeaderLabel.Size = new System.Drawing.Size(76, 16);
            this.SelectedTestTypeHeaderLabel.TabIndex = 4;
            this.SelectedTestTypeHeaderLabel.Text = "Testo tipas: ";
            // 
            // SelectedTestTypeLabel
            // 
            this.SelectedTestTypeLabel.AutoSize = true;
            this.SelectedTestTypeLabel.Location = new System.Drawing.Point(118, 55);
            this.SelectedTestTypeLabel.Name = "SelectedTestTypeLabel";
            this.SelectedTestTypeLabel.Size = new System.Drawing.Size(39, 16);
            this.SelectedTestTypeLabel.TabIndex = 5;
            this.SelectedTestTypeLabel.Text = "Raštu";
            // 
            // WordsStatsHeaderLabel
            // 
            this.WordsStatsHeaderLabel.AutoSize = true;
            this.WordsStatsHeaderLabel.Location = new System.Drawing.Point(272, 55);
            this.WordsStatsHeaderLabel.Name = "WordsStatsHeaderLabel";
            this.WordsStatsHeaderLabel.Size = new System.Drawing.Size(95, 16);
            this.WordsStatsHeaderLabel.TabIndex = 6;
            this.WordsStatsHeaderLabel.Text = "Išmokti žodžiai:";
            // 
            // WordsStatsLabel
            // 
            this.WordsStatsLabel.AutoSize = true;
            this.WordsStatsLabel.Location = new System.Drawing.Point(373, 55);
            this.WordsStatsLabel.Name = "WordsStatsLabel";
            this.WordsStatsLabel.Size = new System.Drawing.Size(15, 16);
            this.WordsStatsLabel.TabIndex = 8;
            this.WordsStatsLabel.TabStop = true;
            this.WordsStatsLabel.Text = "5";
            this.WordsStatsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WordsStatsLabel_LinkClicked);
            // 
            // StartDifferentTestButton
            // 
            this.StartDifferentTestButton.BackColor = System.Drawing.Color.YellowGreen;
            this.StartDifferentTestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartDifferentTestButton.Location = new System.Drawing.Point(229, 152);
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
            this.EndProgramButton.Location = new System.Drawing.Point(444, 152);
            this.EndProgramButton.Name = "EndProgramButton";
            this.EndProgramButton.Padding = new System.Windows.Forms.Padding(2);
            this.EndProgramButton.Size = new System.Drawing.Size(138, 32);
            this.EndProgramButton.TabIndex = 10;
            this.EndProgramButton.Text = "Uždaryti programą";
            this.EndProgramButton.UseVisualStyleBackColor = false;
            this.EndProgramButton.Click += new System.EventHandler(this.EndProgramButton_Click);
            // 
            // TestResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 291);
            this.ControlBox = false;
            this.Controls.Add(this.EndProgramButton);
            this.Controls.Add(this.StartDifferentTestButton);
            this.Controls.Add(this.WordsStatsLabel);
            this.Controls.Add(this.WordsStatsHeaderLabel);
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
        private System.Windows.Forms.Label WordsStatsHeaderLabel;
        private System.Windows.Forms.LinkLabel WordsStatsLabel;
        private System.Windows.Forms.Button StartDifferentTestButton;
        private System.Windows.Forms.Button EndProgramButton;
    }
}