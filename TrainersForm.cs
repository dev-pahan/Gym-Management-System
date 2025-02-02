using GymManagementSystem.Controller;
using GymManagementSystem.Model;
using System;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class TrainersForm : Form
    {
        // Controller instance to handle trainer-related operations
        private readonly TrainerController _trainercontroller;
        // Variable to store the selected trainer's ID
        private int _selectedTrainerId;

        // Constructor to initialize the form and load trainers
        public TrainersForm()
        {
            InitializeComponent();
            _trainercontroller = new TrainerController();
            LoadTrainers();
        }

        // Method to load all trainers into the TrainersList DataGridView
        private void LoadTrainers()
        {
            TrainersList.DataSource = _trainercontroller.GetAllTrainers();
        }

        // Event handler for the Save button click event
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // Create a new Trainer object with the provided details
            var trainer = new Trainer
            {
                Name = TNameTb.Text,
                Gender = GenderCb.Text,
                DateOfBirth = DOBTb.Value.Date,
                Phone = PhoneTb.Text,
                Address = AddressTb.Text,
            };

            // Attempt to add the new trainer using the controller
            string errorMessage;
            bool isAdded = _trainercontroller.AddTrainer(trainer, out errorMessage);

            if (isAdded)
            {
                // If addition is successful, show a success message, reload trainers, and clear fields
                MessageBox.Show("Trainer added successfully!");
                LoadTrainers();
                ClearFields();
            }
            else
            {
                // If addition fails, show the error message
                MessageBox.Show(errorMessage);
            }
        }

        // Event handler for the Edit button click event
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (_selectedTrainerId == 0)
            {
                MessageBox.Show("Select a trainer to edit.");
                return;
            }

            // Create a new Trainer object with the updated details
            var trainer = new Trainer
            {
                Id = _selectedTrainerId,
                Name = TNameTb.Text,
                Gender = GenderCb.Text,
                DateOfBirth = DOBTb.Value.Date,
                Phone = PhoneTb.Text,
                Address = AddressTb.Text,
            };

            // Attempt to update the trainer using the controller
            if (_trainercontroller.UpdateTrainer(trainer, out string errorMessage))
            {
                // If update is successful, show a success message, reload trainers, and clear fields
                MessageBox.Show("Trainer updated successfully!");
                LoadTrainers();
                ClearFields();
            }
            else
            {
                // If update fails, show the error message
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the Delete button click event
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (_selectedTrainerId == 0)
            {
                MessageBox.Show("Select a trainer to delete.");
                return;
            }

            // Attempt to delete the selected trainer using the controller
            string errorMessage;
            if (_trainercontroller.DeleteTrainer(_selectedTrainerId, out errorMessage))
            {
                // If deletion is successful, show a success message, reload trainers, and clear fields
                MessageBox.Show("Trainer deleted successfully!");
                LoadTrainers();
                ClearFields();
            }
            else
            {
                // If deletion fails, show the error message
                MessageBox.Show($"{errorMessage}");
            }
        }

        // Event handler for the TrainersList DataGridView cell click event
        private void TrainersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Populate the form fields with the selected trainer's details
                var row = TrainersList.Rows[e.RowIndex];
                _selectedTrainerId = int.Parse(row.Cells[0].Value.ToString());
                TNameTb.Text = row.Cells[1].Value.ToString();
                GenderCb.Text = row.Cells[2].Value.ToString();
                DOBTb.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                PhoneTb.Text = row.Cells[4].Value.ToString();
                AddressTb.Text = row.Cells[5].Value.ToString();
            }
        }

        // Method to clear the form fields
        private void ClearFields()
        {
            _selectedTrainerId = 0;
            TNameTb.Text = string.Empty;
            GenderCb.SelectedIndex = -1;
            DOBTb.Value = new DateTime(2007, 1, 1);
            PhoneTb.Text = string.Empty;
            AddressTb.Text = string.Empty;
        }

        // Event handler for the Classes label click event
        private void label13_Click(object sender, EventArgs e)
        {
            // Open the ClassesForm and hide the current form
            ClassesForm classesForm = new ClassesForm();
            classesForm.Show();
            this.Hide();
        }

        // Event handler for the Members label click event
        private void label11_Click(object sender, EventArgs e)
        {
            // Open the MembersForm and hide the current form
            MembersForm membersForm = new MembersForm();
            membersForm.Show();
            this.Hide();
        }

        // Event handler for the Logout label click event
        private void label16_Click(object sender, EventArgs e)
        {
            // Open the LoginForm and hide the current form
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        // Event handler for the Attendance label click event
        private void label14_Click(object sender, EventArgs e)
        {
            // Open the AttendanceForm and hide the current form
            AttendanceForm attendanceForm = new AttendanceForm();
            attendanceForm.Show();
            this.Hide();
        }
    }
}
