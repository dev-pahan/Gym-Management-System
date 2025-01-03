using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());


            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS UsersTbl (
            UserID INTEGER PRIMARY KEY AUTOINCREMENT,
            Username TEXT NOT NULL,
            Password TEXT NOT NULL);";

            Database db = new Database();
            try
            {
                db.ExecuteCommand(createTableQuery);
                Console.WriteLine("UsersTbl table created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating UsersTbl table: {ex.Message}");
            }

            // Hardcode a row of data into UsersTbl
            string insertQuery = "INSERT INTO UsersTbl (Username, Password, Role) VALUES (@username, @password, @role)";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@username", "testuser"),
                new SQLiteParameter("@password", "password123"), // Use hashing for real-world scenarios
            };

            try
            {
                db.ExecuteCommand(insertQuery, parameters);
                Console.WriteLine("Test user added to UsersTbl successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding test user: {ex.Message}");
            }*/
        }
    }
}
