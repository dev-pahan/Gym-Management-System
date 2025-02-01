using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementSystem.Model;

namespace GymManagementSystem.Controller
{
    public class RegisterController
    {
        private readonly Database _database;

        public RegisterController()
        {
            _database = new Database();
        }

        //Check if username exists
        public bool DoesUsernameExist(string username)
        {
            const string query = "SELECT COUNT(*) FROM UsersTbl WHERE Username = @Username";
            var parameters = new[]
            {
                new SQLiteParameter("@Username", username)
            };

            DataTable result = _database.GetData(query, parameters);

            return Convert.ToInt32(result.Rows[0][0]) > 0;
        }

        //Add new user
        public void RegisterUser(User user)
        {
            const string query = "INSERT INTO UsersTbl (Username, Password) VALUES (@Username, @Password)";
            var parameters = new[]
            {
                new SQLiteParameter("@Username", user.Username),
                new SQLiteParameter("@Password", user.Password)
            };

            _database.ExecuteCommand(query, parameters);
        }
    }
}
