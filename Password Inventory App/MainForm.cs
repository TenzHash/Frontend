using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClosedXML.Excel;
using Microsoft.VisualBasic;
using System.Security.Cryptography; // Add at the top if not present
using System.Text;                  // Add at the top if not present

namespace Password_Inventory_App
{
    public partial class NavigationalPanel : Form
    {
        string connectionStringUsers = "server=localhost;user=root;password=;database=passwordinventory;";
        string connectionString = "server=localhost;user=root;password=;database=passwordinventorydb;";
        private DataTable passwordsTable; // Add this at the class level
        private DataTable usersTable; // Add this at the class level

        public NavigationalPanel()
        {
            InitializeComponent();
            this.FormClosed += (s, e) => Application.Exit();
            this.txtUserSearch.TextChanged += new System.EventHandler(this.txtUserSearch_TextChanged);
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
        }

        private void LoadPasswords()
        {
            string connectionString = "server=localhost;database=passwordinventorydb;uid=root;pwd=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        p.entry_id,
                        p.user_id,
                        p.site_name, 
                        p.username, 
                        p.password_encrypted,   
                        c.category_name, 
                        p.created_at,
                        al.action
                    FROM passwords p
                    LEFT JOIN categories c ON p.category_id = c.category_id
                    LEFT JOIN (
                        SELECT user_id, action
                        FROM activitylogs
                        WHERE (user_id, timestamp) IN (
                            SELECT user_id, MAX(timestamp)
                            FROM activitylogs
                            GROUP BY user_id
                        )
                    ) al ON p.user_id = al.user_id";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    passwordsTable = new DataTable();
                    adapter.Fill(passwordsTable);

                    dataGridViewPasswords.DataSource = passwordsTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadUsers()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionStringUsers))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM users";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    usersTable = new DataTable();
                    adapter.Fill(usersTable);
                    dgvUsers.DataSource = usersTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading users: " + ex.Message);
                }
            }
        }

        private void FilterUsersTable()
        {
            if (usersTable == null)
                return;

            string searchValue = txtUserSearch.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(searchValue))
            {
                usersTable.DefaultView.RowFilter = "";
            }
            else
            {
                usersTable.DefaultView.RowFilter =
                    $"username LIKE '%{searchValue}%' OR email LIKE '%{searchValue}%'";
            }
        }
        private void LoadDashboardStats()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Total Passwords
                MySqlCommand cmdPasswords = new MySqlCommand("SELECT COUNT(*) FROM passwords", conn);
                int totalPasswords = Convert.ToInt32(cmdPasswords.ExecuteScalar());

                // Total Categories
                MySqlCommand cmdCategories = new MySqlCommand("SELECT COUNT(*) FROM categories", conn);
                int totalCategories = Convert.ToInt32(cmdCategories.ExecuteScalar());

                // Most Recent Entries
                MySqlCommand cmdRecent = new MySqlCommand("SELECT site_name, username, password_encrypted, created_at FROM passwords ORDER BY created_at DESC LIMIT 1", conn);
                MySqlDataReader reader = cmdRecent.ExecuteReader();

                StringBuilder recentEntries = new StringBuilder();
                while (reader.Read())
                {
                    recentEntries.AppendLine($"Website: {reader["site_name"]}");
                    recentEntries.AppendLine($"Username:{reader["username"]}");
                    recentEntries.AppendLine($"Encrypted Password:{reader["password_encrypted"]}");
                    recentEntries.AppendLine($"Date Added: ({Convert.ToDateTime(reader["created_at"]).ToShortDateString()})");
                }

                // Update labels or controls inside tableLayoutPanel1
                // Example: assume you have labels lblTotalPasswords, lblTotalCategories, lblRecentEntries
                lblTotalPasswords.Text = totalPasswords.ToString();
                lblTotalCategories.Text = totalCategories.ToString();
                lblRecentEntries.Text = recentEntries.ToString();

                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void NavigationalPanel_Load(object sender, EventArgs e)
        {
            LoadDashboardStats(); // Updates the label statistics
            LoadPasswords();      // Displays full passwords list in the DataGridView
            LoadUsers();         // Loads users into the DataGridView
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void Passwords_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void category_Click(object sender, EventArgs e)
        {

        }

        private void showpassBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordInput_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameInput_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void websiteInput_Click(object sender, EventArgs e)
        {

        }

        private void passwordsTab_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void passwordCn_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dashboardTab_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblRecentEntries_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridViewPasswords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }

            var row = dataGridViewPasswords.SelectedRows[0];
            int entryId = Convert.ToInt32(row.Cells["entry_id"].Value);
            string siteName = row.Cells["site_name"].Value?.ToString();
            string username = row.Cells["username"].Value?.ToString();
            string passwordEncrypted = row.Cells["password_encrypted"].Value?.ToString();
            string categoryName = row.Cells["category_name"].Value?.ToString();

            var editForm = new AddPasswordForm(entryId, siteName, username, passwordEncrypted, categoryName);
            editForm.FormClosed += (s, args) => LoadPasswords(); // Refresh after edit
            editForm.ShowDialog();
        }

        private void EditPassword(int passwordId, string siteName, string username, string passwordEncrypted, int categoryId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                UPDATE passwords 
                SET site_name = @siteName, 
                    username = @username, 
                    password_encrypted = @passwordEncrypted, 
                    category_id = @categoryId, 
                    updated_at = NOW() 
                WHERE password_id = @passwordId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@siteName", siteName);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@passwordEncrypted", passwordEncrypted);
                        cmd.Parameters.AddWithValue("@categoryId", categoryId);
                        cmd.Parameters.AddWithValue("@passwordId", passwordId);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Password updated successfully!");
                            LogActivity(1, $"Updated password for site: {siteName}");
                            LoadPasswords();
                            LoadDashboardStats();
                        }
                        else
                        {
                            MessageBox.Show("No record was updated.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridViewPasswords.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewPasswords.SelectedRows[0];

                // Make sure password_id is part of your DataGridView's data source
                if (selectedRow.Cells["entry_id"].Value != null)
                {
                    int passwordId = Convert.ToInt32(selectedRow.Cells["entry_id"].Value);

                    DialogResult dialogResult = MessageBox.Show(
                        "Are you sure you want to delete this password?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (dialogResult == DialogResult.Yes)
                    {
                        DeletePassword(passwordId);
                    }
                }
                else
                {
                    MessageBox.Show("Selected row does not contain a valid password ID.");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void DeletePassword(int passwordId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM passwords WHERE entry_id = @passwordId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@passwordId", passwordId);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Password deleted successfully!");
                            LogActivity(1, $"Deleted password with ID: {passwordId}");
                            LoadPasswords();
                            LoadDashboardStats();
                        }
                        else
                        {
                            MessageBox.Show("No record was deleted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AddUser(string username, string password, string email)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionStringUsers)) // Use passwordinventory database
            {
                try
                {
                    conn.Open();
                    string hashedPassword = HashPassword(password); // Hash the password here
                    string query = "INSERT INTO users (username, password, email) VALUES (@username, @password, @email)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword); // Store hashed password
                        cmd.Parameters.AddWithValue("@email", email);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("User added successfully!");
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add user.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void EditUser(int userId, string username, string password, string email)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE users SET username=@username, password=@password, email=@email WHERE user_id=@userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("User updated successfully!");
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("No record was updated.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void DeleteUser(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionStringUsers))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM users WHERE user_id=@userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("User deleted successfully!");
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("No record was deleted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {

        }

        private void searchLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (passwordsTable == null)
                return;

            string searchValue = txtSearch.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(searchValue))
            {
                passwordsTable.DefaultView.RowFilter = "";
            }
            else
            {
                passwordsTable.DefaultView.RowFilter =
                    $"site_name LIKE '%{searchValue}%' OR username LIKE '%{searchValue}%' OR category_name LIKE '%{searchValue}%'";
            }
        }

        private void txtWebsite_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            AddPasswordForm addForm = new AddPasswordForm();
            addForm.FormClosed += (s, args) =>
            {
                LoadPasswords();
                LoadDashboardStats();
            };
            addForm.ShowDialog();
        }

        private void LogActivity(int userId, string action)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    INSERT INTO activitylogs (user_id, action, timestamp) 
                    VALUES (@userId, @action, NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@action", action);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error logging activity: " + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnExportToExcel_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewPasswords.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Save an Excel File"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Passwords");
                        // Add headers
                        for (int i = 0; i < dataGridViewPasswords.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dataGridViewPasswords.Columns[i].HeaderText;
                        }
                        // Add rows
                        for (int i = 0; i < dataGridViewPasswords.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridViewPasswords.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dataGridViewPasswords.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                            }
                        }
                        workbook.SaveAs(sfd.FileName);
                    }
                    MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (passwordsTable == null)
                return;

            string searchValue = txtSearch.Text.Trim().Replace("'", "''"); // Escape single quotes
            if (string.IsNullOrEmpty(searchValue))
            {
                passwordsTable.DefaultView.RowFilter = "";
            }
            else
            {
                // Filter by site_name, username, or category_name (case-insensitive)
                passwordsTable.DefaultView.RowFilter =
                    $"site_name LIKE '%{searchValue}%' OR username LIKE '%{searchValue}%' OR category_name LIKE '%{searchValue}%'";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }


        private void usersTab_Click(object sender, EventArgs e)
        {

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Simple input dialog for demonstration; replace with a proper form as needed
            string username = Prompt.ShowDialog("Enter username:", "Add User");
            string password = Prompt.ShowDialog("Enter password:", "Add User");
            string email = Prompt.ShowDialog("Enter email:", "Add User");
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(email))
            {
                AddUser(username, password, email);
            }
        }

        private void btnEditUser_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.");
                return;
            }
            var row = dgvUsers.SelectedRows[0];
            int userId = Convert.ToInt32(row.Cells["user_id"].Value);
            string username = row.Cells["username"].Value?.ToString();
            string password = row.Cells["password"].Value?.ToString();
            string email = row.Cells["email"].Value?.ToString();

            // Use the Prompt helper for user input
            string newUsername = Prompt.ShowDialog("Edit username:", "Edit User", username);
            string newPassword = Prompt.ShowDialog("Edit password:", "Edit User", password);
            string newEmail = Prompt.ShowDialog("Edit email:", "Edit User", email);

            if (!string.IsNullOrWhiteSpace(newUsername) && !string.IsNullOrWhiteSpace(newPassword) && !string.IsNullOrWhiteSpace(newEmail))
            {
                EditUser(userId, newUsername, newPassword, newEmail);
            }
        }

        private void btnDeleteUser_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }
            var row = dgvUsers.SelectedRows[0];
            int userId = Convert.ToInt32(row.Cells["user_id"].Value);

            var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DeleteUser(userId);
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void txtUserSearch_TextChanged(object sender, EventArgs e)
        {
            FilterUsersTable();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            if (dgvUsers.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Save Users to Excel"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Users");
                        // Add headers
                        for (int i = 0; i < dgvUsers.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvUsers.Columns[i].HeaderText;
                        }
                        // Add visible rows
                        int rowIndex = 2;
                        foreach (DataGridViewRow row in dgvUsers.Rows)
                        {
                            if (row.Visible && !row.IsNewRow)
                            {
                                for (int j = 0; j < dgvUsers.Columns.Count; j++)
                                {
                                    worksheet.Cell(rowIndex, j + 1).Value = row.Cells[j].Value?.ToString() ?? string.Empty;
                                }
                                rowIndex++;
                            }
                        }
                        workbook.SaveAs(sfd.FileName);
                    }
                    MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
