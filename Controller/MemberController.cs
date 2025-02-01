using GymManagementSystem.Model;
using System.Data;
using System.Data.SQLite;
using System.Linq;

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

        public bool AddMember(Member member, out string errorMessage)
        {
            // Check if all fields are filled
            if (!AreAllFieldsFilled(member, out errorMessage))
            {
                return false;
            }

            // Validate phone number
            if (!IsValidPhoneNumber(member.Phone))
            {
                errorMessage = "Please enter a valid 10-digit phone number.";
                return false;
            }

            // Validate address
            if (!IsValidAddress(member.Address))
            {
                errorMessage = "Please enter a valid address (5-100 characters, no special symbols)";
                return false;
            }

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

            errorMessage = string.Empty;
            return true;
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

        private bool IsValidAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false; // Address cannot be empty
            if (address.Length < 5 || address.Length > 100)
                return false; // Address should be between 5 and 100 characters
            if (!System.Text.RegularExpressions.Regex.IsMatch(address, @"^[a-zA-Z0-9\s,.-]+$"))
                return false; // Address can contain letters, numbers, spaces, commas, dots, and dashes

            return true;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);

        }

        private bool AreAllFieldsFilled(Member member, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(member.Name) ||
                string.IsNullOrWhiteSpace(member.Gender) ||
                string.IsNullOrWhiteSpace(member.Phone) ||
                string.IsNullOrWhiteSpace(member.Address) ||
                string.IsNullOrWhiteSpace(member.MClass))
            {
                errorMessage = "All fields are required. Please fill in all details.";
                return false;
            }

            errorMessage = ""; // No errors
            return true;
        }

    }
}