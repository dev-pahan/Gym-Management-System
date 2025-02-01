using System;

namespace GymManagementSystem.Model
{
    public class Attendance
    {
        public int AId { get; set; }
        public int MemberId { get; set; }
        public DateTime ADate { get; set; }
        public string AStatus { get; set; }

        public Attendance() { }

        public Attendance(int id, int memberId, DateTime date, string status)
        {
            AId = id;
            MemberId = memberId;
            ADate = date;
            AStatus = status;
        }
    }
}
