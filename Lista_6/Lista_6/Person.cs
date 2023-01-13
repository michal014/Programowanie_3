using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_6
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PESEL { get; set; }

        public Person() 
        {
            this.Id = 0;
            this.FirstName= string.Empty;
            this.LastName= string.Empty;
            this.Gender = string.Empty;
            this.PESEL = string.Empty;
        }

        public Person(int Id,string FirstName,string LastName,string gender,string PESEL)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = gender;
            this.PESEL = PESEL;
        }

        public Person(Person p)
        {
            this.Id = p.Id;
            this.FirstName = p.FirstName;
            this.LastName = p.LastName;
            this.Gender = p.Gender;
            this.PESEL = p.PESEL;
        }


    }
}
