using System;
using System.Windows.Forms;

namespace Words.Test.Forms.Helper
{
    partial class AllWordsVerbalTestPasswordForm
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
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.ValidatePasswordButton = new System.Windows.Forms.Button();
            this.IncorrectPasswordLabel = new System.Windows.Forms.Label();
            this.BackToTestSelectionButton = new System.Windows.Forms.Button();
            this.EnterPasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(73, 59);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(282, 23);
            this.PasswordTextBox.TabIndex = 0;
            this.PasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTextBox_KeyPress);
            this.PasswordTextBox.TextChanged += new EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // ValidatePasswordButton
            // 
            this.ValidatePasswordButton.BackColor = System.Drawing.Color.YellowGreen;
            this.ValidatePasswordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ValidatePasswordButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ValidatePasswordButton.Location = new System.Drawing.Point(73, 128);
            this.ValidatePasswordButton.Name = "ValidatePasswordButton";
            this.ValidatePasswordButton.Padding = new System.Windows.Forms.Padding(2);
            this.ValidatePasswordButton.Size = new System.Drawing.Size(107, 39);
            this.ValidatePasswordButton.TabIndex = 55;
            this.ValidatePasswordButton.Text = "Pereiti į testą";
            this.ValidatePasswordButton.UseVisualStyleBackColor = false;
            this.ValidatePasswordButton.Click += new System.EventHandler(this.ValidatePasswordButton_Click);
            // 
            // IncorrectPasswordLabel
            // 
            this.IncorrectPasswordLabel.AutoSize = true;
            this.IncorrectPasswordLabel.BackColor = System.Drawing.SystemColors.Control;
            this.IncorrectPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.IncorrectPasswordLabel.Location = new System.Drawing.Point(74, 89);
            this.IncorrectPasswordLabel.Name = "IncorrectPasswordLabel";
            this.IncorrectPasswordLabel.Size = new System.Drawing.Size(149, 16);
            this.IncorrectPasswordLabel.TabIndex = 56;
            this.IncorrectPasswordLabel.Text = "* neteisingas slaptažodis.";
            this.IncorrectPasswordLabel.Visible = false;
            // 
            // BackToTestSelectionButton
            // 
            this.BackToTestSelectionButton.BackColor = System.Drawing.Color.Yellow;
            this.BackToTestSelectionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackToTestSelectionButton.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.BackToTestSelectionButton.Location = new System.Drawing.Point(207, 128);
            this.BackToTestSelectionButton.Name = "BackToTestSelectionButton";
            this.BackToTestSelectionButton.Padding = new System.Windows.Forms.Padding(2);
            this.BackToTestSelectionButton.Size = new System.Drawing.Size(148, 39);
            this.BackToTestSelectionButton.TabIndex = 57;
            this.BackToTestSelectionButton.Text = "Gryžti į pasirinkimą";
            this.BackToTestSelectionButton.UseVisualStyleBackColor = false;
            this.BackToTestSelectionButton.Click += new System.EventHandler(this.BackToTestSelectionButton_Click);
            // 
            // EnterPasswordLabel
            // 
            this.EnterPasswordLabel.AutoSize = true;
            this.EnterPasswordLabel.Location = new System.Drawing.Point(70, 40);
            this.EnterPasswordLabel.Name = "EnterPasswordLabel";
            this.EnterPasswordLabel.Size = new System.Drawing.Size(114, 16);
            this.EnterPasswordLabel.TabIndex = 58;
            this.EnterPasswordLabel.Text = "Įveskite slaptažodį:";
            // 
            // AllWordsVerbalTestPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 202);
            this.ControlBox = false;
            this.Controls.Add(this.EnterPasswordLabel);
            this.Controls.Add(this.BackToTestSelectionButton);
            this.Controls.Add(this.IncorrectPasswordLabel);
            this.Controls.Add(this.ValidatePasswordButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AllWordsVerbalTestPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visų žodžių testo (žodžiu) slaptažodis";
            this.Load += new System.EventHandler(this.AllWordsVerbalTestPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button ValidatePasswordButton;
        private System.Windows.Forms.Label IncorrectPasswordLabel;
        private System.Windows.Forms.Button BackToTestSelectionButton;
        private Label EnterPasswordLabel;
    }
}