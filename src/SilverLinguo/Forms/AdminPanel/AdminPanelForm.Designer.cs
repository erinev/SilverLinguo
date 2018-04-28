﻿using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AdminPanelTabControl = new System.Windows.Forms.TabControl();
            this.AllWordsTabPage = new System.Windows.Forms.TabPage();
            this.SaveChangesButton = new System.Windows.Forms.Button();
            this.ReloadAllWordsGridViewButton = new System.Windows.Forms.Button();
            this.AllWordsDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirtyRowUuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnknownWordsTabPage = new System.Windows.Forms.TabPage();
            this.AdminTabPage = new System.Windows.Forms.TabPage();
            this.GoBackToStartupFormButton = new System.Windows.Forms.Button();
            this.firstLanguageWordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondLanguageWordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wordPairForDataGridViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            // 
            // AllWordsTabPage
            // 
            this.AllWordsTabPage.Controls.Add(this.SaveChangesButton);
            this.AllWordsTabPage.Controls.Add(this.ReloadAllWordsGridViewButton);
            this.AllWordsTabPage.Controls.Add(this.AllWordsDataGridView);
            this.AllWordsTabPage.Location = new System.Drawing.Point(4, 24);
            this.AllWordsTabPage.Name = "AllWordsTabPage";
            this.AllWordsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AllWordsTabPage.Size = new System.Drawing.Size(919, 456);
            this.AllWordsTabPage.TabIndex = 0;
            this.AllWordsTabPage.Text = "Visi žodžiai";
            this.AllWordsTabPage.UseVisualStyleBackColor = true;
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.BackColor = System.Drawing.Color.YellowGreen;
            this.SaveChangesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveChangesButton.Location = new System.Drawing.Point(813, 19);
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Padding = new System.Windows.Forms.Padding(2);
            this.SaveChangesButton.Size = new System.Drawing.Size(100, 32);
            this.SaveChangesButton.TabIndex = 17;
            this.SaveChangesButton.Text = "Išsaugoti";
            this.SaveChangesButton.UseVisualStyleBackColor = false;
            this.SaveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // ReloadAllWordsGridViewButton
            // 
            this.ReloadAllWordsGridViewButton.BackColor = System.Drawing.Color.Orange;
            this.ReloadAllWordsGridViewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReloadAllWordsGridViewButton.Location = new System.Drawing.Point(707, 19);
            this.ReloadAllWordsGridViewButton.Name = "ReloadAllWordsGridViewButton";
            this.ReloadAllWordsGridViewButton.Padding = new System.Windows.Forms.Padding(2);
            this.ReloadAllWordsGridViewButton.Size = new System.Drawing.Size(100, 32);
            this.ReloadAllWordsGridViewButton.TabIndex = 16;
            this.ReloadAllWordsGridViewButton.Text = "Atstatyti";
            this.ReloadAllWordsGridViewButton.UseVisualStyleBackColor = false;
            this.ReloadAllWordsGridViewButton.Click += new System.EventHandler(this.ReloadAllWordsGridViewButton_Click);
            // 
            // AllWordsDataGridView
            // 
            this.AllWordsDataGridView.AllowUserToResizeColumns = false;
            this.AllWordsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon;
            this.AllWordsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.AllWordsDataGridView.AutoGenerateColumns = false;
            this.AllWordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AllWordsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.firstLanguageWordDataGridViewTextBoxColumn,
            this.DirtyRowUuid,
            this.secondLanguageWordDataGridViewTextBoxColumn});
            this.AllWordsDataGridView.DataSource = this.wordPairForDataGridViewBindingSource;
            this.AllWordsDataGridView.Location = new System.Drawing.Point(7, 7);
            this.AllWordsDataGridView.MultiSelect = false;
            this.AllWordsDataGridView.Name = "AllWordsDataGridView";
            this.AllWordsDataGridView.Size = new System.Drawing.Size(694, 443);
            this.AllWordsDataGridView.TabIndex = 0;
            this.AllWordsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllWordsDataGridView_CellEndEdit);
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
            // DirtyRowUuid
            // 
            this.DirtyRowUuid.DataPropertyName = "DirtyRowUuid";
            this.DirtyRowUuid.HeaderText = "DirtyRowUuid";
            this.DirtyRowUuid.Name = "DirtyRowUuid";
            this.DirtyRowUuid.Visible = false;
            // 
            // UnknownWordsTabPage
            // 
            this.UnknownWordsTabPage.Location = new System.Drawing.Point(4, 24);
            this.UnknownWordsTabPage.Name = "UnknownWordsTabPage";
            this.UnknownWordsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.UnknownWordsTabPage.Size = new System.Drawing.Size(919, 456);
            this.UnknownWordsTabPage.TabIndex = 1;
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
            this.AdminTabPage.Text = "Administravimas";
            this.AdminTabPage.UseVisualStyleBackColor = true;
            // 
            // GoBackToStartupFormButton
            // 
            this.GoBackToStartupFormButton.BackColor = System.Drawing.Color.Yellow;
            this.GoBackToStartupFormButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoBackToStartupFormButton.Location = new System.Drawing.Point(819, 12);
            this.GoBackToStartupFormButton.Name = "GoBackToStartupFormButton";
            this.GoBackToStartupFormButton.Padding = new System.Windows.Forms.Padding(2);
            this.GoBackToStartupFormButton.Size = new System.Drawing.Size(100, 32);
            this.GoBackToStartupFormButton.TabIndex = 15;
            this.GoBackToStartupFormButton.Text = "Grįžti atgal";
            this.GoBackToStartupFormButton.UseVisualStyleBackColor = false;
            this.GoBackToStartupFormButton.Click += new System.EventHandler(this.GoBackToStartupFormButton_Click);
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
            this.AdminPanelTabControl.ResumeLayout(false);
            this.AllWordsTabPage.ResumeLayout(false);
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
    }
}