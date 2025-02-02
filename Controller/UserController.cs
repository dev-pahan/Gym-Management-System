using System;
using System.Data;
using System.Data.SQLite;
using Guna.UI2.AnimatorNS;
using GymManagementSystem.Model;

namespace GymManagementSystem.Controller
{
    public class UserController
    {
        private readonly Database _database;

        public UserController()
        {
            _database = new Database();
        }

        public bool RegisterUser(User user, out string errorMessage)
        {
            if (!AreAllFieldsFilled(user, out errorMessage))
            {
                return false;
            }

            if (IsUsernameTaken(user.Username))
            {
                errorMessage = "Username already exists.";
                return false;
            }

            try
            {
                string query = "INSERT INTO UsersTbl (Username, Password, Role) VALUES (@Username, @Password, @Role)";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Username", user.Username),
                    new SQLiteParameter("@Password", user.Password),
                    new SQLiteParameter("@Role", user.Role)
                };

                _database.ExecuteCommand(query, parameters);
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                return HandleDatabaseException(ex, out errorMessage);
            }
        }

        private bool AreAllFieldsFilled(User user, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                errorMessage = "Username is required.";
                return false;
            }
            if (user.Username.Length < 5 || user.Username.Length > 20)
            {
                errorMessage = "Username must be between 5 and 20 characters.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                errorMessage = "Password is required.";
                return false;
            }
            if (user.Password.Length < 8)
            {
                errorMessage = "Password must be at least 8 characters long.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Role))
            {
                errorMessage = "Role is required.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        private bool IsUsernameTaken(string username)
        {
            string query = "SELECT COUNT(*) FROM UsersTbl WHERE Username = @Username";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Username", username)
            };

            int count = Convert.ToInt32(_database.GetData(query, parameters).Rows[0][0]);
            return count > 0;
        }

        private bool HandleDatabaseException(Exception ex, out string errorMessage)
        {
            errorMessage = $"Database error: {ex.Message}";
            return false;
        }

        public User AuthenticateUser(string username, string password, out string errorMessage)
        {
            try
            {
                string query = "SELECT * FROM UsersTbl WHERE Username = @Username AND Password = @Password";
                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Username", username),
                    new SQLiteParameter("@Password", password)
                };

                DataTable result = _database.GetData(query, parameters);

                if (result.Rows.Count == 1)
                {
                    DataRow row = result.Rows[0];
                    User user = new User
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Username = row["Username"].ToString(),
                        Password = row["Password"].ToString(),
                        Role = row["Role"].ToString()
                    };
                    errorMessage = string.Empty;
                    return user;
                }
                else
                {
                    errorMessage = "Invalid username or password.";
                    return null;
                }
            }
            catch (SQLiteException ex)
            {
                errorMessage = $"Database error: {ex.Message}";
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = $"An unexpected error occurred: {ex.Message}";
                return null;
            }
        }
    }
}

