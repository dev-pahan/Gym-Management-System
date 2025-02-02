using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
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
        public bool DoesUsernameExist(string username, out string errorMessage)
        {

            // Validate username first
            if (!IsUsernameValid(username, out errorMessage))
            {
                return false; // Return false if username validation fails
            }

            const string query = "SELECT COUNT(*) FROM UsersTbl WHERE Username = @Username";
            var parameters = new[]
            {
                new SQLiteParameter("@Username", username)
            };

            DataTable result = _database.GetData(query, parameters);

            return Convert.ToInt32(result.Rows[0][0]) > 0;
        }

        //Add new user
        public bool RegisterUser(User user, out string errorMessage)
        {
            // Validate password first
            if (!IsPasswordValid(user.Password, out errorMessage))
            {
                return false; // Return false if password validation fails
            }
            try
            {
                const string query = "INSERT INTO UsersTbl (Username, Password) VALUES (@Username, @Password)";
                var parameters = new[]
                {
                    new SQLiteParameter("@Username", user.Username),
                    new SQLiteParameter("@Password", user.Password)
                };

                _database.ExecuteCommand(query, parameters);
                errorMessage = "";
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }

            
        }

        // Error handling for password
        public bool IsPasswordValid(string password, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Password cannot be empty.";
                return false;
            }

            if (password.Length < 8)
            {
                errorMessage = "Password must be at least 8 characters long.";
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                errorMessage = "Password must contain at least one uppercase letter.";
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                errorMessage = "Password must contain at least one digit.";
                return false;
            }

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                errorMessage = "Password must contain at least one special character (e.g., @, #, $, %).";
                return false;
            }

            errorMessage = ""; // No errors
            return true;
         
        }

        // Error handling for username
        public bool IsUsernameValid(string  username, out string errorMessage)
        {
            if (username.Contains(" "))
            {
                errorMessage = "Username cannot contain spaces. Please try again!"; 
                return false;
            }

            errorMessage = ""; // No error
            return true; // Username is valid
        }
    }
}
