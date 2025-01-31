using GymManagementSystem.Model;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System;
using System.Net.Sockets;

namespace GymManagementSystem.Controller
{
    public class TrainerController
    {
        private readonly Database _database;

        public TrainerController()
        {
            _database = new Database();
        }

        public DataTable GetAllTrainers()
        {
            string query = "SELECT * FROM TrainersTbl";
            return _database.GetData(query);
        }

        public bool AddTrainer(Trainer trainer, out string errorMessage)
        {
            //Validate phone number
            if (!IsValidPhoneNumber (trainer.Phone))
            {
                errorMessage = "Please enter a valid 10-digit phone number.";
                return false;
            }

            //Validate the date of birth (Trainer must be 18 or older)
            if (trainer.DateOfBirth > DateTime.Now.AddYears(-18))
            {
                errorMessage = "Trainer must be at least 18 years old.";
                return false;
            }

            string query = "INSERT INTO TrainersTbl (TName, TGender, TDOB, TPhone, TExperience, TAddress, TPass) " +
                           "VALUES (@TName, @Gender, @DOB, @Phone, @Experience, @Address, @Password)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@TName", trainer.Name),
                new SQLiteParameter("@Gender", trainer.Gender),
                new SQLiteParameter("@DOB", trainer.DateOfBirth),
                new SQLiteParameter("@Phone", trainer.Phone),
                new SQLiteParameter("@Experience", trainer.Experience),
                new SQLiteParameter("@Address", trainer.Address),
                new SQLiteParameter("@Password", trainer.Password)
            };

            //Exevute the command to insert the trainer into the database
            _database.ExecuteCommand(query, parameters);

            //Return success and clear the error message
            errorMessage = string.Empty;
            return true;

        }

        public void UpdateTrainer(Trainer trainer)
        {
            string query = "UPDATE TrainersTbl SET TName = @TName, TGender = @Gender, TDOB = @DOB, TPhone = @Phone, " +
                           "TExperience = @Experience, TAddress = @Address, TPass = @Password WHERE TId = @TId";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@TName", trainer.Name),
                new SQLiteParameter("@Gender", trainer.Gender),
                new SQLiteParameter("@DOB", trainer.DateOfBirth),
                new SQLiteParameter("@Phone", trainer.Phone),
                new SQLiteParameter("@Experience", trainer.Experience),
                new SQLiteParameter("@Address", trainer.Address),
                new SQLiteParameter("@Password", trainer.Password),
                new SQLiteParameter("@TId", trainer.Id)
            };

            _database.ExecuteCommand(query, parameters);
        }

        public void DeleteTrainer(int trainerId)
        {
            string query = "DELETE FROM TrainersTbl WHERE TId = @TId";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@TId", trainerId)
            };

            _database.ExecuteCommand(query, parameters);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);

        }
    }
}
