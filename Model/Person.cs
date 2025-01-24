using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person() { }

        public Person(int id, string name, string gender, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }
    }
}
