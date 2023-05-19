using ConsoleAppGenerateVacation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGenerateVacation.Domain.Interface
{
    interface IVacationGenerate
    {
        public List<DaysVacation> GenerateVacationEmployee();
        public DateTime GetRandomStartDate(DateTime currentDate);
    }
}
