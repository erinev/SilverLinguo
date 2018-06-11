using System.Drawing.Printing;
using System.Windows.Forms;

namespace SilverLinguo.Forms.AdminPanel
{
    partial class AdminPanelForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AdminPanelTabControl = new System.Windows.Forms.TabControl();
            this.AllWordsTabPage = new System.Windows.Forms.TabPage();
            this.ClearAllWordsSearchButton = new System.Windows.Forms.Button();
            this.SearchAllWordsButton = new System.Windows.Forms.Button();
            this.AllWordsSearchTextBox = new System.Windows.Forms.TextBox();
            this.SaveChangesButton = new System.Windows.Forms.Button();
            this.ReloadAllWordsGridViewButton = new System.Windows.Forms.Button();
            this.AllWordsDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstLanguageWordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirtyRowUuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondLanguageWordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wordPairForDataGridViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UnknownWordsTabPage = new System.Windows.Forms.TabPage();
            this.AdminTabPage = new System.Windows.Forms.TabPage();
            this.GoBackToStartupFormButton = new System.Windows.Forms.Button();
            this.AdminPanelTabControl.SuspendLayout();
            this.AllWordsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllWordsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordPairForDataGridViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminPanelTabControl
            // 
            this.AdminPanelTabControl.Controls.Add(this.AllWordsTabPage);
            this.AdminPanelTabControl.Controls.Add(this.UnknownWordsTabPage);
            this.AdminPanelTabControl.Controls.Add(this.AdminTabPage);
            this.AdminPanelTabControl.Location = new System.Drawing.Point(2, 30);
            this.AdminPanelTabControl.Name = "AdminPanelTabControl";
            this.AdminPanelTabControl.SelectedIndex = 0;
            this.AdminPanelTabControl.Size = new System.Drawing.Size(927, 484);
            this.AdminPanelTabControl.TabIndex = 0;
            this.AdminPanelTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.AdminPanelTabControl_Selected);
            // 
            // AllWordsTabPage
            // 
            this.AllWordsTabPage.Controls.Add(this.ClearAllWordsSearchButton);
            this.AllWordsTabPage.Controls.Add(this.SearchAllWordsButton);
            this.AllWordsTabPage.Controls.Add(this.AllWordsSearchTextBox);
            this.AllWordsTabPage.Controls.Add(this.SaveChangesButton);
            this.AllWordsTabPage.Controls.Add(this.ReloadAllWordsGridViewButton);
            this.AllWordsTabPage.Controls.Add(this.AllWordsDataGridView);
            this.AllWordsTabPage.Location = new System.Drawing.Point(4, 24);
            this.AllWordsTabPage.Name = "AllWordsTabPage";
            this.AllWordsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AllWordsTabPage.Size = new System.Drawing.Size(919, 456);
            this.AllWordsTabPage.TabIndex = 0;
            this.AllWordsTabPage.Tag = "1";
            this.AllWordsTabPage.Text = "Visi žodžiai";
            this.AllWordsTabPage.UseVisualStyleBackColor = true;
            // 
            // ClearAllWordsSearchButton
            // 
            this.ClearAllWordsSearchButton.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClearAllWordsSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearAllWordsSearchButton.Location = new System.Drawing.Point(6, 7);
            this.ClearAllWordsSearchButton.Name = "ClearAllWordsSearchButton";
            this.ClearAllWordsSearchButton.Padding = new System.Windows.Forms.Padding(2);
            this.ClearAllWordsSearchButton.Size = new System.Drawing.Size(105, 32);
            this.ClearAllWordsSearchButton.TabIndex = 20;
            this.ClearAllWordsSearchButton.Text = "Išvalyti paieška";
            this.ClearAllWordsSearchButton.UseVisualStyleBackColor = false;
            this.ClearAllWordsSearchButton.Visible = false;
            this.ClearAllWordsSearchButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClearAllWordsSearchButton_Click);
            // 
            // SearchAllWordsButton
            // 
            this.SearchAllWordsButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SearchAllWordsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchAllWordsButton.Location = new System.Drawing.Point(436, 7);
            this.SearchAllWordsButton.Name = "SearchAllWordsButton";
            this.SearchAllWordsButton.Padding = new System.Windows.Forms.Padding(2);
            this.SearchAllWordsButton.Size = new System.Drawing.Size(77, 32);
            this.SearchAllWordsButton.TabIndex = 19;
            this.SearchAllWordsButton.Text = "Ieškoti";
            this.SearchAllWordsButton.UseVisualStyleBackColor = false;
            this.SearchAllWordsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchAllWordsButton_Click);
            // 
            // AllWordsSearchTextBox
            // 
            this.AllWordsSearchTextBox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.AllWordsSearchTextBox.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.AllWordsSearchTextBox.Location = new System.Drawing.Point(120, 9);
            this.AllWordsSearchTextBox.Name = "AllWordsSearchTextBox";
            this.AllWordsSearchTextBox.Size = new System.Drawing.Size(308, 29);
            this.AllWordsSearchTextBox.TabIndex = 18;
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.BackColor = System.Drawing.Color.YellowGreen;
            this.SaveChangesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveChangesButton.Enabled = false;
            this.SaveChangesButton.Location = new System.Drawing.Point(707, 9);
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Padding = new System.Windows.Forms.Padding(2);
            this.SaveChangesButton.Size = new System.Drawing.Size(100, 32);
            this.SaveChangesButton.TabIndex = 17;
            this.SaveChangesButton.Text = "Išsaugoti";
            this.SaveChangesButton.UseVisualStyleBackColor = false;
            this.SaveChangesButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SaveChangesButton_Click);
            // 
            // ReloadAllWordsGridViewButton
            // 
            this.ReloadAllWordsGridViewButton.BackColor = System.Drawing.Color.Orange;
            this.ReloadAllWordsGridViewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReloadAllWordsGridViewButton.Enabled = false;
            this.ReloadAllWordsGridViewButton.Location = new System.Drawing.Point(813, 9);
            this.ReloadAllWordsGridViewButton.Name = "ReloadAllWordsGridViewButton";
            this.ReloadAllWordsGridViewButton.Padding = new System.Windows.Forms.Padding(2);
            this.ReloadAllWordsGridViewButton.Size = new System.Drawing.Size(100, 32);
            this.ReloadAllWordsGridViewButton.TabIndex = 16;
            this.ReloadAllWordsGridViewButton.Text = "Atstatyti";
            this.ReloadAllWordsGridViewButton.UseVisualStyleBackColor = false;
            this.ReloadAllWordsGridViewButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ReloadAllWordsGridViewButton_Click);
            // 
            // AllWordsDataGridView
            // 
            this.AllWordsDataGridView.AllowUserToResizeColumns = false;
            this.AllWordsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            this.AllWordsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.AllWordsDataGridView.AutoGenerateColumns = false;
            this.AllWordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AllWordsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.firstLanguageWordDataGridViewTextBoxColumn,
            this.DirtyRowUuid,
            this.secondLanguageWordDataGridViewTextBoxColumn});
            this.AllWordsDataGridView.DataSource = this.wordPairForDataGridViewBindingSource;
            this.AllWordsDataGridView.Location = new System.Drawing.Point(7, 47);
            this.AllWordsDataGridView.MultiSelect = false;
            this.AllWordsDataGridView.Name = "AllWordsDataGridView";
            this.AllWordsDataGridView.Size = new System.Drawing.Size(694, 403);
            this.AllWordsDataGridView.TabIndex = 0;
            this.AllWordsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllWordsDataGridView_CellEndEdit);
            this.AllWordsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.AllWordsDataGridView_CellValidating);
            this.AllWordsDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.AllWordsDataGridView_RowValidating);
            this.AllWordsDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.AllWordsDataGridView_UserDeletingRow);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // firstLanguageWordDataGridViewTextBoxColumn
            // 
            this.firstLanguageWordDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.firstLanguageWordDataGridViewTextBoxColumn.DataPropertyName = "FirstLanguageWord";
            this.firstLanguageWordDataGridViewTextBoxColumn.HeaderText = "Lietuviškas žodis";
            this.firstLanguageWordDataGridViewTextBoxColumn.MinimumWidth = 317;
            this.firstLanguageWordDataGridViewTextBoxColumn.Name = "firstLanguageWordDataGridViewTextBoxColumn";
            this.firstLanguageWordDataGridViewTextBoxColumn.Width = 317;
            // 
            // DirtyRowUuid
            // 
            this.DirtyRowUuid.DataPropertyName = "DirtyRowUuid";
            this.DirtyRowUuid.HeaderText = "DirtyRowUuid";
            this.DirtyRowUuid.Name = "DirtyRowUuid";
            this.DirtyRowUuid.Visible = false;
            // 
            // secondLanguageWordDataGridViewTextBoxColumn
            // 
            this.secondLanguageWordDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.secondLanguageWordDataGridViewTextBoxColumn.DataPropertyName = "SecondLanguageWord";
            this.secondLanguageWordDataGridViewTextBoxColumn.HeaderText = "Angliškas žodis";
            this.secondLanguageWordDataGridViewTextBoxColumn.MinimumWidth = 317;
            this.secondLanguageWordDataGridViewTextBoxColumn.Name = "secondLanguageWordDataGridViewTextBoxColumn";
            this.secondLanguageWordDataGridViewTextBoxColumn.Width = 317;
            // 
            // wordPairForDataGridViewBindingSource
            // 
            this.wordPairForDataGridViewBindingSource.DataSource = typeof(SilverLinguo.Dto.WordPairForDataGridView);
            // 
            // UnknownWordsTabPage
            // 
            this.UnknownWordsTabPage.Location = new System.Drawing.Point(4, 24);
            this.UnknownWordsTabPage.Name = "UnknownWordsTabPage";
            this.UnknownWordsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.UnknownWordsTabPage.Size = new System.Drawing.Size(919, 456);
            this.UnknownWordsTabPage.TabIndex = 1;
            this.UnknownWordsTabPage.Tag = "2";
            this.UnknownWordsTabPage.Text = "Nežinomi žodžiai";
            this.UnknownWordsTabPage.UseVisualStyleBackColor = true;
            // 
            // AdminTabPage
            // 
            this.AdminTabPage.AllowDrop = true;
            this.AdminTabPage.Location = new System.Drawing.Point(4, 24);
            this.AdminTabPage.Name = "AdminTabPage";
            this.AdminTabPage.Size = new System.Drawing.Size(919, 456);
            this.AdminTabPage.TabIndex = 2;
            this.AdminTabPage.Tag = "3";
            this.AdminTabPage.Text = "Administravimas";
            this.AdminTabPage.UseVisualStyleBackColor = true;
            // 
            // GoBackToStartupFormButton
            // 
            this.GoBackToStartupFormButton.BackColor = System.Drawing.Color.Yellow;
            this.GoBackToStartupFormButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoBackToStartupFormButton.Location = new System.Drawing.Point(819, 10);
            this.GoBackToStartupFormButton.Name = "GoBackToStartupFormButton";
            this.GoBackToStartupFormButton.Padding = new System.Windows.Forms.Padding(2);
            this.GoBackToStartupFormButton.Size = new System.Drawing.Size(100, 32);
            this.GoBackToStartupFormButton.TabIndex = 15;
            this.GoBackToStartupFormButton.Text = "Grįžti atgal";
            this.GoBackToStartupFormButton.UseVisualStyleBackColor = false;
            this.GoBackToStartupFormButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GoBackToStartupFormButton_Click);
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 519);
            this.ControlBox = false;
            this.Controls.Add(this.GoBackToStartupFormButton);
            this.Controls.Add(this.AdminPanelTabControl);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SilverLinguo™ - Redaktorius";
            this.Load += new System.EventHandler(this.AdminPanelForm_Load);
            this.Shown += new System.EventHandler(this.AdminPanelForm_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AdminPanelForm_KeyUp);
            this.AdminPanelTabControl.ResumeLayout(false);
            this.AllWordsTabPage.ResumeLayout(false);
            this.AllWordsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllWordsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordPairForDataGridViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl AdminPanelTabControl;
        private System.Windows.Forms.TabPage AllWordsTabPage;
        private System.Windows.Forms.TabPage UnknownWordsTabPage;
        private System.Windows.Forms.TabPage AdminTabPage;
        private System.Windows.Forms.Button GoBackToStartupFormButton;
        private System.Windows.Forms.DataGridView AllWordsDataGridView;
        private System.Windows.Forms.BindingSource wordPairForDataGridViewBindingSource;
        private System.Windows.Forms.Button SaveChangesButton;
        private System.Windows.Forms.Button ReloadAllWordsGridViewButton;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn firstLanguageWordDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn DirtyRowUuid;
        private DataGridViewTextBoxColumn secondLanguageWordDataGridViewTextBoxColumn;
        private Button SearchAllWordsButton;
        private TextBox AllWordsSearchTextBox;
        private Button ClearAllWordsSearchButton;
    }
}