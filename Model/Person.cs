using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        private DateTime _dateOfBirth { get; set; }
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (!IsValidDOB(value))
                {
                    MessageBox.Show("Trainer must be 18 years or above.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _dateOfBirth = value;
            }
        }

        public Person() { }

        public Person(int id, string name, string gender, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        //Method to validate DOB
        private bool IsValidDOB(DateTime dob)
        {
            DateTime minAllowedDOB = new DateTime(2007, 1, 1);
            return dob < minAllowedDOB;
        }
    }
}
