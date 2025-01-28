using System;

namespace GymManagementSystem.Model
{
    public class Member : Person
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public string MembershipStatus { get; set; }
        public string MClass { get; set; } // New Property for Member's Class

        public Member() { }

        public Member(int id, string name, string gender, DateTime dateOfBirth, string phone, string address, string membershipStatus, string mClass)
            : base(id, name, gender, dateOfBirth)
        {
            Phone = phone;
            Address = address;
            MembershipStatus = membershipStatus;
            MClass = mClass;
        }
    }
}
