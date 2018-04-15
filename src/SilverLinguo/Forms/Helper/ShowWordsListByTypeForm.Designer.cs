namespace SilverLinguo.Forms.Helper
{
    partial class ShowWordsListByTypeForm
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
            this.WordsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // WordsListBox
            // 
            this.WordsListBox.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.WordsListBox.FormattingEnabled = true;
            this.WordsListBox.ItemHeight = 21;
            this.WordsListBox.Location = new System.Drawing.Point(12, 12);
            this.WordsListBox.Name = "WordsListBox";
            this.WordsListBox.ScrollAlwaysVisible = true;
            this.WordsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.WordsListBox.Size = new System.Drawing.Size(945, 256);
            this.WordsListBox.TabIndex = 0;
            // 
            // ShowWordsListByTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 302);
            this.Controls.Add(this.WordsListBox);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowWordsListByTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Išmokti žodžiai:";
            this.Load += new System.EventHandler(this.ShowWordsListByTypeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox WordsListBox;
    }
}