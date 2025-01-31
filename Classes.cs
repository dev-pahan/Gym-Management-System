﻿using GymManagementSystem.Controller;
using GymManagementSystem.Model;
using System;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class Classes : Form
    {
        private readonly ClassController _classController;
        private readonly TrainerController _trainerController;
        private int _selectedClassId;

        public Classes()
        {
            InitializeComponent();
            _classController = new ClassController();
            _trainerController = new TrainerController();
            LoadClasses();
            LoadTrainerNames();
        }

        private void LoadClasses()
        {
            ClassesList.DataSource = _classController.GetAllClasses();
        }

        private void LoadTrainerNames()
        {
            var trainers = _trainerController.GetAllTrainers();
            CTrainerName.DataSource = trainers;
            CTrainerName.DisplayMember = "TName";
            CTrainerName.ValueMember = "TName";

            CTrainerName.SelectedIndex = -1;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (_selectedClassId == 0)
            {
                MessageBox.Show("Select a class to edit.");
                return;
            }

            var classItem = new Class
            {
                CId = _selectedClassId,
                CName = CNameTb.Text,
                CTime = CTime.Text,
                CTrainer = CTrainerName.Text
            };

            _classController.UpdateClass(classItem);
            MessageBox.Show("Class updated successfully!");
            LoadClasses();
            ClearFields();
        }

        private void CNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void CTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CTrainerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var classItem = new Class
            {
                CName = CNameTb.Text,
                CTime = CTime.Text,
                CTrainer = CTrainerName.Text
            };

            _classController.AddClass(classItem);
            MessageBox.Show("Class added successfully!");
            LoadClasses();
            ClearFields();
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (_selectedClassId == 0)
            {
                MessageBox.Show("Select a class to delete.");
                return;
            }

            _classController.DeleteClass(_selectedClassId);
            MessageBox.Show("Class deleted successfully!");
            LoadClasses();
            ClearFields();
        }


        private void ClassesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = ClassesList.Rows[e.RowIndex];
                _selectedClassId = int.Parse(row.Cells[0].Value.ToString());
                CNameTb.Text = row.Cells[1].Value.ToString();
                CTime.Text = row.Cells[2].Value.ToString();
                CTrainerName.Text = row.Cells[3].Value.ToString();
            }
        }
        private void ClearFields()
        {
            _selectedClassId = 0;
            CNameTb.Text = string.Empty;
            CTime.SelectedIndex = -1;
            CTrainerName.SelectedIndex = -1;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Trainers trainersForm = new Trainers();
            trainersForm.Show();
            
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Members membersForm = new Members();
            membersForm.Show();
            
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Classes classForm = new Classes();
            classForm.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}