using GymManagementSystem.Controller;
using GymManagementSystem.Model;
using System;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class MembersForm : Form
    {
        private readonly MemberController _memberController;
        private readonly ClassController _classController;
        private int _selectedMemberId;

        public MembersForm()
        {
            InitializeComponent();
            _memberController = new MemberController();
            _classController = new ClassController();
            LoadMembers();
            LoadClasses();
        }

        // Load all members into the MembersList DataGridView
        private void LoadMembers()
        {
            MembersList.DataSource = _memberController.GetAllMembers();
        }

        // Load all classes into the MClass ComboBox
        private void LoadClasses()
        {
            var classes = _classController.GetAllClasses();
            MClass.DataSource = classes;
            MClass.DisplayMember = "CName";
            MClass.ValueMember = "CName";
            MClass.SelectedIndex = -1;
        }

        // Navigate to TrainersForm
        private void label10_Click(object sender, EventArgs e)
        {
            TrainersForm trainersForm = new TrainersForm();
            trainersForm.Show();
            this.Hide();
        }

        // Save a new member
        private void SaveBt_Click(object sender, EventArgs e)
        {
            var member = new Member
            {
                Name = MNameTb.Text,
                Gender = GenderCb.Text,
                DateOfBirth = DOBTb.Value.Date,
                Phone = PhoneTb.Text,
                Address = MAddressTb.Text,
                MembershipStatus = MStatus.Text,
                MClass = MClass.Text
            };

            string errorMessage;
            bool isAdded = _memberController.AddMember(member, out errorMessage);

            if (isAdded)
            {
                MessageBox.Show("Member added successfully!");
                LoadMembers();
                ClearFields();
            }
            else
            {
                MessageBox.Show($"Failed to add member: {errorMessage}");
            }
        }

        // Edit an existing member
        private void EditBt_Click(object sender, EventArgs e)
        {
            if (_selectedMemberId == 0)
            {
                MessageBox.Show("Select a member to edit.");
                return;
            }

            var member = new Member
            {
                Id = _selectedMemberId,
                Name = MNameTb.Text,
                Gender = GenderCb.Text,
                DateOfBirth = DOBTb.Value.Date,
                Phone = PhoneTb.Text,
                Address = MAddressTb.Text,
                MembershipStatus = MStatus.Text,
                MClass = MClass.Text
            };

            _memberController.UpdateMember(member);
            MessageBox.Show("Member updated successfully!");
            LoadMembers();
            ClearFields();
        }

        // Delete a selected member
        private void DeleteBt_Click(object sender, EventArgs e)
        {
            if (_selectedMemberId == 0)
            {
                MessageBox.Show("Select a member to delete.");
                return;
            }

            _memberController.DeleteMember(_selectedMemberId);
            MessageBox.Show("Member deleted successfully!");
            LoadMembers();
            ClearFields();
        }

        // Navigate to ClassesForm
        private void label13_Click(object sender, EventArgs e)
        {
            ClassesForm classesForm = new ClassesForm();
            classesForm.Show();
            this.Hide();
        }

        // Clear all input fields
        private void ClearFields()
        {
            _selectedMemberId = 0;
            MNameTb.Text = string.Empty;
            GenderCb.SelectedIndex = -1;
            DOBTb.Value = new DateTime(2007, 1, 1);
            PhoneTb.Text = string.Empty;
            MAddressTb.Text = string.Empty;
            MStatus.SelectedIndex = -1;
            MClass.SelectedIndex = -1;
        }

        // Populate fields with selected member data
        private void MembersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = MembersList.Rows[e.RowIndex];
                _selectedMemberId = int.Parse(row.Cells[0].Value.ToString());
                MNameTb.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                GenderCb.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                DOBTb.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                PhoneTb.Text = row.Cells[4].Value?.ToString() ?? string.Empty;
                MAddressTb.Text = row.Cells[5].Value?.ToString() ?? string.Empty;
                MStatus.Text = row.Cells[6].Value?.ToString() ?? string.Empty;
                MClass.Text = row.Cells[7].Value?.ToString() ?? string.Empty;
            }
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
