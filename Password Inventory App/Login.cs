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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional: clear fields when form loads
            txtUsername.Clear();
            txtPassword.Clear();
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
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string connectionString = "server=localhost;database=passwordinventory;uid=root;pwd=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string hashedPassword = HashPassword(password); // use the same hashing method

                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword); // hashed check


                    int userExists = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        NavigationalPanel navPanel = new NavigationalPanel();
                        navPanel.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) // chkShowPassword
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide(); // Close the login form
        }


        private void username_TextChanged(object sender, EventArgs e)
        {
            // Optional: Live validation or UI feedback
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // hide login
            forgot ForgotPasswordForm = new forgot();

            // When Register is closed, show Login again
            ForgotPasswordForm.FormClosed += (s, args) => this.Show();
            ForgotPasswordForm.Show();
        }
    }
    public class AppContext : ApplicationContext
    {
        public AppContext()
        {
            Login loginForm = new Login();
            loginForm.FormClosed += OnFormClosed;
            loginForm.Show();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            ExitThread(); // this ends the app cleanly
        }
    }
}
