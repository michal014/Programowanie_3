using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class UserOperations
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }

        public UserOperations()
        {
            this.id = 0;
            this.login = String.Empty;
            this.password = String.Empty;
            this.isAdmin = false;
        }
        public UserOperations(int id, string login, string password, bool isAdmin)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.isAdmin = isAdmin;
        }

        public UserOperations(UserOperations uo)
        {
            this.id = uo.id;
            this.login = uo.login;
            this.password = uo.password;
            this.isAdmin = uo.isAdmin;
        }
    }
}
