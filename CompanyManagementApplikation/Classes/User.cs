using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementApplikation.Classes
{
    class User : Person
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public User(string name, string position, decimal salary, string team, DateTime employedSince, string insurance, string username, string password) : base(name, position, salary, team, employedSince, insurance)
        {
            Username = username;
            Password = password;

            CreateTable();
        }
    }
}
