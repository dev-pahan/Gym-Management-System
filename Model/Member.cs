using System;

namespace GymManagementSystem.Model
{
    public class Member : Person
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public string MembershipStatus { get; set; } 
        public int ClassId { get; set; } 

        public Member() { }

        public Member(int id, string name, string gender, DateTime dateOfBirth, string phone, string address, string membershipStatus, int classId)
            : base(id, name, gender, dateOfBirth)
        {
            Phone = phone;
            Address = address;
            MembershipStatus = membershipStatus;
            ClassId = classId;
        }
    }
}
