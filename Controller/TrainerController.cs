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

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(trainer.Name) ||
                string.IsNullOrWhiteSpace(trainer.Gender) ||
                string.IsNullOrWhiteSpace(trainer.Phone) ||
                string.IsNullOrWhiteSpace(trainer.Address))
            {
                errorMessage = "All fields are required. Please fill in all details.";
                return false;
            }

            // Validate phone number
            if (!IsValidPhoneNumber (trainer.Phone))
            {
                errorMessage = "Please enter a valid 10-digit phone number.";
                return false;
            }

            // Validate the date of birth (Trainer must be 18 or older)
            if (trainer.DateOfBirth > DateTime.Now.AddYears(-18))
            {
                errorMessage = "Trainer must be at least 18 years old.";
                return false;
            }

            // Validate address
            if (!IsValidAddress(trainer.Address))
            {
                errorMessage = "Please enter a valid address (5-100 characters, no special symbols)";
                return false;
            }

            string query = "INSERT INTO TrainersTbl (TName, TGender, TDOB, TPhone, TAddress) " +
                           "VALUES (@TName, @Gender, @DOB, @Phone, @Address)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@TName", trainer.Name),
                new SQLiteParameter("@Gender", trainer.Gender),
                new SQLiteParameter("@DOB", trainer.DateOfBirth),
                new SQLiteParameter("@Phone", trainer.Phone),
                new SQLiteParameter("@Address", trainer.Address),
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
                           "TAddress = @Address WHERE TId = @TId";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@TName", trainer.Name),
                new SQLiteParameter("@Gender", trainer.Gender),
                new SQLiteParameter("@DOB", trainer.DateOfBirth),
                new SQLiteParameter("@Phone", trainer.Phone),
                new SQLiteParameter("@Address", trainer.Address),
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
        private bool IsValidAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false; // Address cannot be empty
            if (address.Length < 5 || address.Length > 100)
                return false; // Address should be between 5 and 100 characters
            if (!System.Text.RegularExpressions.Regex.IsMatch(address, @"^[a-zA-Z0-9\s,.-]+$"))
                return false; // Address can contain letters, numbers, spaces, commas, dots, and dashes

            return true;
        }
    }
}
