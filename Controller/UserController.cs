using System;
using System.Data;
using System.Data.SQLite;
using Guna.UI2.AnimatorNS;
using GymManagementSystem.Model;

namespace GymManagementSystem.Controller
{
    public class UserController
    {
        // Instance of the Database class to handle database operations
        private readonly Database _database;

        // Constructor to initialize the Database instance
        public UserController()
        {
            _database = new Database();
        }

        // Method to register a new user
        public bool RegisterUser(User user, out string errorMessage)
        {
            // Check if all required fields are filled
            if (!AreAllFieldsFilled(user, out errorMessage))
            {
                return false;
            }

            // Check if the username is already taken
            if (IsUsernameTaken(user.Username))
            {
                errorMessage = "Username already exists.";
                return false;
            }

            try
            {
                // SQL query to insert a new user into the UsersTbl table
                string query = "INSERT INTO UsersTbl (Username, Password, Role) VALUES (@Username, @Password, @Role)";

                // Parameters for the SQL query
                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Username", user.Username),
                    new SQLiteParameter("@Password", user.Password),
                    new SQLiteParameter("@Role", user.Role)
                };

                // Execute the SQL command
                _database.ExecuteCommand(query, parameters);
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                // Handle any database exceptions
                return HandleDatabaseException(ex, out errorMessage);
            }
        }

        // Method to check if all required fields are filled
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

        // Method to check if the username is already taken
        private bool IsUsernameTaken(string username)
        {
            // SQL query to count the number of users with the given username
            string query = "SELECT COUNT(*) FROM UsersTbl WHERE Username = @Username";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Username", username)
            };

            // Execute the query and get the count
            int count = Convert.ToInt32(_database.GetData(query, parameters).Rows[0][0]);
            return count > 0;
        }

        // Method to handle database exceptions
        private bool HandleDatabaseException(Exception ex, out string errorMessage)
        {
            errorMessage = $"Database error: {ex.Message}";
            return false;
        }

        // Method to authenticate a user
        public User AuthenticateUser(string username, string password, out string errorMessage)
        {
            try
            {
                // SQL query to select a user with the given username and password
                string query = "SELECT * FROM UsersTbl WHERE Username = @Username AND Password = @Password";
                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Username", username),
                    new SQLiteParameter("@Password", password)
                };

                // Execute the query and get the result
                DataTable result = _database.GetData(query, parameters);

                // Check if a user is found
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