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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UsernameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void EditB_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void NameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExperienceTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddressTb_TextChanged(object sender, EventArgs e)
        {

        }
        private void GenderCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DOBTb_ValueChanged(object sender, EventArgs e)
        {

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

            string errorMessage;
            bool isSuccess = _trainercontroller.AddTrainer(trainer, out errorMessage);

            if (!isSuccess)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                MessageBox.Show("Trainer added succesfully!");
                LoadTrainers();
                ClearFields();
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
