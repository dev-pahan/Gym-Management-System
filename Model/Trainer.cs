using System;

namespace GymManagementSystem.Model
{
    public class Trainer : Person
    {
        public string Phone { get; set; }
        public string Address { get; set; }

        public Trainer() { }

        public Trainer(int id, string name, string gender, DateTime dateOfBirth, string phone, string address)
            : base(id, name, gender, dateOfBirth)
        {
            Phone = phone;
            Address = address;
        }
    }
}