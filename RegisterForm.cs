﻿using System.Data.SQLite;
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
        private readonly RegisterController _controller;
        public RegisterForm()
        {
            InitializeComponent();
            _controller = new RegisterController();
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

            var password = PasswordTb.Text.Trim();
            //Create a new user object
            var user = new User
            {
                Username = username,
                Password = password
            };


            try
            {
                //Register the user
                string errorMessage;
                if (_controller.RegisterUser(user, out errorMessage))
                {
                    MessageBox.Show("Registration successfull!");
                    this.Hide();
                    Login LoginForm = new Login();
                    LoginForm.Show();
                }
                else
                {
                    MessageBox.Show($"Registration failed: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            TxtPassword.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void PasswordTb_Click(object sender, EventArgs e)
        {

        }
    }
}
      