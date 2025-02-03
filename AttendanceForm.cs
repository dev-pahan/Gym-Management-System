using GymManagementSystem.Controller;
using GymManagementSystem.Model;
using System;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class AttendanceForm : Form
    {
        private readonly AttendanceController _attendanceController;
        private int _selectedAttendanceId;

        public AttendanceForm()
        {
            InitializeComponent();
            _attendanceController = new AttendanceController();
            LoadAttendance();
            LoadMembers();
        }

        // Load all attendance records into the AttendanceList DataGridView
        private void LoadAttendance()
        {
            AttendanceList.DataSource = _attendanceController.GetAllAttendance();
        }

        // Load all members into the MemberId ComboBox
        private void LoadMembers()
        {
            var members = _attendanceController.GetMembers();
            MemberId.DataSource = members;
            MemberId.DisplayMember = "MName";
            MemberId.ValueMember = "MId";
            MemberId.SelectedIndex = -1;
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

        // Edit an existing attendance record
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (_selectedAttendanceId == 0)
            {
                MessageBox.Show("Select an attendance record to edit.");
                return;
            }

            var attendance = new Attendance
            {
                AId = _selectedAttendanceId,
                MemberId = int.Parse(MemberId.SelectedValue.ToString()),
                ADate = Date.Value,
                AStatus = AttendanceStatus.Text
            };

            _attendanceController.UpdateAttendance(attendance);
            MessageBox.Show("Attendance updated successfully!");
            LoadAttendance();
            ClearFields();
        }

        // Save a new attendance record
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (MemberId.SelectedValue == null || Date.Value == null || AttendanceStatus.Text == null || _attendanceController == null)
            {
                MessageBox.Show("All the fields must be filled!");
                return;
            }

            var attendance = new Attendance
            {
                MemberId = int.Parse(MemberId.SelectedValue.ToString()),
                ADate = Date.Value,
                AStatus = AttendanceStatus.Text
            };

            _attendanceController.AddAttendance(attendance);
            MessageBox.Show("Attendance added successfully!");
            LoadAttendance();
            ClearFields();
        }

        // Delete a selected attendance record
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (_selectedAttendanceId == 0)
            {
                MessageBox.Show("Select an attendance record to delete.");
                return;
            }

            _attendanceController.DeleteAttendance(_selectedAttendanceId);
            MessageBox.Show("Attendance deleted successfully!");
            LoadAttendance();
            ClearFields();
        }

        // Populate fields with selected attendance data
        private void AttendanceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = AttendanceList.Rows[e.RowIndex];
                _selectedAttendanceId = int.Parse(row.Cells[0].Value.ToString());
                MemberId.SelectedValue = row.Cells[1].Value;
                Date.Value = DateTime.Parse(row.Cells[2].Value.ToString());
                AttendanceStatus.Text = row.Cells[3].Value.ToString();
            }
        }

        // Clear all input fields
        private void ClearFields()
        {
            _selectedAttendanceId = 0;
            MemberId.SelectedIndex = -1;
            AttendanceStatus.SelectedIndex = -1;
        }
    }
}

