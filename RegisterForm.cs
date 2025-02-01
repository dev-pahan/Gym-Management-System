using System.Data.SQLite;
using GymManagementSystem.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymManagementSystem.Model;

namespace GymManagementSystem
{
    public partial class RegisterForm : Form
    {
        private readonly UserController _controller;
        public RegisterForm()
        {
            InitializeComponent();
            _controller = new UserController();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            var username = UsernameTb.Text.Trim();
            var password = PasswordTb.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and Password cannot be empty!");
                return;
            }

            //Check if username exists
            if (_controller.DoesUsernameExist(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;
            }

            //Create a new user object
            var user = new User
            {
                Username = username,
                Password = password
            };

                //Register the user
                _controller.RegisterUser(user);

            MessageBox.Show("Registration successfull!");
            /*this.Close();*/

            //Hide the register form after successfull registration
            /*this.Hide();*/

            Login LoginForm = new Login();
            LoginForm.Show();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            TxtPassword.PasswordChar = '*';
        }
    }
}
