using GymManagementSystem.Model;
using System.Data.SQLite;
using System.Data;

namespace GymManagementSystem.Controller
{
    public class ClassController
    {
        private readonly Database _database;

        public ClassController()
        {
            _database = new Database();
        }

        public DataTable GetAllClasses()
        {
            string query = "SELECT * FROM ClassTbl";
            return _database.GetData(query);
        }

        public DataTable GetTrainers()
        {
            string query = "SELECT TName FROM TrainersTbl";
            return _database.GetData(query);
        }

        public void AddClass(Class gymClass)
        {
            string query = "INSERT INTO ClassTbl (CName, CTime, CTrainer) VALUES (@CName, @CTime, @CTrainer)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CName", gymClass.CName),
                new SQLiteParameter("@CTime", gymClass.CTime),
                new SQLiteParameter("@CTrainer", gymClass.CTrainer)
            };

            _database.ExecuteCommand(query, parameters);
        }

        public void UpdateClass(Class gymClass)
        {
            string query = "UPDATE ClassTbl SET CName = @CName, CTime = @CTime, CTrainer = @CTrainer WHERE CId = @CId";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CId", gymClass.CId),
                new SQLiteParameter("@CName", gymClass.CName),
                new SQLiteParameter("@CTime", gymClass.CTime),
                new SQLiteParameter("@CTrainer", gymClass.CTrainer)
            };

            _database.ExecuteCommand(query, parameters);
        }

        public void DeleteClass(int classId)
        {
            string query = "DELETE FROM ClassTbl WHERE CId = @CId";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CId", classId)
            };

            _database.ExecuteCommand(query, parameters);
        }
    }
}