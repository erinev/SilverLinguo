namespace Silverio.Žodynas
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
            this.LtWordTextBox = new System.Windows.Forms.TextBox();
            this.EnWordTextBox = new System.Windows.Forms.TextBox();
            this.LearnedWordsCountLabel = new System.Windows.Forms.Label();
            this.LearnedWordsCountHeaderLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.ProgressHeaderLabel = new System.Windows.Forms.Label();
            this.EndTestButton = new System.Windows.Forms.Button();
            this.EnHeaderLabel = new System.Windows.Forms.Label();
            this.LtHeaderLabel = new System.Windows.Forms.Label();
            this.ShowLearnedWordsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LtWordTextBox
            // 
            this.LtWordTextBox.AcceptsReturn = true;
            this.LtWordTextBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LtWordTextBox.Location = new System.Drawing.Point(22, 45);
            this.LtWordTextBox.Multiline = true;
            this.LtWordTextBox.Name = "LtWordTextBox";
            this.LtWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LtWordTextBox.Size = new System.Drawing.Size(356, 69);
            this.LtWordTextBox.TabIndex = 38;
            // 
            // EnWordTextBox
            // 
            this.EnWordTextBox.AcceptsReturn = true;
            this.EnWordTextBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EnWordTextBox.Location = new System.Drawing.Point(407, 45);
            this.EnWordTextBox.Multiline = true;
            this.EnWordTextBox.Name = "EnWordTextBox";
            this.EnWordTextBox.ReadOnly = true;
            this.EnWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EnWordTextBox.Size = new System.Drawing.Size(356, 69);
            this.EnWordTextBox.TabIndex = 37;
            // 
            // LearnedWordsCountLabel
            // 
            this.LearnedWordsCountLabel.AutoSize = true;
            this.LearnedWordsCountLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LearnedWordsCountLabel.Location = new System.Drawing.Point(812, 113);
            this.LearnedWordsCountLabel.Name = "LearnedWordsCountLabel";
            this.LearnedWordsCountLabel.Size = new System.Drawing.Size(15, 17);
            this.LearnedWordsCountLabel.TabIndex = 34;
            this.LearnedWordsCountLabel.Text = "0";
            // 
            // LearnedWordsCountHeaderLabel
            // 
            this.LearnedWordsCountHeaderLabel.AutoSize = true;
            this.LearnedWordsCountHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LearnedWordsCountHeaderLabel.Location = new System.Drawing.Point(812, 95);
            this.LearnedWordsCountHeaderLabel.Name = "LearnedWordsCountHeaderLabel";
            this.LearnedWordsCountHeaderLabel.Size = new System.Drawing.Size(99, 16);
            this.LearnedWordsCountHeaderLabel.TabIndex = 33;
            this.LearnedWordsCountHeaderLabel.Text = "Išmokti žodžiai: ";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressLabel.Location = new System.Drawing.Point(812, 38);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(15, 17);
            this.ProgressLabel.TabIndex = 32;
            this.ProgressLabel.Text = "5";
            // 
            // ProgressHeaderLabel
            // 
            this.ProgressHeaderLabel.AutoSize = true;
            this.ProgressHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ProgressHeaderLabel.Location = new System.Drawing.Point(812, 22);
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
            this.EndTestButton.Location = new System.Drawing.Point(386, 225);
            this.EndTestButton.Name = "EndTestButton";
            this.EndTestButton.Padding = new System.Windows.Forms.Padding(4);
            this.EndTestButton.Size = new System.Drawing.Size(145, 44);
            this.EndTestButton.TabIndex = 30;
            this.EndTestButton.Text = "Baigtį testą";
            this.EndTestButton.UseVisualStyleBackColor = false;
            this.EndTestButton.Click += new System.EventHandler(this.EndTestButton_Click);
            // 
            // EnHeaderLabel
            // 
            this.EnHeaderLabel.AutoSize = true;
            this.EnHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EnHeaderLabel.Location = new System.Drawing.Point(404, 22);
            this.EnHeaderLabel.Name = "EnHeaderLabel";
            this.EnHeaderLabel.Size = new System.Drawing.Size(97, 16);
            this.EnHeaderLabel.TabIndex = 29;
            this.EnHeaderLabel.Text = "Angliškas žodis:";
            // 
            // LtHeaderLabel
            // 
            this.LtHeaderLabel.AutoSize = true;
            this.LtHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LtHeaderLabel.Location = new System.Drawing.Point(19, 22);
            this.LtHeaderLabel.Name = "LtHeaderLabel";
            this.LtHeaderLabel.Size = new System.Drawing.Size(106, 16);
            this.LtHeaderLabel.TabIndex = 28;
            this.LtHeaderLabel.Text = "Lietuviškas žodis:";
            // 
            // ShowLearnedWordsButton
            // 
            this.ShowLearnedWordsButton.Location = new System.Drawing.Point(815, 134);
            this.ShowLearnedWordsButton.Name = "ShowLearnedWordsButton";
            this.ShowLearnedWordsButton.Size = new System.Drawing.Size(75, 23);
            this.ShowLearnedWordsButton.TabIndex = 39;
            this.ShowLearnedWordsButton.Text = "Rodyti";
            this.ShowLearnedWordsButton.UseVisualStyleBackColor = true;
            this.ShowLearnedWordsButton.Click += new System.EventHandler(this.ShowLearnedWordsButton_Click);
            // 
            // UnknownWordsGrammarTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 291);
            this.ControlBox = false;
            this.Controls.Add(this.ShowLearnedWordsButton);
            this.Controls.Add(this.LtWordTextBox);
            this.Controls.Add(this.EnWordTextBox);
            this.Controls.Add(this.LearnedWordsCountLabel);
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
            this.Text = "Nežinomų žodžių testas (raštu):";
            this.Load += new System.EventHandler(this.UnknownWordsGrammarTestForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UnknownWordsGrammarTestForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LtWordTextBox;
        private System.Windows.Forms.TextBox EnWordTextBox;
        private System.Windows.Forms.Label LearnedWordsCountLabel;
        private System.Windows.Forms.Label LearnedWordsCountHeaderLabel;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label ProgressHeaderLabel;
        private System.Windows.Forms.Button EndTestButton;
        private System.Windows.Forms.Label EnHeaderLabel;
        private System.Windows.Forms.Label LtHeaderLabel;
        private System.Windows.Forms.Button ShowLearnedWordsButton;
    }
}