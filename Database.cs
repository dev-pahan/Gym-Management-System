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
            // Use a relative path for the database
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "gms.db");
            Connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
        }

        // Method to open a connection
        public void OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        // Method to close a connection
        public void CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        // Method to fetch data
        public DataTable GetData(string query)
        {
            try
            {
                OpenConnection();
                DataTable dt = new DataTable();
                Adapter = new SQLiteDataAdapter(query, Connection);
                Adapter.Fill(dt);
                CloseConnection();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching data: {ex.Message}");
            }
        }

        // Method to execute a command
        public void ExecuteCommand(string query, SQLiteParameter[] parameters = null)
        {
            try
            {
                OpenConnection();
                Command = new SQLiteCommand(query, Connection);

                if (parameters != null)
                {
                    Command.Parameters.AddRange(parameters);
                }

                Command.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing command: {ex.Message}");
            }
        }
    }
}
