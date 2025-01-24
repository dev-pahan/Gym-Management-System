using GymManagementSystem.Model;
using System.Data.SQLite;
using System.Data;

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

        public void AddTrainer(Trainer trainer)
        {
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

            _database.ExecuteCommand(query, parameters);
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
    }
}
