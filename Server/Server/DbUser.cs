using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTorrent
{
    class DbUser
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RegistrationDate { get; set; }

        public DbUser(int id, string username, string password, string registrationDate)
        {
            IdUser = id;
            UserName = username;
            Password = password;
            RegistrationDate = registrationDate;
        }
    }
}
