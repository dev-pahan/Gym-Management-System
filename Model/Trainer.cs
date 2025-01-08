using GymManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.Model
{
    public class Trainer : Person
    {
        public string Phone { get; set; }
        public int Experience { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public Trainer() { }

        public Trainer(int id, string name, string gender, DateTime dateOfBirth, string phone, int experience, string address, string password)
            : base(id, name, gender, dateOfBirth)
        {
            Phone = phone;
            Experience = experience;
            Address = address;
            Password = password;
        }
    }
}