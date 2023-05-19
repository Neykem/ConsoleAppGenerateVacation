using ConsoleAppGenerateVacation.Domain.Interface;
using ConsoleAppGenerateVacation.Model;

namespace ConsoleAppGenerateVacation.Domain
{
    //Класс отвечает за генерацию отпуска для списка сотрудников
    public class VacationGenerate : IVacationGenerate
    {
        public List<Employee> _employees { get; private set; }
        private readonly Random _random;

        public VacationGenerate(List<Employee> employees)
        {
            this._employees = employees;
            _random = new Random();
        }
        //Метод устонавливает новое знаения для выборки сотрудников
        public void SetNewListEmployee(List<Employee> employees)
        {
            _employees = employees;
        }
        //Метод генерирует сам отпуск для всех сотрудников переданого ему ранее, решил сделать так, чтобы обязать инициализировать именно для сотрудников
        public void GenerateVacationEmployee()
        {
            foreach (Employee employee in _employees)
            {
                //Ставим дату начало года
                DateTime currentDate = DateTime.Parse("01.01.2023");
                //Ставим значение на классический отпуск в 28 дней, чтоб не повадно было
                int remainingDays = 28;
                int vacationDuration = 0;
                while (remainingDays > 0)
                {
                    if (remainingDays != 7)
                    {
                        vacationDuration = 7;
                    }
                    else
                    {
                        vacationDuration = _random.Next(1, Math.Min(remainingDays, 15)) <= 7 ? 7 : 14;
                    }

                    DateTime startDate = GetRandomStartDate(currentDate);

                    DaysVacation vacation = new DaysVacation
                    {
                        StartDate = startDate,
                        Duration = vacationDuration
                    };
                    employee.DaysVacation.Add(vacation);

                    currentDate = startDate.AddDays(vacationDuration);
                    remainingDays -= vacationDuration;
                }
            }
        }
        public DateTime GetRandomStartDate(DateTime currentDate)
        {
            //Все никак не мог придумать как брать рамки одного года, поэтому придумал просто брать период после январских праздников и до середины года  
            DateTime minDate = currentDate.AddDays(10);
            DateTime maxDate = currentDate.AddDays(100);

            int daysDifference = (int)(maxDate - minDate).TotalDays;
            int randomDays = _random.Next(daysDifference);

            return minDate.AddDays(randomDays);
        }
    }
}
