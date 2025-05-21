namespace Password_Inventory_App
{
    partial class AddPasswordForm
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.category = new System.Windows.Forms.Label();
            this.cmbCategoryName = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.websiteInput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(19, 105);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(274, 22);
            this.txtUsername.TabIndex = 97;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 96;
            this.label6.Text = "Username";
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(167, 178);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkShowPassword.Size = new System.Drawing.Size(125, 20);
            this.chkShowPassword.TabIndex = 95;
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(225, 252);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(69, 36);
            this.cancelBtn.TabIndex = 94;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(19, 252);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(70, 36);
            this.saveBtn.TabIndex = 93;
            this.saveBtn.Text = "Add";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // category
            // 
            this.category.AutoSize = true;
            this.category.Location = new System.Drawing.Point(16, 181);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(73, 16);
            this.category.TabIndex = 90;
            this.category.Text = "Categories";
            // 
            // cmbCategoryName
            // 
            this.cmbCategoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryName.FormattingEnabled = true;
            this.cmbCategoryName.Location = new System.Drawing.Point(19, 200);
            this.cmbCategoryName.Name = "cmbCategoryName";
            this.cmbCategoryName.Size = new System.Drawing.Size(273, 24);
            this.cmbCategoryName.TabIndex = 89;
            this.cmbCategoryName.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryName_SelectedIndexChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(19, 150);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(273, 22);
            this.txtPassword.TabIndex = 88;
            // 
            // passwordInput
            // 
            this.passwordInput.AutoSize = true;
            this.passwordInput.Location = new System.Drawing.Point(16, 132);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(67, 16);
            this.passwordInput.TabIndex = 87;
            this.passwordInput.Text = "Password";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(19, 60);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(275, 22);
            this.txtWebsite.TabIndex = 86;
            this.txtWebsite.TextChanged += new System.EventHandler(this.txtWebsite_TextChanged);
            // 
            // websiteInput
            // 
            this.websiteInput.AutoSize = true;
            this.websiteInput.Location = new System.Drawing.Point(16, 42);
            this.websiteInput.Name = "websiteInput";
            this.websiteInput.Size = new System.Drawing.Size(57, 16);
            this.websiteInput.TabIndex = 85;
            this.websiteInput.Text = "Website";
            // 
            // AddPasswordForm
            // 
            this.ClientSize = new System.Drawing.Size(309, 324);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.category);
            this.Controls.Add(this.cmbCategoryName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.txtWebsite);
            this.Controls.Add(this.websiteInput);
            this.Name = "AddPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label category;
        private System.Windows.Forms.ComboBox cmbCategoryName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label passwordInput;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label websiteInput;
    }
}