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

        // Retrieve all trainers from the database
        public DataTable GetAllTrainers()
        {
            string query = "SELECT * FROM TrainersTbl";
            return _database.GetData(query);
        }

        // Add a new trainer to the database
        public bool AddTrainer(Trainer trainer, out string errorMessage)
        {
            if (!AreAllFieldsFilled(trainer, out errorMessage))
            {
                return false;
            }

            try
            {
                string query = "INSERT INTO TrainersTbl (TName, TGender, TDOB, TPhone, TAddress) " +
                               "VALUES (@TName, @Gender, @DOB, @Phone, @Address)";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@TName", trainer.Name),
                    new SQLiteParameter("@Gender", trainer.Gender),
                    new SQLiteParameter("@DOB", trainer.DateOfBirth),
                    new SQLiteParameter("@Phone", trainer.Phone),
                    new SQLiteParameter("@Address", trainer.Address)
                };

                _database.ExecuteCommand(query, parameters);
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                return HandleDatabaseException(ex, out errorMessage);
            }
        }

        // Update an existing trainer in the database
        public bool UpdateTrainer(Trainer trainer, out string errorMessage)
        {
            if (trainer.Id <= 0)
            {
                errorMessage = "Invalid trainer ID.";
                return false;
            }

            if (!AreAllFieldsFilled(trainer, out errorMessage))
            {
                return false;
            }

            try
            {
                string query = "UPDATE TrainersTbl SET TName = @TName, TGender = @Gender, TDOB = @DOB, TPhone = @Phone, " +
                               "TAddress = @Address WHERE TId = @TId";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@TId", trainer.Id),
                    new SQLiteParameter("@TName", trainer.Name),
                    new SQLiteParameter("@Gender", trainer.Gender),
                    new SQLiteParameter("@DOB", trainer.DateOfBirth),
                    new SQLiteParameter("@Phone", trainer.Phone),
                    new SQLiteParameter("@Address", trainer.Address)
                };

                _database.ExecuteCommand(query, parameters);
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                return HandleDatabaseException(ex, out errorMessage);
            }
        }

        // Delete a trainer from the database
        public bool DeleteTrainer(int trainerId, out string errorMessage)
        {
            if (trainerId <= 0)
            {
                errorMessage = "Invalid trainer ID.";
                return false;
            }

            try
            {
                string query = "DELETE FROM TrainersTbl WHERE TId = @TId";
                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@TId", trainerId)
                };

                _database.ExecuteCommand(query, parameters);
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                return HandleDatabaseException(ex, out errorMessage);
            }
        }

        // Validate that all required fields are filled
        private bool AreAllFieldsFilled(Trainer trainer, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(trainer.Name) ||
                string.IsNullOrWhiteSpace(trainer.Gender) ||
                string.IsNullOrWhiteSpace(trainer.Phone) ||
                string.IsNullOrWhiteSpace(trainer.Address))
            {
                errorMessage = "All fields are required. Please fill in all details.";
                return false;
            }

            if (!IsValidPhoneNumber(trainer.Phone))
            {
                errorMessage = "Please enter a valid 10-digit phone number.";
                return false;
            }

            if (trainer.DateOfBirth > DateTime.Now.AddYears(-18))
            {
                errorMessage = "Trainer must be at least 18 years old.";
                return false;
            }

            if (!IsValidAddress(trainer.Address))
            {
                errorMessage = "Please enter a valid address (5-100 characters, no special symbols).";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Handle database exceptions
        private bool HandleDatabaseException(Exception ex, out string errorMessage)
        {
            errorMessage = $"Database error: {ex.Message}";
            return false;
        }

        // Validate phone number format
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }

        // Validate address format
        private bool IsValidAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false;
            if (address.Length < 5 || address.Length > 100)
                return false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(address, @"^[a-zA-Z0-9\s,.-]+$"))
                return false;

            return true;
        }
    }
}

