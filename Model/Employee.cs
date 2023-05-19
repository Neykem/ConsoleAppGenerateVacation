using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGenerateVacation.Model
{
    public class Employee
    {
        public string Name { get; set; }
        public List<DaysVacation> DaysVacation { get; set; }

        public Employee(string Name) 
        {
        
        }
    }
}
