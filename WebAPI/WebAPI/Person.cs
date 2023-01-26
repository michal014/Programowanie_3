namespace WebAPI.Controllers
{
    public class Person
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string pesel { get; set; }

        public Person() 
        {
            name = string.Empty;
            lastname = string.Empty;
            age = 0;
            pesel = string.Empty;
        }

        public Person(string name,string lastname,int age,string pesel)
        {
            this.name = name;
            this.lastname = lastname;
            this.age = age;
            this.pesel = pesel;
        }

        public Person(Person p)
        {
            this.name = p.name;
            this.lastname = p.lastname;
            this.age = p.age;
            this.pesel = p.pesel;
        }

    }
}
