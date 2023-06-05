using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementApplikation.Backend;

namespace CompanyManagementApplikation.Classes
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Team { get; set; }
        public DateTime EmployedSince { get; set; }
        public string Insurance { get; set; }

        public Person(string name, string position, decimal salary, string team, DateTime employedSince, string insurance)
        {
            Name = name;
            Position = position;
            Salary = salary;
            Team = team;
            EmployedSince = employedSince;
            Insurance = insurance;

            CreateTable();
        }

        public void CreateTable()
        {
            string query = "CREATE TABLE IF NOT EXISTS `companysim`.`employees` (\r\n  `ID` INT NOT NULL AUTO_INCREMENT,\r\n  `Name` VARCHAR(80) NOT NULL,\r\n  `Position` VARCHAR(45) NOT NULL,\r\n  `Salary` DECIMAL NOT NULL,\r\n  `Team` VARCHAR(45) NOT NULL,\r\n  `EmployedSince` VARCHAR(45) NOT NULL,\r\n  `Insurance` VARCHAR(80) NOT NULL,\r\n  `Username` VARCHAR(45) NULL,\r\n  `Password` VARCHAR(255) NULL,\r\n  PRIMARY KEY (`ID`));\r\n";
            Database database = new Database();
            database.ExecuteQuery(query);
        }
    }
}
