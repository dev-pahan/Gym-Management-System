using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem
{
    internal class Database
    {
        public SQLiteConnection Connection { get; private set; }
        private SQLiteCommand Command;
        private SQLiteDataAdapter Adapter;

        public Database()
        {
            // Initialize the database connection using a relative path
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "gms.db");
            Connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
        }

        // Open the database connection if it is closed
        public void OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        // Close the database connection if it is open
        public void CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        // Fetch data from the database using the provided query and parameters
        public DataTable GetData(string query, SQLiteParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            try
            {
                OpenConnection();
                using (Command = new SQLiteCommand(query, Connection))
                {
                    if (parameters != null)
                    {
                        Command.Parameters.AddRange(parameters);
                    }

                    using (Adapter = new SQLiteDataAdapter(Command))
                    {
                        Adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching data: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }

        // Execute a command in the database using the provided query and parameters
        public int ExecuteCommand(string query, SQLiteParameter[] parameters = null)
        {
            int rowsAffected = 0;

            try
            {
                OpenConnection();
                Command = new SQLiteCommand(query, Connection);

                if (parameters != null)
                {
                    Command.Parameters.AddRange(parameters);
                }

                rowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing command: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }

            return rowsAffected;
        }
    }
}
