using System;

namespace DataCompany.Services
{
    public static class RandonNaming
    {
        /// <summary>
        /// Выдает рандомные мужские имена.
        /// </summary>
        /// <returns>Фамилия, имя, отчество.</returns>
        public static (string, string, string) MaleNames()
        {
            var names = new[]
            {
                "Иван",
                "Григорий",
                "Али",
                "Алексей",
                "Егор",
                "Денис",
                "Давид",
                "Елисей",
                "Константин",
                "Михаил"
            };
            var patronymics = new[]
            {
                "Федосиевич",
                "Климентович",
                "Андроникович",
                "Иванович",
                "Гордеевич",
                "Макарович",
                "Никитевич",
                "Иосифович",
                "Мартьянович",
                "Натанович"
            };
            var surnames = new[]
            {
                "Кривоухов",
                "Краевич",
                "Мирсиянов",
                "Маюров",
                "Кобонов",
                "Муравьёв",
                "Новичков",
                "Лягушкин",
                "Павлов",
                "Мартюшов"
            };

            Random random = new Random();

            string name = names[random.Next(0, 10)],
                surname = surnames[random.Next(0, 10)],
                patronymic = patronymics[random.Next(0, 10)];
            
            return (surname, name, patronymic);
        }
        
        /// <summary>
        /// Выдает рандомные женские имена.
        /// </summary>
        /// <returns>Фамилия, имя, отчество.</returns>
        public static (string, string, string) FemaleNames()
        {
            var names = new[]
            {
                "Елизавета",
                "Кристина", 
                "Александра", 
                "Мия", 
                "Анна", 
                "Варвара", 
                "Мария", 
                "Ксения", 
                "София",
                "Таисия"
            };
            var patronymics = new[]
            {
                "Елисеевна",
                "Никифоровна",
                "Викторовна",
                "Карловна",
                "Эрнестовна",
                "Тимофеевна",
                "Леонидовна",
                "Иларионовна"
            };
            var surnames = new[]
            {
                "Петрищева",
                "Подшивалова",
                "Подколодная",
                "Мичурина",
                "Рожкова",
                "Чупракова",
                "Бубнова",
                "Синицына",
                "Чендева",
                "Сысоева"
            };

            Random random = new Random();

            string name = names[random.Next(0, 9)],
                surname = surnames[random.Next(0, 9)],
                patronymic = patronymics[random.Next(0, 9)];
            
            return (surname, name, patronymic);
        }
    }
}