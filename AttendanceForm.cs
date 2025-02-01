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

        private void LoadAttendance()
        {
            AttendanceList.DataSource = _attendanceController.GetAllAttendance();
        }

        private void LoadMembers()
        {
            var members = _attendanceController.GetMembers();
            MemberId.DataSource = members;
            MemberId.DisplayMember = "MName";
            MemberId.ValueMember = "MId";
            MemberId.SelectedIndex = -1;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            TrainersForm trainersForm = new TrainersForm();
            trainersForm.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            MembersForm membersForm = new MembersForm();
            membersForm.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            ClassesForm classForm = new ClassesForm();
            classForm.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
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

        private void AttendanceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = AttendanceList.Rows[e.RowIndex];
                _selectedAttendanceId = int.Parse(row.Cells[0].Value.ToString());
                MemberId.Text = row.Cells[1].Value.ToString();
                Date.Value = DateTime.Parse(row.Cells[2].Value.ToString());
                AttendanceStatus.Text = row.Cells[3].Value.ToString();
            }
        }

        private void ClearFields()
        {
            _selectedAttendanceId = 0;
            MemberId.SelectedIndex = -1;
            AttendanceStatus.SelectedIndex = -1;
        }
    }
}
