using Google.Protobuf.WellKnownTypes;
using GymManagementSystem.Controller;
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
                Address = AddressTb.Text,
            };

            string errorMessage;
            bool isAdded = _trainercontroller.AddTrainer(trainer, out errorMessage);

            if (isAdded)
            {
                MessageBox.Show("Trainer added succesfully!");
                LoadTrainers();
                ClearFields();
            }
            else
            {
                MessageBox.Show(errorMessage); // Show specific error messge
            }

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
                Address = AddressTb.Text,
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
                AddressTb.Text = row.Cells[6].Value.ToString();
            }
        }

        private void ClearFields()
        {
            _selectedTrainerId = 0;
            TNameTb.Text = string.Empty;
            GenderCb.SelectedIndex = -1;
            DOBTb.Value = new DateTime(2007, 1, 1);
            PhoneTb.Text = string.Empty;
            AddressTb.Text = string.Empty;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Classes classesForm = new Classes();
            classesForm.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

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
    }
}
