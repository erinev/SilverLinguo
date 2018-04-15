namespace Words.Test.Forms
{
    partial class BaseTestResultsForm
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
            this.WordsTypeLabel = new System.Windows.Forms.Label();
            this.WordsTypeHeaderLabel = new System.Windows.Forms.Label();
            this.EndProgramButton = new System.Windows.Forms.Button();
            this.StartDifferentTestButton = new System.Windows.Forms.Button();
            this.SelectedTestTypeLabel = new System.Windows.Forms.Label();
            this.SelectedTestTypeHeaderLabel = new System.Windows.Forms.Label();
            this.SelectedLanguageLabel = new System.Windows.Forms.Label();
            this.SelectedLanguageHeaderLabel = new System.Windows.Forms.Label();
            this.ElapsedTimeLabel = new System.Windows.Forms.Label();
            this.ElapsedTimeHeaderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WordsTypeLabel
            // 
            this.WordsTypeLabel.AutoSize = true;
            this.WordsTypeLabel.Location = new System.Drawing.Point(344, 72);
            this.WordsTypeLabel.Name = "WordsTypeLabel";
            this.WordsTypeLabel.Size = new System.Drawing.Size(61, 16);
            this.WordsTypeLabel.TabIndex = 28;
            this.WordsTypeLabel.Text = "Nežinomi";
            // 
            // WordsTypeHeaderLabel
            // 
            this.WordsTypeHeaderLabel.AutoSize = true;
            this.WordsTypeHeaderLabel.Location = new System.Drawing.Point(268, 72);
            this.WordsTypeHeaderLabel.Name = "WordsTypeHeaderLabel";
            this.WordsTypeHeaderLabel.Size = new System.Drawing.Size(83, 16);
            this.WordsTypeHeaderLabel.TabIndex = 27;
            this.WordsTypeHeaderLabel.Text = "Žodžių tipas: ";
            // 
            // EndProgramButton
            // 
            this.EndProgramButton.BackColor = System.Drawing.Color.Red;
            this.EndProgramButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EndProgramButton.Location = new System.Drawing.Point(384, 169);
            this.EndProgramButton.Name = "EndProgramButton";
            this.EndProgramButton.Padding = new System.Windows.Forms.Padding(2);
            this.EndProgramButton.Size = new System.Drawing.Size(138, 32);
            this.EndProgramButton.TabIndex = 24;
            this.EndProgramButton.Text = "Uždaryti programą";
            this.EndProgramButton.UseVisualStyleBackColor = false;
            this.EndProgramButton.Click += new System.EventHandler(this.EndProgramButton_Click_1);
            // 
            // StartDifferentTestButton
            // 
            this.StartDifferentTestButton.BackColor = System.Drawing.Color.YellowGreen;
            this.StartDifferentTestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartDifferentTestButton.Location = new System.Drawing.Point(149, 169);
            this.StartDifferentTestButton.Name = "StartDifferentTestButton";
            this.StartDifferentTestButton.Padding = new System.Windows.Forms.Padding(2);
            this.StartDifferentTestButton.Size = new System.Drawing.Size(138, 32);
            this.StartDifferentTestButton.TabIndex = 23;
            this.StartDifferentTestButton.Text = "Pasirinkti kitą testą";
            this.StartDifferentTestButton.UseVisualStyleBackColor = false;
            this.StartDifferentTestButton.Click += new System.EventHandler(this.StartDifferentTestButton_Click_1);
            // 
            // SelectedTestTypeLabel
            // 
            this.SelectedTestTypeLabel.AutoSize = true;
            this.SelectedTestTypeLabel.Location = new System.Drawing.Point(91, 72);
            this.SelectedTestTypeLabel.Name = "SelectedTestTypeLabel";
            this.SelectedTestTypeLabel.Size = new System.Drawing.Size(39, 16);
            this.SelectedTestTypeLabel.TabIndex = 20;
            this.SelectedTestTypeLabel.Text = "Raštu";
            // 
            // SelectedTestTypeHeaderLabel
            // 
            this.SelectedTestTypeHeaderLabel.AutoSize = true;
            this.SelectedTestTypeHeaderLabel.Location = new System.Drawing.Point(22, 72);
            this.SelectedTestTypeHeaderLabel.Name = "SelectedTestTypeHeaderLabel";
            this.SelectedTestTypeHeaderLabel.Size = new System.Drawing.Size(76, 16);
            this.SelectedTestTypeHeaderLabel.TabIndex = 19;
            this.SelectedTestTypeHeaderLabel.Text = "Testo tipas: ";
            // 
            // SelectedLanguageLabel
            // 
            this.SelectedLanguageLabel.AutoSize = true;
            this.SelectedLanguageLabel.Location = new System.Drawing.Point(116, 42);
            this.SelectedLanguageLabel.Name = "SelectedLanguageLabel";
            this.SelectedLanguageLabel.Size = new System.Drawing.Size(53, 16);
            this.SelectedLanguageLabel.TabIndex = 18;
            this.SelectedLanguageLabel.Text = "Lietuvių";
            // 
            // SelectedLanguageHeaderLabel
            // 
            this.SelectedLanguageHeaderLabel.AutoSize = true;
            this.SelectedLanguageHeaderLabel.Location = new System.Drawing.Point(22, 42);
            this.SelectedLanguageHeaderLabel.Name = "SelectedLanguageHeaderLabel";
            this.SelectedLanguageHeaderLabel.Size = new System.Drawing.Size(100, 16);
            this.SelectedLanguageHeaderLabel.TabIndex = 17;
            this.SelectedLanguageHeaderLabel.Text = "Pasrinkta kalba: ";
            // 
            // ElapsedTimeLabel
            // 
            this.ElapsedTimeLabel.AutoSize = true;
            this.ElapsedTimeLabel.Location = new System.Drawing.Point(351, 42);
            this.ElapsedTimeLabel.Name = "ElapsedTimeLabel";
            this.ElapsedTimeLabel.Size = new System.Drawing.Size(75, 16);
            this.ElapsedTimeLabel.TabIndex = 16;
            this.ElapsedTimeLabel.Text = "0h 12m 15s";
            // 
            // ElapsedTimeHeaderLabel
            // 
            this.ElapsedTimeHeaderLabel.AutoSize = true;
            this.ElapsedTimeHeaderLabel.Location = new System.Drawing.Point(268, 42);
            this.ElapsedTimeHeaderLabel.Name = "ElapsedTimeHeaderLabel";
            this.ElapsedTimeHeaderLabel.Size = new System.Drawing.Size(86, 16);
            this.ElapsedTimeHeaderLabel.TabIndex = 15;
            this.ElapsedTimeHeaderLabel.Text = "Testo trukmė:";
            // 
            // BaseTestResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 243);
            this.ControlBox = false;
            this.Controls.Add(this.WordsTypeLabel);
            this.Controls.Add(this.WordsTypeHeaderLabel);
            this.Controls.Add(this.EndProgramButton);
            this.Controls.Add(this.StartDifferentTestButton);
            this.Controls.Add(this.SelectedTestTypeLabel);
            this.Controls.Add(this.SelectedTestTypeHeaderLabel);
            this.Controls.Add(this.SelectedLanguageLabel);
            this.Controls.Add(this.SelectedLanguageHeaderLabel);
            this.Controls.Add(this.ElapsedTimeLabel);
            this.Controls.Add(this.ElapsedTimeHeaderLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaseTestResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bazinė testo rezultatų forma:";
            this.Load += new System.EventHandler(this.BaseTestResultsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label WordsTypeLabel;
        private System.Windows.Forms.Label WordsTypeHeaderLabel;
        private System.Windows.Forms.Button EndProgramButton;
        private System.Windows.Forms.Button StartDifferentTestButton;
        private System.Windows.Forms.Label SelectedTestTypeLabel;
        private System.Windows.Forms.Label SelectedTestTypeHeaderLabel;
        private System.Windows.Forms.Label SelectedLanguageLabel;
        private System.Windows.Forms.Label SelectedLanguageHeaderLabel;
        private System.Windows.Forms.Label ElapsedTimeLabel;
        private System.Windows.Forms.Label ElapsedTimeHeaderLabel;
    }
}