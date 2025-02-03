using GymManagementSystem.Controller;
using GymManagementSystem.Model;
using System;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class LoginForm : Form
    {
        private readonly UserController _controller;

        public LoginForm()
        {
            InitializeComponent();
            _controller = new UserController();
        }

        // Navigate to UserRegisterForm
        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                UserRegisterForm userRegisterForm = new UserRegisterForm();
                userRegisterForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle user login
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = LUsername.Text;
            string password = LPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                User user = _controller.AuthenticateUser(username, password, out string errorMessage);

                if (user != null)
                {
                    if (user.Role == "Admin")
                    {
                        TrainersForm trainersForm = new TrainersForm();
                        trainersForm.Show();
                    }
                    else if (user.Role == "Trainer")
                    {
                        TrainerClassesForm classesForm = new TrainerClassesForm();
                        classesForm.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(errorMessage, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
