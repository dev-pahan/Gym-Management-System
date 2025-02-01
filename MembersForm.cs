using GymManagementSystem.Controller;
using GymManagementSystem.Model;
using System;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class MembersForm : Form
    {
        private readonly MemberController _memberController;
        private readonly ClassController _classController; // Controller for ClassTbl
        private int _selectedMemberId;

        public MembersForm()
        {
            InitializeComponent();
            _memberController = new MemberController();
            _classController = new ClassController(); // Initialize ClassController
            LoadMembers();
            LoadClasses(); // Populate MClass combo box
        }

        private void LoadMembers()
        {
            MembersList.DataSource = _memberController.GetAllMembers();
        }

        private void LoadClasses()
        {
            var classes = _classController.GetAllClasses(); // Retrieve classes from ClassTbl
            MClass.DataSource = classes;
            MClass.DisplayMember = "CName"; // Class Name
            MClass.ValueMember = "CName"; // Value
            MClass.SelectedIndex = -1; // Ensure no class is selected by default
        }

        private void label10_Click(object sender, EventArgs e)
        {
            TrainersForm trainersForm = new TrainersForm();
            trainersForm.Show();
            this.Hide();
        }

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
                MClass = MClass.Text // Save selected class
            };

            _memberController.AddMember(member);
            MessageBox.Show("Member added successfully!");
            LoadMembers();
            ClearFields();
        }

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
                MClass = MClass.Text // Update selected class
            };

            _memberController.UpdateMember(member);
            MessageBox.Show("Member updated successfully!");
            LoadMembers();
            ClearFields();
        }

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

        private void label13_Click(object sender, EventArgs e)
        {
            ClassesForm classesForm = new ClassesForm();
            classesForm.Show();
            this.Hide();

        }

        private void label14_Click(object sender, EventArgs e)
        {
            AttendanceForm attendanceForm = new AttendanceForm();
            attendanceForm.Show();
            this.Hide();
        }
        private void ClearFields()
        {
            _selectedMemberId = 0;
            MNameTb.Text = string.Empty;
            GenderCb.SelectedIndex = -1;
            DOBTb.Value = DateTime.Now;
            PhoneTb.Text = string.Empty;
            MAddressTb.Text = string.Empty;
            MStatus.SelectedIndex = -1;
            MClass.SelectedIndex = -1;
        }

        private void MembersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = MembersList.Rows[e.RowIndex];
                _selectedMemberId = int.Parse(row.Cells[0].Value.ToString());
                MNameTb.Text = row.Cells[1].Value.ToString();
                GenderCb.Text = row.Cells[2].Value.ToString();
                DOBTb.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                PhoneTb.Text = row.Cells[4].Value.ToString();
                MAddressTb.Text = row.Cells[5].Value.ToString();
                MStatus.Text = row.Cells[6].Value.ToString();
                MClass.Text = row.Cells[7].Value.ToString(); // Set selected class
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
