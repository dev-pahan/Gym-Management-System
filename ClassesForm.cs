using GymManagementSystem.Controller;
using GymManagementSystem.Model;
using System;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class ClassesForm : Form
    {
        private readonly ClassController _classController;
        private readonly TrainerController _trainerController;
        private int _selectedClassId;

        public ClassesForm()
        {
            InitializeComponent();
            _classController = new ClassController();
            _trainerController = new TrainerController();
            LoadClasses();
            LoadTrainerNames();
        }

        // Load all classes into the ClassesList DataGridView
        private void LoadClasses()
        {
            ClassesList.DataSource = _classController.GetAllClasses();
        }

        // Load all trainer names into the CTrainerName ComboBox
        private void LoadTrainerNames()
        {
            var trainers = _trainerController.GetAllTrainers();
            CTrainerName.DataSource = trainers;
            CTrainerName.DisplayMember = "TName";
            CTrainerName.ValueMember = "TName";
            CTrainerName.SelectedIndex = -1;
        }

        // Edit an existing class
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

            string errorMessage;
            if (_classController.UpdateClass(classItem, out errorMessage))
            {
                MessageBox.Show("Class updated successfully!");
                LoadClasses();
                ClearFields();
            }
            else
            {
                MessageBox.Show($"{errorMessage}");
            }
        }

        // Save a new class
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var classItem = new Class
            {
                CName = CNameTb.Text,
                CTime = CTime.Text,
                CTrainer = CTrainerName.Text
            };

            string errorMessage;
            if (_classController.AddClass(classItem, out errorMessage))
            {
                MessageBox.Show("Class added successfully!");
                LoadClasses();
                ClearFields();
            }
            else
            {
                MessageBox.Show($"{errorMessage}");
            }
        }

        // Delete a selected class
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (_selectedClassId == 0)
            {
                MessageBox.Show("Select a class to delete.");
                return;
            }

            string errorMessage;
            if (_classController.DeleteClass(_selectedClassId, out errorMessage))
            {
                MessageBox.Show("Class deleted successfully!");
                LoadClasses();
                ClearFields();
            }
            else
            {
                MessageBox.Show($"{errorMessage}");
            }
        }

        // Populate fields with selected class data
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

        // Clear all input fields
        private void ClearFields()
        {
            _selectedClassId = 0;
            CNameTb.Text = string.Empty;
            CTime.SelectedIndex = -1;
            CTrainerName.SelectedIndex = -1;
        }

        // Navigate to TrainersForm
        private void label10_Click(object sender, EventArgs e)
        {
            TrainersForm trainersForm = new TrainersForm();
            trainersForm.Show();
            this.Hide();
        }

        // Navigate to MembersForm
        private void label11_Click(object sender, EventArgs e)
        {
            MembersForm membersForm = new MembersForm();
            membersForm.Show();
            this.Hide();
        }

        // Navigate to ClassesForm
        private void label13_Click(object sender, EventArgs e)
        {
            ClassesForm classForm = new ClassesForm();
            classForm.Show();
            this.Hide();
        }

        // Navigate to LoginForm
        private void label16_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        // Navigate to AttendanceForm
        private void label14_Click(object sender, EventArgs e)
        {
            AttendanceForm attendanceForm = new AttendanceForm();
            attendanceForm.Show();
            this.Hide();
        }
    }
}

