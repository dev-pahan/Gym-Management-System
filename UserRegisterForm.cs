using System;
using System.Windows.Forms;
using GymManagementSystem.Controller;
using GymManagementSystem.Model;

namespace GymManagementSystem
{
    public partial class UserRegisterForm : Form
    {
        // Controller instance to handle user registration logic
        private readonly UserController _userController;

        // Constructor to initialize the form and the controller
        public UserRegisterForm()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        // Event handler for the Submit button click event
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            // Retrieve user input from the form fields
            string username = RUsername.Text;
            string password = RPassword.Text;
            string role = RRole.SelectedItem?.ToString() ?? string.Empty;

            // Check if a role is selected, if not, show a message and return
            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            // Create a new User object with the provided details
            User newUser = new User(username, password, role);

            // Attempt to register the new user using the controller
            if (_userController.RegisterUser(newUser, out string errorMessage))
            {
                // If registration is successful, show a success message and open the login form
                MessageBox.Show("User registered successfully!");
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            else
            {
                // If registration fails, show an error message
                MessageBox.Show($"Error: {errorMessage}");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}