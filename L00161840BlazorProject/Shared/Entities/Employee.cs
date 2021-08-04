using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string PayrollReference { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PPSN { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string Phone { get; set; }
        public string NOKName { get; set; }
        public string NOKPhone { get; set; }
        public Invite Invite { get; set; }

        public Employee ShallowCopy()
        {
            return (Employee)this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                   PayrollReference == employee.PayrollReference &&
                   Forename == employee.Forename &&
                   Surname == employee.Surname &&
                   Email == employee.Email &&
                   PPSN == employee.PPSN &&
                   Address1 == employee.Address1 &&
                   Address2 == employee.Address2 &&
                   Address3 == employee.Address3 &&
                   Address4 == employee.Address4 &&
                   Address5 == employee.Address5 &&
                   Phone == employee.Phone &&
                   NOKName == employee.NOKName &&
                   NOKPhone == employee.NOKPhone;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(PayrollReference);
            hash.Add(Forename);
            hash.Add(Surname);
            hash.Add(Email);
            hash.Add(PPSN);
            hash.Add(Address1);
            hash.Add(Address2);
            hash.Add(Address3);
            hash.Add(Address4);
            hash.Add(Address5);
            hash.Add(Phone);
            hash.Add(NOKName);
            hash.Add(NOKPhone);
            return hash.ToHashCode();
        }
    }

}
