using System;

namespace GymManagementSystem.Model
{
    public class Class
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public string CTime { get; set; }
        public string CTrainer { get; set; }

        public Class() { }

        public Class(int id, string name, string time, string trainer)
        {
            CId = id;
            CName = name;
            CTime = time;
            CTrainer = trainer;
        }
    }
}