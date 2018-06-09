namespace SilverLinguo.Forms.Helper
{
    partial class BetterMessageBox
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
            this.WarningQuestionLabel = new System.Windows.Forms.Label();
            this.WarningIconPictureBox = new System.Windows.Forms.PictureBox();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WarningIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WarningQuestionLabel
            // 
            this.WarningQuestionLabel.AutoSize = true;
            this.WarningQuestionLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.WarningQuestionLabel.Location = new System.Drawing.Point(81, 32);
            this.WarningQuestionLabel.Name = "WarningQuestionLabel";
            this.WarningQuestionLabel.Size = new System.Drawing.Size(136, 19);
            this.WarningQuestionLabel.TabIndex = 0;
            this.WarningQuestionLabel.Text = "Ar tikrai norite tęsti ?";
            // 
            // WarningIconPictureBox
            // 
            this.WarningIconPictureBox.BackgroundImage = global::SilverLinguo.Properties.Resources.Warning_Icon;
            this.WarningIconPictureBox.Location = new System.Drawing.Point(12, 12);
            this.WarningIconPictureBox.Name = "WarningIconPictureBox";
            this.WarningIconPictureBox.Size = new System.Drawing.Size(63, 60);
            this.WarningIconPictureBox.TabIndex = 1;
            this.WarningIconPictureBox.TabStop = false;
            // 
            // YesButton
            // 
            this.YesButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.YesButton.Location = new System.Drawing.Point(85, 95);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(78, 32);
            this.YesButton.TabIndex = 2;
            this.YesButton.Text = "Taip";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.NoButton.Location = new System.Drawing.Point(240, 95);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(78, 32);
            this.NoButton.TabIndex = 3;
            this.NoButton.Text = "Ne";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // BetterMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 140);
            this.ControlBox = false;
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.WarningIconPictureBox);
            this.Controls.Add(this.WarningQuestionLabel);
            this.Name = "BetterMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation form";
            this.Load += new System.EventHandler(this.BetterMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WarningIconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WarningQuestionLabel;
        private System.Windows.Forms.PictureBox WarningIconPictureBox;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
    }
}