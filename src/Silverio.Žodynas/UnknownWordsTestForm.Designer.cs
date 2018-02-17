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
            this.UnknownWordsCountLabel = new System.Windows.Forms.Label();
            this.LearnedWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.ProgressHeaderLabel = new System.Windows.Forms.Label();
            this.LearnedWordButton = new System.Windows.Forms.Button();
            this.EndTestButton = new System.Windows.Forms.Button();
            this.NextWordButton = new System.Windows.Forms.Button();
            this.EnWordLabel = new System.Windows.Forms.Label();
            this.LtWordLabel = new System.Windows.Forms.Label();
            this.ChangeLanguageButton = new System.Windows.Forms.Button();
            this.EnHeaderLabel = new System.Windows.Forms.Label();
            this.LtHeaderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UnknownWordsCountLabel
            // 
            this.UnknownWordsCountLabel.AutoSize = true;
            this.UnknownWordsCountLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.UnknownWordsCountLabel.Location = new System.Drawing.Point(670, 107);
            this.UnknownWordsCountLabel.Name = "UnknownWordsCountLabel";
            this.UnknownWordsCountLabel.Size = new System.Drawing.Size(15, 17);
            this.UnknownWordsCountLabel.TabIndex = 23;
            this.UnknownWordsCountLabel.Text = "0";
            // 
            // LearnedWordsCountHeaderLabel
            // 
            this.LearnedWordsCountHeaderLabel.AutoSize = true;
            this.LearnedWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LearnedWordsCountHeaderLabel.Location = new System.Drawing.Point(670, 89);
            this.LearnedWordsCountHeaderLabel.Name = "LearnedWordsCountHeaderLabel";
            this.LearnedWordsCountHeaderLabel.Size = new System.Drawing.Size(99, 16);
            this.LearnedWordsCountHeaderLabel.TabIndex = 22;
            this.LearnedWordsCountHeaderLabel.Text = "Išmokti žodžiai: ";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressLabel.Location = new System.Drawing.Point(670, 32);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(34, 17);
            this.ProgressLabel.TabIndex = 21;
            this.ProgressLabel.Text = "1 / 5";
            // 
            // ProgressHeaderLabel
            // 
            this.ProgressHeaderLabel.AutoSize = true;
            this.ProgressHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressHeaderLabel.Location = new System.Drawing.Point(670, 14);
            this.ProgressHeaderLabel.Name = "ProgressHeaderLabel";
            this.ProgressHeaderLabel.Size = new System.Drawing.Size(67, 16);
            this.ProgressHeaderLabel.TabIndex = 20;
            this.ProgressHeaderLabel.Text = "Progresas:";
            // 
            // LearnedWordButton
            // 
            this.LearnedWordButton.BackColor = System.Drawing.Color.Yellow;
            this.LearnedWordButton.Cursor = System.Windows.Forms.Cursors.Help;
            this.LearnedWordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LearnedWordButton.Location = new System.Drawing.Point(482, 114);
            this.LearnedWordButton.Name = "LearnedWordButton";
            this.LearnedWordButton.Padding = new System.Windows.Forms.Padding(2);
            this.LearnedWordButton.Size = new System.Drawing.Size(133, 39);
            this.LearnedWordButton.TabIndex = 19;
            this.LearnedWordButton.Text = "Išmokau žodį";
            this.LearnedWordButton.UseVisualStyleBackColor = false;
            this.LearnedWordButton.Click += new System.EventHandler(this.LearnedWordButton_Click);
            // 
            // EndTestButton
            // 
            this.EndTestButton.BackColor = System.Drawing.Color.Red;
            this.EndTestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EndTestButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.EndTestButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EndTestButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EndTestButton.Location = new System.Drawing.Point(345, 242);
            this.EndTestButton.Name = "EndTestButton";
            this.EndTestButton.Padding = new System.Windows.Forms.Padding(4);
            this.EndTestButton.Size = new System.Drawing.Size(145, 44);
            this.EndTestButton.TabIndex = 18;
            this.EndTestButton.Text = "Baigtį testą";
            this.EndTestButton.UseVisualStyleBackColor = false;
            this.EndTestButton.Click += new System.EventHandler(this.EndTestButton_Click);
            // 
            // NextWordButton
            // 
            this.NextWordButton.BackColor = System.Drawing.Color.YellowGreen;
            this.NextWordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextWordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.NextWordButton.Location = new System.Drawing.Point(28, 114);
            this.NextWordButton.Name = "NextWordButton";
            this.NextWordButton.Padding = new System.Windows.Forms.Padding(2);
            this.NextWordButton.Size = new System.Drawing.Size(107, 39);
            this.NextWordButton.TabIndex = 17;
            this.NextWordButton.Text = "Kitas žodis";
            this.NextWordButton.UseVisualStyleBackColor = false;
            this.NextWordButton.Click += new System.EventHandler(this.NextWordButton_Click);
            // 
            // EnWordLabel
            // 
            this.EnWordLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EnWordLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EnWordLabel.CausesValidation = false;
            this.EnWordLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EnWordLabel.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EnWordLabel.Location = new System.Drawing.Point(358, 55);
            this.EnWordLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.EnWordLabel.Name = "EnWordLabel";
            this.EnWordLabel.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.EnWordLabel.Size = new System.Drawing.Size(257, 43);
            this.EnWordLabel.TabIndex = 16;
            this.EnWordLabel.Visible = false;
            // 
            // LtWordLabel
            // 
            this.LtWordLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LtWordLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LtWordLabel.CausesValidation = false;
            this.LtWordLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LtWordLabel.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LtWordLabel.Location = new System.Drawing.Point(28, 55);
            this.LtWordLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.LtWordLabel.Name = "LtWordLabel";
            this.LtWordLabel.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.LtWordLabel.Size = new System.Drawing.Size(257, 43);
            this.LtWordLabel.TabIndex = 15;
            // 
            // ChangeLanguageButton
            // 
            this.ChangeLanguageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeLanguageButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ChangeLanguageButton.Image = global::Silverio.Žodynas.Properties.Resources.EnglishFlag;
            this.ChangeLanguageButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChangeLanguageButton.Location = new System.Drawing.Point(231, 114);
            this.ChangeLanguageButton.Name = "ChangeLanguageButton";
            this.ChangeLanguageButton.Padding = new System.Windows.Forms.Padding(2);
            this.ChangeLanguageButton.Size = new System.Drawing.Size(163, 33);
            this.ChangeLanguageButton.TabIndex = 14;
            this.ChangeLanguageButton.Text = "Pakeisti kalbą";
            this.ChangeLanguageButton.UseVisualStyleBackColor = true;
            this.ChangeLanguageButton.Click += new System.EventHandler(this.ChangeLanguageButton_Click);
            // 
            // EnHeaderLabel
            // 
            this.EnHeaderLabel.AutoSize = true;
            this.EnHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EnHeaderLabel.Location = new System.Drawing.Point(355, 14);
            this.EnHeaderLabel.Name = "EnHeaderLabel";
            this.EnHeaderLabel.Size = new System.Drawing.Size(97, 16);
            this.EnHeaderLabel.TabIndex = 13;
            this.EnHeaderLabel.Text = "Angliškas žodis:";
            // 
            // LtHeaderLabel
            // 
            this.LtHeaderLabel.AutoSize = true;
            this.LtHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LtHeaderLabel.Location = new System.Drawing.Point(25, 14);
            this.LtHeaderLabel.Name = "LtHeaderLabel";
            this.LtHeaderLabel.Size = new System.Drawing.Size(106, 16);
            this.LtHeaderLabel.TabIndex = 12;
            this.LtHeaderLabel.Text = "Lietuviškas žodis:";
            // 
            // UnknownWordsTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.EndTestButton;
            this.ClientSize = new System.Drawing.Size(804, 301);
            this.ControlBox = false;
            this.Controls.Add(this.UnknownWordsCountLabel);
            this.Controls.Add(this.LearnedWordsCountHeaderLabel);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.ProgressHeaderLabel);
            this.Controls.Add(this.LearnedWordButton);
            this.Controls.Add(this.EndTestButton);
            this.Controls.Add(this.NextWordButton);
            this.Controls.Add(this.EnWordLabel);
            this.Controls.Add(this.LtWordLabel);
            this.Controls.Add(this.ChangeLanguageButton);
            this.Controls.Add(this.EnHeaderLabel);
            this.Controls.Add(this.LtHeaderLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Name = "UnknownWordsTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nežinomų žodžių testas";
            this.Load += new System.EventHandler(this.UnknownWordsTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UnknownWordsCountLabel;
        private System.Windows.Forms.Label LearnedWordsCountHeaderLabel;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label ProgressHeaderLabel;
        private System.Windows.Forms.Button LearnedWordButton;
        private System.Windows.Forms.Button EndTestButton;
        private System.Windows.Forms.Button NextWordButton;
        private System.Windows.Forms.Label EnWordLabel;
        private System.Windows.Forms.Label LtWordLabel;
        private System.Windows.Forms.Button ChangeLanguageButton;
        private System.Windows.Forms.Label EnHeaderLabel;
        private System.Windows.Forms.Label LtHeaderLabel;
    }
}