using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int ID;
        private string firstName;
        private string lastName;
        private DateTime birthdate;
        private int age;
        public List<Reward> UserRewards { get; set; }
        public User()
        {
            ID = IDGenerator.GetID();
        }

        public User(int id, string fname, string lname, DateTime bdate)
        {
            ID = id;
            FirstName = fname;
            LastName = lname;
            Birthdate = bdate;
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {

                if (value.Length <= 50)
                    firstName = value;
            }

        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length <= 50)
                    lastName = value;
            }

        }
        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                if (value <= DateTime.Now && (DateTime.Now.Year - value.Year) <= 150)
                    birthdate = value;
            }
        }
        public int GetAge(DateTime BirthDate)
        {
            int YearsPassed = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
            {
                YearsPassed--;
            }
            return YearsPassed;
        }
        public int Age
        {
            get
            {
                int YearsPassed = DateTime.Now.Year - Birthdate.Year;
                if (DateTime.Now.Month < Birthdate.Month || (DateTime.Now.Month == Birthdate.Month && DateTime.Now.Day < Birthdate.Day))
                {
                    YearsPassed--;
                }
                return YearsPassed;
                //return age = GetAge(Birthdate);
            }
        }
    }
}
