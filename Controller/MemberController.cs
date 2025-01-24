using GymManagementSystem.Model;
using System.Data;
using System.Data.SQLite;

namespace GymManagementSystem.Controller
{
    public class MemberController
    {
        private readonly Database _database;

        public MemberController()
        {
            _database = new Database();
        }

        public DataTable GetAllMembers()
        {
            string query = "SELECT * FROM MembersTbl";
            return _database.GetData(query);
        }

        public void AddMember(Member member)
        {
            string query = @"INSERT INTO MembersTbl (MName, MGender, MDOB, MPhone, MAddress, MMembershipStatus, MClass) 
                     VALUES (@MName, @Gender, @DOB, @Phone, @Address, @MembershipStatus, @MClass)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@MName", member.Name),
                new SQLiteParameter("@Gender", member.Gender),
                new SQLiteParameter("@DOB", member.DateOfBirth),
                new SQLiteParameter("@Phone", member.Phone),
                new SQLiteParameter("@Address", member.Address),
                new SQLiteParameter("@MembershipStatus", member.MembershipStatus),
                new SQLiteParameter("@MClass", member.MClass)
            };

            _database.ExecuteCommand(query, parameters);
        }

        public void UpdateMember(Member member)
        {
            string query = @"UPDATE MembersTbl SET 
                             MName = @MName, MGender = @Gender, MDOB = @DOB, MPhone = @Phone, 
                             MAddress = @Address, MMembershipStatus = @MembershipStatus, MClass = @MClass
                             WHERE MId = @MId";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@MName", member.Name),
                new SQLiteParameter("@Gender", member.Gender),
                new SQLiteParameter("@DOB", member.DateOfBirth),
                new SQLiteParameter("@Phone", member.Phone),
                new SQLiteParameter("@Address", member.Address),
                new SQLiteParameter("@MembershipStatus", member.MembershipStatus),
                new SQLiteParameter("@MClass", member.MClass),
                new SQLiteParameter("@MId", member.Id)
            };

            _database.ExecuteCommand(query, parameters);
        }

        public void DeleteMember(int memberId)
        {
            string query = "DELETE FROM MembersTbl WHERE MId = @MId";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@MId", memberId)
            };

            _database.ExecuteCommand(query, parameters);
        }
    }
}