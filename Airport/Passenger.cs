using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Passenger
    {
        public string PassName { get; set; }
        public string PassSirname { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string ClassOfSeat { get; set; }

        //public Passenger() { }
        public Passenger(string passName, string passSirname, string nationality, string passport, string sex, string classOfSeat, DateTime dateOfBirth)
        {
            this.PassName = passName;
            this.PassSirname = passSirname;
            this.Nationality = nationality;
            this.Passport = passport;
            this.Sex = sex;
            this.ClassOfSeat = classOfSeat;
            this.DateOfBirth = dateOfBirth;
        }
    }
}
