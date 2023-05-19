namespace ConsoleAppGenerateVacation.Domain.Interface
{
    //Интерфейс для генератора отпуско
    interface IVacationGenerate
    {
        //Сначало сделал метод более логичным 
        public void GenerateVacationEmployee();
        //Метод который генерирует рандомную дату для вычисления отпуска
        public DateTime GetRandomStartDate(DateTime currentDate);
    }
}
