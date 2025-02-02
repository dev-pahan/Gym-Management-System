using GymManagementSystem.Controller;
using GymManagementSystem.Model;
using System;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class TrainerClassesForm : Form
    {
        private readonly ClassController _classController;
        private readonly TrainerController _trainerController;
        private int _selectedClassId;

        public TrainerClassesForm()
        {
            InitializeComponent();
            _classController = new ClassController();
            _trainerController = new TrainerController();
            LoadClasses();
            LoadTrainerNames();
        }

        // Loads all classes into the ClassesList DataGridView
        private void LoadClasses()
        {
            ClassesList.DataSource = _classController.GetAllClasses();
        }

        // Loads all trainer names into the CTrainerName ComboBox
        private void LoadTrainerNames()
        {
            var trainers = _trainerController.GetAllTrainers();
            CTrainerName.DataSource = trainers;
            CTrainerName.DisplayMember = "TName";
            CTrainerName.ValueMember = "TName";

            CTrainerName.SelectedIndex = -1;
        }

        // Handles the Edit button click event to update the selected class
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

        // Handles the Save button click event to add a new class
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

        // Handles the Delete button click event to delete the selected class
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

        // Handles the cell content click event in the ClassesList DataGridView to populate the fields with the selected class data
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

        // Clears the input fields and resets the selected class ID
        private void ClearFields()
        {
            _selectedClassId = 0;
            CNameTb.Text = string.Empty;
            CTime.SelectedIndex = -1;
            CTrainerName.SelectedIndex = -1;
        }

        // Handles the label click event to navigate to the login form
        private void label16_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
