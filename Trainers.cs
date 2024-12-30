using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class Trainers : Form
    {
        Database Con;
        public Trainers()
        {
            InitializeComponent();
            Con = new Database();
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
                if (TNameTb.Text == "" || PhoneTb.Text == "" || ExperienceTb.Text == "" || PasswordTb.Text == "" || GenderCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    string Name = TNameTb.Text;
                    string Gender = GenderCb.Text;
                    string Phone = PhoneTb.Text;
                    int Experience = Convert.ToInt32(ExperienceTb.Text);
                    string Address = AddressTb.Text;
                    string Password = PasswordTb.Text;
                    DateTime DOB = DOBTb.Value.Date;

                    string Query = "INSERT INTO TrainersTbl (TName, TGender, TDOB, TPhone, TExperience, TAddress, TPass) " +
                                   "VALUES (@TName, @Gender, @DOB, @Phone, @Experience, @Address, @Password)";

                    using (SQLiteCommand cmd = new SQLiteCommand(Query, Con.Connection))
                    {
                        cmd.Parameters.AddWithValue("@TName", Name);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@DOB", DOB);
                        cmd.Parameters.AddWithValue("@Phone", Phone);
                        cmd.Parameters.AddWithValue("@Experience", Experience);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        Con.OpenConnection();
                        cmd.ExecuteNonQuery();
                        Con.CloseConnection();

                        MessageBox.Show("Trainer Added!");
                        ShowTrainer();
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
                if (e.RowIndex >= 0 && TrainersList.Rows[e.RowIndex].Cells.Count > 0)
                {
                    DataGridViewRow selectedRow = TrainersList.Rows[e.RowIndex];

                    TNameTb.Text = selectedRow.Cells[1]?.Value?.ToString() ?? string.Empty;
                    GenderCb.Text = selectedRow.Cells[2]?.Value?.ToString() ?? string.Empty;
                    DOBTb.Value = DateTime.TryParse(selectedRow.Cells[3]?.Value?.ToString(), out DateTime dob) ? dob : DateTime.Now;
                    PhoneTb.Text = selectedRow.Cells[4]?.Value?.ToString() ?? string.Empty;
                    ExperienceTb.Text = selectedRow.Cells[5]?.Value?.ToString() ?? string.Empty;
                    AddressTb.Text = selectedRow.Cells[6]?.Value?.ToString() ?? string.Empty;
                    PasswordTb.Text = selectedRow.Cells[7]?.Value?.ToString() ?? string.Empty;

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
                    string Query = "DELETE FROM TrainersTbl WHERE TId = @TId";

                    using (SQLiteCommand cmd = new SQLiteCommand(Query, Con.Connection))
                    {
                        cmd.Parameters.AddWithValue("@TId", Key);

                        Con.OpenConnection();
                        cmd.ExecuteNonQuery();
                        Con.CloseConnection();

                        MessageBox.Show("Trainer Deleted!");
                        ShowTrainer();

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
                    string Name = TNameTb.Text;
                    string Gender = GenderCb.Text;
                    DateTime DOB = DOBTb.Value.Date;
                    string Phone = PhoneTb.Text;
                    int Experience = Convert.ToInt32(ExperienceTb.Text);
                    string Address = AddressTb.Text;
                    string Password = PasswordTb.Text;

                    string Query = "UPDATE TrainersTbl SET TName = @TName, TGender = @Gender, TDOB = @DOB, TPhone = @Phone, " +
                                   "TExperience = @Experience, TAddress = @Address, TPass = @Password WHERE TId = @TId";

                    using (SQLiteCommand cmd = new SQLiteCommand(Query, Con.Connection))
                    {
                        cmd.Parameters.AddWithValue("@TName", Name);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@DOB", DOB);
                        cmd.Parameters.AddWithValue("@Phone", Phone);
                        cmd.Parameters.AddWithValue("@Experience", Experience);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@TId", Key);

                        Con.OpenConnection();
                        cmd.ExecuteNonQuery();
                        Con.CloseConnection();

                        MessageBox.Show("Trainer Updated!");
                        ShowTrainer();

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
