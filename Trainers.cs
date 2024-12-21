using System;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace GymManagementSystem
{
    public partial class Trainers : Form
    {
        Functions Con;
        public Trainers()
        {
            InitializeComponent();
            Con = new Functions();
            ShowTrainer(); 
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UsernameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void EditB_Click(object sender, EventArgs e)
        {

        }

        private void DeleteB_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void NameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExperienceTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddressTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowTrainer()
        {
            try
            {
                string Query = "SELECT * FROM TrainersTbl";
                TrainersList.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching trainers: {ex.Message}");
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate fields to ensure none of the required fields are empty
                if (TNameTb.Text == "" || PhoneTb.Text == "" || ExperienceTb.Text == "" || PasswordTb.Text == "" || GenderCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    // Collect form data
                    string Name = TNameTb.Text;
                    string Gender = GenderCb.Text;
                    string Phone = PhoneTb.Text;
                    int Experience = Convert.ToInt32(ExperienceTb.Text);
                    string Address = AddressTb.Text;
                    string Password = PasswordTb.Text;
                    DateTime DOB = DOBTb.Value.Date;

                    // SQL Query with parameters to insert trainer data into database
                    string Query = "INSERT INTO TrainersTbl (TName, TGender, TDOB, TPhone, TExperience, TAddress, TPass) " +
                                   "VALUES (@TName, @Gender, @DOB, @Phone, @Experience, @Address, @Password)";

                    // Use the SqlCommand with parameters
                    using (SqlCommand cmd = new SqlCommand(Query, Con.Connection))
                    {
                        // Add parameters with values from the form
                        cmd.Parameters.AddWithValue("@TName", Name);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@DOB", DOB);
                        cmd.Parameters.AddWithValue("@Phone", Phone);
                        cmd.Parameters.AddWithValue("@Experience", Experience);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        // Open connection, execute query, and close connection
                        Con.OpenConnection();
                        cmd.ExecuteNonQuery(); // Execute the insert command
                        Con.CloseConnection(); // Close the connection

                        MessageBox.Show("Trainer Added!");
                        ShowTrainer(); // Refresh the data grid view after adding a trainer
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void GenderCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DOBTb_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TrainersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Trainers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDatabaseDataSet.TrainersTbl' table. You can move, or remove it, as needed.
            this.trainersTblTableAdapter.Fill(this.gymDatabaseDataSet.TrainersTbl);

        }
    }
}
