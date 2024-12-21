using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private SqlDataAdapter Sda;
        private string ConStr;

        // Constructor
        public Functions()
        {
            // Set connection string for SQL Server Express
            ConStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=GymDatabase;Integrated Security=True";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        // Open database connection
        public void OpenConnection()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
        }

        // Close database connection
        public void CloseConnection()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        // Get data (used for fetching records into DataGridView)
        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                // Use SqlDataAdapter to fill the DataTable
                Sda = new SqlDataAdapter(query, Con);
                Sda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
            return dt;
        }

        // Execute queries (used for insert, update, delete operations)
        public int SetData(string query)
        {
            int cnt = 0;
            try
            {
                // Use SqlCommand to execute query
                Cmd.CommandText = query;
                OpenConnection();
                cnt = Cmd.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing query: {ex.Message}");
            }
            return cnt;
        }

        // Property to access the connection object
        public SqlConnection Connection
        {
            get { return Con; }
        }
    }
}