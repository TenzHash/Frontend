using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Password_Inventory_App
{
    public partial class AddPasswordForm : Form
    {
        string connectionString = "server=localhost;user=root;password=;database=passwordinventorydb;";
        private int? entryId;

        public AddPasswordForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            LoadCategories();
        }

        public AddPasswordForm(int entryId, string siteName, string username, string passwordEncrypted, string categoryName)
            : this()
        {
            this.entryId = entryId;
            txtWebsite.Text = siteName;
            txtUsername.Text = username;
            txtPassword.Text = passwordEncrypted;
            // Ensure categories are loaded before selecting
            if (cmbCategoryName.Items.Contains(categoryName))
                cmbCategoryName.SelectedItem = categoryName;
            else
                cmbCategoryName.SelectedIndex = -1;
        }

        private void LoadCategories()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT category_name FROM categories";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbCategoryName.Items.Add(reader["category_name"].ToString());
                }
                reader.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private int GetCategoryIdFromName(string categoryName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT category_id FROM categories WHERE category_name = @categoryName";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryName", categoryName);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtWebsite_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string siteName = txtWebsite.Text.Trim();
            string username = txtUsername.Text.Trim();
            string passwordEncrypted = txtPassword.Text.Trim();
            string categoryName = cmbCategoryName.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(siteName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwordEncrypted) || string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int categoryId = GetCategoryIdFromName(categoryName);

            if (categoryId == -1)
            {
                MessageBox.Show("Category not found.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                if (entryId.HasValue)
                {
                    // Edit mode: update existing record
                    string query = @"
                        UPDATE passwords
                        SET site_name = @siteName,
                            username = @username,
                            password_encrypted = @passwordEncrypted,
                            category_id = @categoryId
                        WHERE entry_id = @entryId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@siteName", siteName);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@passwordEncrypted", passwordEncrypted);
                        cmd.Parameters.AddWithValue("@categoryId", categoryId);
                        cmd.Parameters.AddWithValue("@entryId", entryId.Value);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Password updated successfully!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update password.");
                        }
                    }
                }
                else
                {
                    // Add mode: insert new record
                    string query = @"
                        INSERT INTO passwords (site_name, username, password_encrypted, category_id, user_id, encryption_id, created_at)
                        VALUES (@siteName, @username, @passwordEncrypted, @categoryId, 1, 1, NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@siteName", siteName);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@passwordEncrypted", passwordEncrypted);
                        cmd.Parameters.AddWithValue("@categoryId", categoryId);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Password added successfully!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add password.");
                        }
                    }
                }
            }
        }

        private void cmbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
