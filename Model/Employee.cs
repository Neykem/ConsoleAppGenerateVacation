namespace ConsoleAppGenerateVacation.Model
{
    public class Employee
    {
        public string Name { get; set; }
        public List<DaysVacation> DaysVacation { get; set; }

        public Employee(string name)
        {
            Name = name;
            DaysVacation = new List<DaysVacation>();
        }

        public List<DateTime> GetCountDaysVacation()
        {
            List<DateTime> vacationDays = new List<DateTime>();

            foreach (DaysVacation vacation in DaysVacation)
            {
                DateTime currentDate = vacation.StartDate;

                for (int i = 0; i < vacation.Duration; i++)
                {
                    vacationDays.Add(currentDate);
                    currentDate = currentDate.AddDays(1);
                }
            }
            return vacationDays;
        }
    }
}
