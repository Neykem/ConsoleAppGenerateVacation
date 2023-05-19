

using ConsoleAppGenerateVacation.Domain;
using ConsoleAppGenerateVacation.Domain.Interface;
using ConsoleAppGenerateVacation.Model;

namespace ConsoleAppGenerateVacation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Это конечно не хешированный словарь и генерация не работает сказать чтоб быстрее,
            //но и данные даже если в теории и будет использоваться подобноее приложение будут скорее выглядить как модель из базы данных
            //по этому мой вариант, это вариант на ООП
            List<Employee> employees = new List<Employee>
            {
                new Employee("Иванов Иван Иванович"),
                new Employee("Юлина Юлия Юлиановна"),
                new Employee("Павлов Павел Павлович"),
                new Employee("Петров Петр Петрович"),
                new Employee("Сидоров Сидор Сидорович"),
                new Employee("Георгиев Георг Георгиевич")
            };

            IVacationGenerate generator = new VacationGenerate(employees);
            generator.GenerateVacationEmployee();

            foreach (Employee employee in employees)
            {
                Console.WriteLine("Список дней для отпуска " + employee.Name);

                List<DateTime> vacationDays = employee.GetCountDaysVacation();
                int a = 0;
                foreach (DateTime vacationDay in vacationDays)
                {
                    Console.WriteLine(vacationDay.ToString("d"));
                    a++;
                }
                Console.WriteLine(a);
                Console.WriteLine();
            }
        }
    }
}