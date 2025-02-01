using GymManagementSystem.Model;
using System.Data;
using System.Data.SQLite;

namespace GymManagementSystem.Controller
{
    public class AttendanceController
    {
        private readonly Database _database;

        public AttendanceController()
        {
            _database = new Database();
        }

        public DataTable GetAllAttendance()
        {
            string query = "SELECT A.AId, M.MName, A.ADate, A.AStatus FROM AttendanceTbl A " +
                           "JOIN MembersTbl M ON A.MemberId = M.MId";
            return _database.GetData(query);
        }

        public DataTable GetMembers()
        {
            string query = "SELECT MId, MName FROM MembersTbl";
            return _database.GetData(query);
        }

        public void AddAttendance(Attendance attendance)
        {
            string query = "INSERT INTO AttendanceTbl (MemberId, ADate, AStatus) VALUES (@MemberId, @ADate, @AStatus)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@MemberId", attendance.MemberId),
                new SQLiteParameter("@ADate", attendance.ADate),
                new SQLiteParameter("@AStatus", attendance.AStatus)
            };

            _database.ExecuteCommand(query, parameters);
        }

        public void UpdateAttendance(Attendance attendance)
        {
            string query = "UPDATE AttendanceTbl SET MemberId = @MemberId, ADate = @ADate, AStatus = @AStatus WHERE AId = @AId";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@AId", attendance.AId),
                new SQLiteParameter("@MemberId", attendance.MemberId),
                new SQLiteParameter("@ADate", attendance.ADate),
                new SQLiteParameter("@AStatus", attendance.AStatus)
            };

            _database.ExecuteCommand(query, parameters);
        }

        public void DeleteAttendance(int attendanceId)
        {
            string query = "DELETE FROM AttendanceTbl WHERE AId = @AId";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@AId", attendanceId)
            };

            _database.ExecuteCommand(query, parameters);
        }
    }
}
