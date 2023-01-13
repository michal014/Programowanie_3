using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wyswietlanie_danych_i_serializacja
{
    [XmlRoot(ElementName = "Persons")]
    public class Person
    {
        [XmlAttribute("FirstName")]
        public string firstName { get; set; }
        [XmlAttribute("lastName")]
        public string lastName { get; set; }
        [XmlAttribute("gender")]
        public string gender { get; set; }
        [XmlAttribute("pesel")]
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
