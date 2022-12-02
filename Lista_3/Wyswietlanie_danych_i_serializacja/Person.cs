using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyswietlanie_danych_i_serializacja
{
    class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string pesel { get; set; }
        

        public Person()
        {
            this.firstName = string.Empty;
            this.lastName = string.Empty;
            this.gender = string.Empty;
            this.pesel = string.Empty;
        }

        public Person(string firstName, string lastName,string plec, string pesel)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = plec;
            this.pesel = pesel;
        }

        public Person(Person person)
        {
            this.firstName = person.firstName;
            this.lastName = person.lastName;
            this.pesel = person.pesel;
            this.gender = person.gender;
        }
    }
}
