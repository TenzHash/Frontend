namespace Password_Inventory_App
{
    partial class NavigationalPanel
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
            this.passwordTab = new System.Windows.Forms.TabPage();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dataGridViewPasswords = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dashboardTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRecentEntries = new System.Windows.Forms.Label();
            this.lblTotalCategories = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalPasswords = new System.Windows.Forms.Label();
            this.passwordsTab = new System.Windows.Forms.TabControl();
            this.usersTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.searchBtn = new System.Windows.Forms.Button();
            this.txtUserSearch = new System.Windows.Forms.TextBox();
            this.passwordTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPasswords)).BeginInit();
            this.dashboardTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.passwordsTab.SuspendLayout();
            this.usersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordTab
            // 
            this.passwordTab.Controls.Add(this.btnExportToExcel);
            this.passwordTab.Controls.Add(this.button4);
            this.passwordTab.Controls.Add(this.btnDelete);
            this.passwordTab.Controls.Add(this.btnEdit);
            this.passwordTab.Controls.Add(this.dataGridViewPasswords);
            this.passwordTab.Controls.Add(this.btnSearch);
            this.passwordTab.Controls.Add(this.txtSearch);
            this.passwordTab.Location = new System.Drawing.Point(4, 25);
            this.passwordTab.Name = "passwordTab";
            this.passwordTab.Padding = new System.Windows.Forms.Padding(3);
            this.passwordTab.Size = new System.Drawing.Size(1198, 706);
            this.passwordTab.TabIndex = 2;
            this.passwordTab.Text = "Passwords";
            this.passwordTab.UseVisualStyleBackColor = true;
            this.passwordTab.Click += new System.EventHandler(this.passwordCn_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(775, 621);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(159, 71);
            this.btnExportToExcel.TabIndex = 57;
            this.btnExportToExcel.Text = "Export";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(238, 621);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 71);
            this.button4.TabIndex = 56;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(598, 621);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(159, 71);
            this.btnDelete.TabIndex = 55;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(419, 621);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(159, 71);
            this.btnEdit.TabIndex = 54;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.button7_Click);
            // 
            // dataGridViewPasswords
            // 
            this.dataGridViewPasswords.AllowUserToAddRows = false;
            this.dataGridViewPasswords.AllowUserToDeleteRows = false;
            this.dataGridViewPasswords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPasswords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridViewPasswords.ColumnHeadersHeight = 29;
            this.dataGridViewPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPasswords.Location = new System.Drawing.Point(75, 64);
            this.dataGridViewPasswords.Name = "dataGridViewPasswords";
            this.dataGridViewPasswords.ReadOnly = true;
            this.dataGridViewPasswords.RowHeadersWidth = 51;
            this.dataGridViewPasswords.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewPasswords.RowTemplate.Height = 24;
            this.dataGridViewPasswords.Size = new System.Drawing.Size(1035, 544);
            this.dataGridViewPasswords.TabIndex = 52;
            this.dataGridViewPasswords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1035, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 51;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(760, 33);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(271, 22);
            this.txtSearch.TabIndex = 50;
            this.txtSearch.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // dashboardTab
            // 
            this.dashboardTab.Controls.Add(this.label2);
            this.dashboardTab.Controls.Add(this.tableLayoutPanel1);
            this.dashboardTab.Location = new System.Drawing.Point(4, 25);
            this.dashboardTab.Name = "dashboardTab";
            this.dashboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.dashboardTab.Size = new System.Drawing.Size(1198, 706);
            this.dashboardTab.TabIndex = 0;
            this.dashboardTab.Text = "Dashboard";
            this.dashboardTab.UseVisualStyleBackColor = true;
            this.dashboardTab.Click += new System.EventHandler(this.dashboardTab_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Welcome to Password Inventory App!";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lblRecentEntries, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalCategories, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalPasswords, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(106, 248);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.08696F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.91304F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(986, 276);
            this.tableLayoutPanel1.TabIndex = 12;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // lblRecentEntries
            // 
            this.lblRecentEntries.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecentEntries.AutoSize = true;
            this.lblRecentEntries.Location = new System.Drawing.Point(779, 166);
            this.lblRecentEntries.Name = "lblRecentEntries";
            this.lblRecentEntries.Size = new System.Drawing.Size(83, 16);
            this.lblRecentEntries.TabIndex = 12;
            this.lblRecentEntries.Text = "Recent Entry";
            this.lblRecentEntries.UseMnemonic = false;
            this.lblRecentEntries.Click += new System.EventHandler(this.lblRecentEntries_Click);
            // 
            // lblTotalCategories
            // 
            this.lblTotalCategories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalCategories.AutoSize = true;
            this.lblTotalCategories.Location = new System.Drawing.Point(456, 166);
            this.lblTotalCategories.Name = "lblTotalCategories";
            this.lblTotalCategories.Size = new System.Drawing.Size(73, 16);
            this.lblTotalCategories.TabIndex = 11;
            this.lblTotalCategories.Text = "Categories";
            this.lblTotalCategories.UseMnemonic = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(779, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Recent Entry";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total Passwords Stored";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Categories";
            // 
            // lblTotalPasswords
            // 
            this.lblTotalPasswords.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalPasswords.AutoSize = true;
            this.lblTotalPasswords.Location = new System.Drawing.Point(127, 166);
            this.lblTotalPasswords.Name = "lblTotalPasswords";
            this.lblTotalPasswords.Size = new System.Drawing.Size(74, 16);
            this.lblTotalPasswords.TabIndex = 10;
            this.lblTotalPasswords.Text = "Passwords";
            this.lblTotalPasswords.UseMnemonic = false;
            // 
            // passwordsTab
            // 
            this.passwordsTab.Controls.Add(this.dashboardTab);
            this.passwordsTab.Controls.Add(this.passwordTab);
            this.passwordsTab.Controls.Add(this.usersTab);
            this.passwordsTab.Location = new System.Drawing.Point(4, 6);
            this.passwordsTab.Name = "passwordsTab";
            this.passwordsTab.SelectedIndex = 0;
            this.passwordsTab.Size = new System.Drawing.Size(1206, 735);
            this.passwordsTab.TabIndex = 0;
            // 
            // usersTab
            // 
            this.usersTab.Controls.Add(this.button1);
            this.usersTab.Controls.Add(this.btnAdd);
            this.usersTab.Controls.Add(this.btnDeleteUser);
            this.usersTab.Controls.Add(this.btnEditUser);
            this.usersTab.Controls.Add(this.dgvUsers);
            this.usersTab.Controls.Add(this.searchBtn);
            this.usersTab.Controls.Add(this.txtUserSearch);
            this.usersTab.Location = new System.Drawing.Point(4, 25);
            this.usersTab.Name = "usersTab";
            this.usersTab.Padding = new System.Windows.Forms.Padding(3);
            this.usersTab.Size = new System.Drawing.Size(1198, 706);
            this.usersTab.TabIndex = 3;
            this.usersTab.Text = "Users";
            this.usersTab.UseVisualStyleBackColor = true;
            this.usersTab.Click += new System.EventHandler(this.usersTab_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(782, 614);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 71);
            this.button1.TabIndex = 64;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_4);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(245, 614);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(159, 71);
            this.btnAdd.TabIndex = 63;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(605, 614);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(159, 71);
            this.btnDeleteUser.TabIndex = 62;
            this.btnDeleteUser.Text = "Delete";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click_1);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(426, 614);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(159, 71);
            this.btnEditUser.TabIndex = 61;
            this.btnEditUser.Text = "Edit";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click_1);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dgvUsers.ColumnHeadersHeight = 29;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.Location = new System.Drawing.Point(82, 57);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(1035, 544);
            this.dgvUsers.TabIndex = 60;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(1042, 22);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 29);
            this.searchBtn.TabIndex = 59;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // txtUserSearch
            // 
            this.txtUserSearch.Location = new System.Drawing.Point(767, 26);
            this.txtUserSearch.Name = "txtUserSearch";
            this.txtUserSearch.Size = new System.Drawing.Size(271, 22);
            this.txtUserSearch.TabIndex = 58;
            // 
            // NavigationalPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1222, 753);
            this.Controls.Add(this.passwordsTab);
            this.MaximumSize = new System.Drawing.Size(1240, 800);
            this.MinimumSize = new System.Drawing.Size(1240, 800);
            this.Name = "NavigationalPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Inventory";
            this.Load += new System.EventHandler(this.NavigationalPanel_Load);
            this.passwordTab.ResumeLayout(false);
            this.passwordTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPasswords)).EndInit();
            this.dashboardTab.ResumeLayout(false);
            this.dashboardTab.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.passwordsTab.ResumeLayout(false);
            this.usersTab.ResumeLayout(false);
            this.usersTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage passwordTab;
        private System.Windows.Forms.TabPage dashboardTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl passwordsTab;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TabPage usersTab;
        private System.Windows.Forms.Label lblTotalPasswords;
        private System.Windows.Forms.Label lblTotalCategories;
        private System.Windows.Forms.Label lblRecentEntries;
        private System.Windows.Forms.DataGridView dataGridViewPasswords;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox txtUserSearch;
    }
}