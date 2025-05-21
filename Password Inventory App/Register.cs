using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Password_Inventory_App
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text.Trim();
            string password = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
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
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", username);

                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (exists > 0)
                    {
                        MessageBox.Show("Username already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string insertQuery = "INSERT INTO users (username, password) VALUES (@username, @password)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Close the Register form
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // hide register
            Login loginForm = new Login();

            // When Login is closed, show Register again (optional)
            loginForm.FormClosed += (s, args) => this.Show();
            loginForm.Show();
    }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

private void btnlogin_Click(object sender, EventArgs e)
    {
            string username = txtNewUsername.Text.Trim();
            string password = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
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
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", username);

                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (exists > 0)
                    {
                        MessageBox.Show("Username already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string hashedPassword = HashPassword(password);
                    string insertQuery = "INSERT INTO users (username, password) VALUES (@username, @password)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword); // hashed password

                    cmd.ExecuteNonQuery();

                    // Auto-login after successful registration
                    MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NavigationalPanel navPanel = new NavigationalPanel();
                    navPanel.FormClosed += (s, args) => Application.Exit(); // make sure the app exits when navPanel closes
                    navPanel.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNewUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
