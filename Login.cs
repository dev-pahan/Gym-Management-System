using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class Login : Form
    {
        //Connection string to SQLite Database

        private string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "gms.db");
        private string connectionString;
        private Database Con;

        public Login()
        {
            InitializeComponent();
            connectionString = $"Data Source={dbPath};Version=3;";
            Con = new Database();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            TxtPassword.PasswordChar = '*';
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text.Trim();
            string password = TxtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hardcoded default username and password
            /*if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hide the login form and open the main dashboard
                this.Hide();
                Trainers dashboard = new Trainers();
                dashboard.Show();
                return;
            }*/

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM UsersTbl WHERE Username = @Username";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        object storedPassword = cmd.ExecuteScalar();

                        /*if (storedPassword != null)
                        {
                            //Compare entered password with the stored hashed password
                            if (VerifyPassword(password, storedPassword.ToString()))
                            {
                                MessageBox.Show("Login Successfill!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Hide the login form and open the main dashboard
                                this.Hide();
                                Trainers dashboard = new Trainers();
                                dashboard.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }*/

                        cmd.Parameters.AddWithValue("@Password", password);

                        int result = Convert.ToInt32(cmd.ExecuteScalar());

                        if (result > 0)
                        {
                            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Hide the login form and open the main dashboard
                            this.Hide();
                            Trainers dashboard = new Trainers();
                            dashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterLbl_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }
    }
}

