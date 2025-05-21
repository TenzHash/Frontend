using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Password_Inventory_App
{
    public partial class forgot : Form
    {
        public forgot()
        {
            InitializeComponent();
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "server=localhost;database=passwordinventory;uid=root;pwd=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if user exists
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", username);

                    int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userExists == 0)
                    {
                        MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Hash the new password
                    string hashedPassword = HashPassword(newPassword);

                    // Update the password
                    string updateQuery = "UPDATE users SET password = @password WHERE username = @username";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@password", hashedPassword);
                    updateCmd.Parameters.AddWithValue("@username", username);

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Password reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NavigationalPanel navPanel = new NavigationalPanel();
                    navPanel.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // hide register
            Login loginForm = new Login();

            // When Login is closed, show Register again (optional)
            loginForm.FormClosed += (s, args) => this.Show();
            loginForm.Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void forgot_Load(object sender, EventArgs e)
        {

        }
    }
}
