﻿using GymManagementSystem.Controller;
using GymManagementSystem.Model;
using System;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class Trainers : Form    
    {
        private readonly TrainerController _trainercontroller;
        private int _selectedTrainerId;

        public Trainers()
        {
            InitializeComponent();
            _trainercontroller = new TrainerController();
            LoadTrainers();
        }

        private void LoadTrainers()
        {
            TrainersList.DataSource = _trainercontroller.GetAllTrainers();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var trainer = new Trainer
            {
                Name = TNameTb.Text,
                Gender = GenderCb.Text,
                DateOfBirth = DOBTb.Value.Date,
                Phone = PhoneTb.Text,
                Experience = int.Parse(ExperienceTb.Text),
                Address = AddressTb.Text,
                Password = PasswordTb.Text
            };

            _trainercontroller.AddTrainer(trainer);
            MessageBox.Show("Trainer added successfully!");
            LoadTrainers();
            ClearFields();
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (_selectedTrainerId == 0)
            {
                MessageBox.Show("Select a trainer to edit.");
                return;
            }

            var trainer = new Trainer
            {
                Id = _selectedTrainerId,
                Name = TNameTb.Text,
                Gender = GenderCb.Text,
                DateOfBirth = DOBTb.Value.Date,
                Phone = PhoneTb.Text,
                Experience = int.Parse(ExperienceTb.Text),
                Address = AddressTb.Text,
                Password = PasswordTb.Text
            };

            _trainercontroller.UpdateTrainer(trainer);
            MessageBox.Show("Trainer updated successfully!");
            LoadTrainers();
            ClearFields();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (_selectedTrainerId == 0)
            {
                MessageBox.Show("Select a trainer to delete.");
                return;
            }

 
            _trainercontroller.DeleteTrainer(_selectedTrainerId);

            MessageBox.Show("Trainer deleted successfully!");
            LoadTrainers();
            ClearFields();
        }

        private void TrainersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = TrainersList.Rows[e.RowIndex];
                _selectedTrainerId = int.Parse(row.Cells[0].Value.ToString());
                TNameTb.Text = row.Cells[1].Value.ToString();
                GenderCb.Text = row.Cells[2].Value.ToString();
                DOBTb.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                PhoneTb.Text = row.Cells[4].Value.ToString();
                ExperienceTb.Text = row.Cells[5].Value.ToString();
                AddressTb.Text = row.Cells[6].Value.ToString();
                PasswordTb.Text = row.Cells[7].Value.ToString();
            }
        }

        private void ClearFields()
        {
            _selectedTrainerId = 0;
            TNameTb.Text = string.Empty;
            GenderCb.SelectedIndex = -1;
            DOBTb.Value = DateTime.Now;
            PhoneTb.Text = string.Empty;
            ExperienceTb.Text = string.Empty;
            AddressTb.Text = string.Empty;
            PasswordTb.Text = string.Empty;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Classes classesForm = new Classes();
            classesForm.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Members membersForm = new Members();
            membersForm.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            AttendanceForm attendanceForm = new AttendanceForm();
            attendanceForm.Show();
            this.Hide();
        }
    }
}
