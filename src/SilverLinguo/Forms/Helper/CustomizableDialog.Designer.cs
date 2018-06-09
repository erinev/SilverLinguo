using System.Windows.Forms;

namespace SilverLinguo.Forms.Helper
{
    partial class CustomizableDialog
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
            this.WarningIconPictureBox = new System.Windows.Forms.PictureBox();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.DialogBodyReadonlyTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.WarningIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WarningIconPictureBox
            // 
            this.WarningIconPictureBox.BackgroundImage = global::SilverLinguo.Properties.Resources.Warning_Icon;
            this.WarningIconPictureBox.Location = new System.Drawing.Point(12, 13);
            this.WarningIconPictureBox.Name = "WarningIconPictureBox";
            this.WarningIconPictureBox.Size = new System.Drawing.Size(63, 63);
            this.WarningIconPictureBox.TabIndex = 1;
            this.WarningIconPictureBox.TabStop = false;
            // 
            // YesButton
            // 
            this.YesButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.YesButton.Location = new System.Drawing.Point(85, 102);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(88, 34);
            this.YesButton.TabIndex = 2;
            this.YesButton.Text = "Taip";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.YesButton_MouseClick);
            // 
            // NoButton
            // 
            this.NoButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.NoButton.Location = new System.Drawing.Point(209, 102);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(88, 34);
            this.NoButton.TabIndex = 3;
            this.NoButton.Text = "Ne";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NoButton_MouseClick);
            // 
            // DialogBodyReadonlyTextBox
            // 
            this.DialogBodyReadonlyTextBox.AcceptsReturn = true;
            this.DialogBodyReadonlyTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.DialogBodyReadonlyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DialogBodyReadonlyTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.DialogBodyReadonlyTextBox.Location = new System.Drawing.Point(85, 13);
            this.DialogBodyReadonlyTextBox.Multiline = true;
            this.DialogBodyReadonlyTextBox.Name = "DialogBodyReadonlyTextBox";
            this.DialogBodyReadonlyTextBox.ReadOnly = true;
            this.DialogBodyReadonlyTextBox.ShortcutsEnabled = false;
            this.DialogBodyReadonlyTextBox.Size = new System.Drawing.Size(300, 63);
            this.DialogBodyReadonlyTextBox.TabIndex = 55;
            this.DialogBodyReadonlyTextBox.Text = "Ar tikrai tikrai tikrai tikrai tikrai tikrai tikrai tikrai tikrai norite tęsti ?";
            // 
            // CustomizableDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 151);
            this.ControlBox = false;
            this.Controls.Add(this.DialogBodyReadonlyTextBox);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.WarningIconPictureBox);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Name = "CustomizableDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Žodžio trinimas";
            this.Load += new System.EventHandler(this.CustomizableDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WarningIconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox WarningIconPictureBox;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private TextBox DialogBodyReadonlyTextBox;
    }
}