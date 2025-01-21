using System.Data;
using System.Data.SQLite;

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
    }
}
