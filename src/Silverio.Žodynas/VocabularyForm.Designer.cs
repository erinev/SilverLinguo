namespace Silverio.Žodynas
{
    partial class VocabularyForm
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
            this.LtHeaderLabel = new System.Windows.Forms.Label();
            this.EnHeaderLabel = new System.Windows.Forms.Label();
            this.LtWordLabel = new System.Windows.Forms.Label();
            this.EnWordLabel = new System.Windows.Forms.Label();
            this.NextWordButton = new System.Windows.Forms.Button();
            this.EndTestButton = new System.Windows.Forms.Button();
            this.UnknownWordButton = new System.Windows.Forms.Button();
            this.ChangeLanguageButton = new System.Windows.Forms.Button();
            this.ProgressHeaderLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.UnknownWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.UnknownWordsCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LtHeaderLabel
            // 
            this.LtHeaderLabel.AutoSize = true;
            this.LtHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LtHeaderLabel.Location = new System.Drawing.Point(22, 13);
            this.LtHeaderLabel.Name = "LtHeaderLabel";
            this.LtHeaderLabel.Size = new System.Drawing.Size(106, 16);
            this.LtHeaderLabel.TabIndex = 0;
            this.LtHeaderLabel.Text = "Lietuviškas žodis:";
            // 
            // EnHeaderLabel
            // 
            this.EnHeaderLabel.AutoSize = true;
            this.EnHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EnHeaderLabel.Location = new System.Drawing.Point(305, 13);
            this.EnHeaderLabel.Name = "EnHeaderLabel";
            this.EnHeaderLabel.Size = new System.Drawing.Size(97, 16);
            this.EnHeaderLabel.TabIndex = 1;
            this.EnHeaderLabel.Text = "Angliškas žodis:";
            // 
            // LtWordLabel
            // 
            this.LtWordLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LtWordLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LtWordLabel.CausesValidation = false;
            this.LtWordLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LtWordLabel.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LtWordLabel.Location = new System.Drawing.Point(25, 48);
            this.LtWordLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.LtWordLabel.Name = "LtWordLabel";
            this.LtWordLabel.Padding = new System.Windows.Forms.Padding(5);
            this.LtWordLabel.Size = new System.Drawing.Size(220, 37);
            this.LtWordLabel.TabIndex = 3;
            // 
            // EnWordLabel
            // 
            this.EnWordLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EnWordLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EnWordLabel.CausesValidation = false;
            this.EnWordLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EnWordLabel.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EnWordLabel.Location = new System.Drawing.Point(308, 48);
            this.EnWordLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.EnWordLabel.Name = "EnWordLabel";
            this.EnWordLabel.Padding = new System.Windows.Forms.Padding(5);
            this.EnWordLabel.Size = new System.Drawing.Size(220, 37);
            this.EnWordLabel.TabIndex = 4;
            this.EnWordLabel.Visible = false;
            // 
            // NextWordButton
            // 
            this.NextWordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextWordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.NextWordButton.Location = new System.Drawing.Point(25, 102);
            this.NextWordButton.Name = "NextWordButton";
            this.NextWordButton.Size = new System.Drawing.Size(90, 26);
            this.NextWordButton.TabIndex = 5;
            this.NextWordButton.Text = "Kitas žodis";
            this.NextWordButton.UseVisualStyleBackColor = true;
            this.NextWordButton.Click += new System.EventHandler(this.NextWordButton_Click);
            // 
            // EndTestButton
            // 
            this.EndTestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EndTestButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.EndTestButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EndTestButton.Location = new System.Drawing.Point(228, 221);
            this.EndTestButton.Name = "EndTestButton";
            this.EndTestButton.Size = new System.Drawing.Size(98, 28);
            this.EndTestButton.TabIndex = 6;
            this.EndTestButton.Text = "Baigtį pamoką";
            this.EndTestButton.UseVisualStyleBackColor = true;
            this.EndTestButton.Click += new System.EventHandler(this.EndTestButton_Click);
            // 
            // UnknownWordButton
            // 
            this.UnknownWordButton.Cursor = System.Windows.Forms.Cursors.Help;
            this.UnknownWordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.UnknownWordButton.Location = new System.Drawing.Point(423, 102);
            this.UnknownWordButton.Name = "UnknownWordButton";
            this.UnknownWordButton.Size = new System.Drawing.Size(105, 26);
            this.UnknownWordButton.TabIndex = 7;
            this.UnknownWordButton.Text = "Nežinau žodžio";
            this.UnknownWordButton.UseVisualStyleBackColor = true;
            this.UnknownWordButton.Click += new System.EventHandler(this.UnknownWordButton_Click);
            // 
            // ChangeLanguageButton
            // 
            this.ChangeLanguageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeLanguageButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ChangeLanguageButton.Image = global::Silverio.Žodynas.Properties.Resources.EnglishFlag;
            this.ChangeLanguageButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChangeLanguageButton.Location = new System.Drawing.Point(211, 99);
            this.ChangeLanguageButton.Name = "ChangeLanguageButton";
            this.ChangeLanguageButton.Size = new System.Drawing.Size(128, 29);
            this.ChangeLanguageButton.TabIndex = 2;
            this.ChangeLanguageButton.Text = "Pakeisti kalbą";
            this.ChangeLanguageButton.UseVisualStyleBackColor = true;
            this.ChangeLanguageButton.Click += new System.EventHandler(this.ChangeLanguageButton_Click);
            // 
            // ProgressHeaderLabel
            // 
            this.ProgressHeaderLabel.AutoSize = true;
            this.ProgressHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressHeaderLabel.Location = new System.Drawing.Point(575, 13);
            this.ProgressHeaderLabel.Name = "ProgressHeaderLabel";
            this.ProgressHeaderLabel.Size = new System.Drawing.Size(67, 16);
            this.ProgressHeaderLabel.TabIndex = 8;
            this.ProgressHeaderLabel.Text = "Progresas:";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressLabel.Location = new System.Drawing.Point(575, 29);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(34, 17);
            this.ProgressLabel.TabIndex = 9;
            this.ProgressLabel.Text = "1 / 5";
            // 
            // UnknownWordsCountHeaderLabel
            // 
            this.UnknownWordsCountHeaderLabel.AutoSize = true;
            this.UnknownWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.UnknownWordsCountHeaderLabel.Location = new System.Drawing.Point(575, 78);
            this.UnknownWordsCountHeaderLabel.Name = "UnknownWordsCountHeaderLabel";
            this.UnknownWordsCountHeaderLabel.Size = new System.Drawing.Size(110, 16);
            this.UnknownWordsCountHeaderLabel.TabIndex = 10;
            this.UnknownWordsCountHeaderLabel.Text = "Nežinomi žodžiai: ";
            // 
            // UnknownWordsCountLabel
            // 
            this.UnknownWordsCountLabel.AutoSize = true;
            this.UnknownWordsCountLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.UnknownWordsCountLabel.Location = new System.Drawing.Point(575, 94);
            this.UnknownWordsCountLabel.Name = "UnknownWordsCountLabel";
            this.UnknownWordsCountLabel.Size = new System.Drawing.Size(15, 17);
            this.UnknownWordsCountLabel.TabIndex = 11;
            this.UnknownWordsCountLabel.Text = "0";
            // 
            // VocabularyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.EndTestButton;
            this.ClientSize = new System.Drawing.Size(707, 261);
            this.Controls.Add(this.UnknownWordsCountLabel);
            this.Controls.Add(this.UnknownWordsCountHeaderLabel);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.ProgressHeaderLabel);
            this.Controls.Add(this.UnknownWordButton);
            this.Controls.Add(this.EndTestButton);
            this.Controls.Add(this.NextWordButton);
            this.Controls.Add(this.EnWordLabel);
            this.Controls.Add(this.LtWordLabel);
            this.Controls.Add(this.ChangeLanguageButton);
            this.Controls.Add(this.EnHeaderLabel);
            this.Controls.Add(this.LtHeaderLabel);
            this.Name = "VocabularyForm";
            this.Text = "Žodžių testas";
            this.Load += new System.EventHandler(this.VocabularyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LtHeaderLabel;
        private System.Windows.Forms.Label EnHeaderLabel;
        private System.Windows.Forms.Button ChangeLanguageButton;
        private System.Windows.Forms.Label LtWordLabel;
        private System.Windows.Forms.Label EnWordLabel;
        private System.Windows.Forms.Button NextWordButton;
        private System.Windows.Forms.Button EndTestButton;
        private System.Windows.Forms.Button UnknownWordButton;
        private System.Windows.Forms.Label ProgressHeaderLabel;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label UnknownWordsCountHeaderLabel;
        private System.Windows.Forms.Label UnknownWordsCountLabel;
    }
}

