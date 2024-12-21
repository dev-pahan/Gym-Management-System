﻿using System;
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
        private void GenderCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DOBTb_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Trainers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDatabaseDataSet.TrainersTbl' table. You can move, or remove it, as needed.
            this.trainersTblTableAdapter.Fill(this.gymDatabaseDataSet.TrainersTbl);

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

        int Key = 0;
        private void TrainersList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the clicked row is valid
                if (e.RowIndex >= 0 && TrainersList.Rows[e.RowIndex].Cells.Count > 0)
                {
                    DataGridViewRow selectedRow = TrainersList.Rows[e.RowIndex];

                    // Populate input fields with the selected row's values
                    TNameTb.Text = selectedRow.Cells[1]?.Value?.ToString() ?? string.Empty;
                    GenderCb.Text = selectedRow.Cells[2]?.Value?.ToString() ?? string.Empty;
                    DOBTb.Value = DateTime.TryParse(selectedRow.Cells[3]?.Value?.ToString(), out DateTime dob) ? dob : DateTime.Now;
                    PhoneTb.Text = selectedRow.Cells[4]?.Value?.ToString() ?? string.Empty;
                    ExperienceTb.Text = selectedRow.Cells[5]?.Value?.ToString() ?? string.Empty;
                    AddressTb.Text = selectedRow.Cells[6]?.Value?.ToString() ?? string.Empty;
                    PasswordTb.Text = selectedRow.Cells[7]?.Value?.ToString() ?? string.Empty;

                    // Assign the primary key value
                    Key = string.IsNullOrWhiteSpace(TNameTb.Text) ? 0 : Convert.ToInt32(selectedRow.Cells[0]?.Value ?? "0");
                }
                else
                {
                    MessageBox.Show("Invalid selection. Please select a valid row.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Select the Trainer to Delete!");
                }
                else
                {
                    // SQL Query with parameters to delete trainer data from database based on the unique key
                    string Query = "DELETE FROM TrainersTbl WHERE TId = @TId";

                    // Use the SqlCommand with parameters
                    using (SqlCommand cmd = new SqlCommand(Query, Con.Connection))
                    {
                        // Add parameter with the unique trainer key
                        cmd.Parameters.AddWithValue("@TId", Key);

                        // Open connection, execute query, and close connection
                        Con.OpenConnection();
                        cmd.ExecuteNonQuery(); // Execute the delete command
                        Con.CloseConnection(); // Close the connection

                        MessageBox.Show("Trainer Deleted!");
                        ShowTrainer(); // Refresh the data grid view after deleting a trainer

                        // Clear the input fields after deletion
                        TNameTb.Text = "";
                        GenderCb.SelectedIndex = -1;
                        DOBTb.Value = DateTime.Now;
                        PhoneTb.Text = "";
                        ExperienceTb.Text = "";
                        AddressTb.Text = "";
                        PasswordTb.Text = "";
                        Key = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that a trainer is selected and required fields are not empty
                if (Key == 0)
                {
                    MessageBox.Show("Select the Trainer to Edit!");
                }
                else if (TNameTb.Text == "" || PhoneTb.Text == "" || ExperienceTb.Text == "" || PasswordTb.Text == "" || GenderCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    // Collect updated data from input fields
                    string Name = TNameTb.Text;
                    string Gender = GenderCb.Text;
                    DateTime DOB = DOBTb.Value.Date;
                    string Phone = PhoneTb.Text;
                    int Experience = Convert.ToInt32(ExperienceTb.Text);
                    string Address = AddressTb.Text;
                    string Password = PasswordTb.Text;

                    // SQL Query with parameters to update trainer data in the database
                    string Query = "UPDATE TrainersTbl SET TName = @TName, TGender = @Gender, TDOB = @DOB, TPhone = @Phone, " +
                                   "TExperience = @Experience, TAddress = @Address, TPass = @Password WHERE TId = @TId";

                    // Use the SqlCommand with parameters
                    using (SqlCommand cmd = new SqlCommand(Query, Con.Connection))
                    {
                        // Add parameters with updated values
                        cmd.Parameters.AddWithValue("@TName", Name);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@DOB", DOB);
                        cmd.Parameters.AddWithValue("@Phone", Phone);
                        cmd.Parameters.AddWithValue("@Experience", Experience);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@TId", Key);

                        // Open connection, execute query, and close connection
                        Con.OpenConnection();
                        cmd.ExecuteNonQuery(); // Execute the update command
                        Con.CloseConnection(); // Close the connection

                        MessageBox.Show("Trainer Updated!");
                        ShowTrainer(); // Refresh the data grid view after updating the trainer

                        // Clear input fields after update
                        TNameTb.Text = "";
                        GenderCb.SelectedIndex = -1;
                        DOBTb.Value = DateTime.Now;
                        PhoneTb.Text = "";
                        ExperienceTb.Text = "";
                        AddressTb.Text = "";
                        PasswordTb.Text = "";
                        Key = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
