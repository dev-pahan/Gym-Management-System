using System;
using System.Windows.Forms;
using GymManagementSystem.Controller;
using GymManagementSystem.Model;

namespace GymManagementSystem
{
    public partial class UserRegisterForm : Form
    {
        private readonly UserController _controller;

        public UserRegisterForm()
        {
            InitializeComponent();
            _controller = new UserController();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            string username = RUsername.Text;
            string password = RPassword.Text;
            string role = RRole.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            User newUser = new User(username, password, role);

            if (_controller.RegisterUser(newUser, out string errorMessage))
            {
                MessageBox.Show("User registered successfully!");
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show($"Error: {errorMessage}");
            }
        }
    }
}