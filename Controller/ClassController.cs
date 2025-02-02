using GymManagementSystem.Model;
using System.Data.SQLite;
using System.Data;
using System;

namespace GymManagementSystem.Controller
{
    public class ClassController
    {
        private readonly Database _database;

        public ClassController()
        {
            _database = new Database();
        }

        // Retrieve all classes from the database
        public DataTable GetAllClasses()
        {
            string query = "SELECT * FROM ClassTbl";
            return _database.GetData(query);
        }

        // Retrieve all trainers from the database
        public DataTable GetTrainers()
        {
            string query = "SELECT TName FROM TrainersTbl";
            return _database.GetData(query);
        }

        // Add a new class to the database
        public bool AddClass(Class gymClass, out string errorMessage)
        {
            if (!AreAllFieldsFilled(gymClass, out errorMessage))
            {
                return false;
            }

            try
            {
                string query = "INSERT INTO ClassTbl (CName, CTime, CTrainer) VALUES (@CName, @CTime, @CTrainer)";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@CName", gymClass.CName),
                    new SQLiteParameter("@CTime", gymClass.CTime),
                    new SQLiteParameter("@CTrainer", gymClass.CTrainer)
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

        // Update an existing class in the database
        public bool UpdateClass(Class gymClass, out string errorMessage)
        {
            if (gymClass.CId <= 0)
            {
                errorMessage = "Invalid class ID.";
                return false;
            }

            if (!AreAllFieldsFilled(gymClass, out errorMessage))
            {
                return false;
            }

            try
            {
                string query = "UPDATE ClassTbl SET CName = @CName, CTime = @CTime, CTrainer = @CTrainer WHERE CId = @CId";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@CId", gymClass.CId),
                    new SQLiteParameter("@CName", gymClass.CName),
                    new SQLiteParameter("@CTime", gymClass.CTime),
                    new SQLiteParameter("@CTrainer", gymClass.CTrainer)
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

        // Delete a class from the database
        public bool DeleteClass(int classId, out string errorMessage)
        {
            if (classId <= 0)
            {
                errorMessage = "Invalid class ID.";
                return false;
            }

            try
            {
                string query = "DELETE FROM ClassTbl WHERE CId = @CId";
                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@CId", classId)
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
        private bool AreAllFieldsFilled(Class gymClass, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(gymClass.CName))
            {
                errorMessage = "Class name is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(gymClass.CTime))
            {
                errorMessage = "Class time is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(gymClass.CTrainer))
            {
                errorMessage = "Trainer name is required.";
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
    }
}

