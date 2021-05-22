using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCompany.Models;

namespace DataCompany.Database.Initializers
{
    public class WorkersInitializer
    {
        public static async Task InitializeAsync(RegistrationContext context)
        {

            var birthDate = new DateTime(1970, 1, 1);
            
            if (context.Workers.Any() == false)
            {
                var workers = new List<Worker>
                {
                    new Worker
                    {
                        Name = "Алексей",
                        Surname = "Рогозин",
                        Patronymic = "Иванович",
                        BirthDate = birthDate.AddDays(1000),
                        PhoneNumber = "+7(800)555-35-35",
                        WhenAdded = DateTime.Now,
                        CompanyId = 1,
                        PositionId = 1
                    },
                    new Worker
                    {
                        Name = "Богдан",
                        Surname = "Енотов",
                        Patronymic = "Павлович",
                        BirthDate = birthDate.AddDays(900),
                        PhoneNumber = "+7(900)355-95-25",
                        WhenAdded = DateTime.Now,
                        CompanyId = 1,
                        PositionId = 2
                    },
                    new Worker
                    {
                        Name = "Наталья",
                        Surname = "Есенина",
                        Patronymic = "Александровна",
                        BirthDate = birthDate.AddDays(3400),
                        PhoneNumber = "+7(920)375-92-93",
                        WhenAdded = DateTime.Now,
                        CompanyId = 1,
                        PositionId = 3
                    },
                    new Worker
                    {
                        Name = "Карина",
                        Surname = "Синицина",
                        Patronymic = "Ибрагимовна",
                        BirthDate = birthDate.AddDays(5100),
                        PhoneNumber = "+7(941)971-22-12",
                        WhenAdded = DateTime.Now,
                        CompanyId = 2,
                        PositionId = 4
                    },
                    new Worker
                    {
                        Name = "Мария",
                        Surname = "Виноградова",
                        Patronymic = "Васильевна",
                        BirthDate = birthDate.AddDays(9400),
                        PhoneNumber = "+7(990)351-64-30",
                        WhenAdded = DateTime.Now,
                        CompanyId = 1,
                        PositionId = 2
                    },
                    new Worker
                    {
                        Name = "Даниил",
                        Surname = "Попов",
                        Patronymic = "Патрисиевич",
                        BirthDate = birthDate.AddDays(8701),
                        PhoneNumber = "+7(989)445-42-53",
                        WhenAdded = DateTime.Now,
                        CompanyId = 1,
                        PositionId = 6
                    },
                    new Worker
                    {
                        Name = "Ярослав",
                        Surname = "Лебедев",
                        Patronymic = "Ярославович",
                        BirthDate = birthDate.AddDays(10400),
                        PhoneNumber = "+7(943)095-02-90",
                        WhenAdded = DateTime.Now,
                        CompanyId = 3,
                        PositionId = 5
                    },
                    new Worker
                    {
                        Name = "Кристина",
                        Surname = "Черкасова",
                        Patronymic = "Константиновна",
                        BirthDate = birthDate.AddDays(5420),
                        PhoneNumber = "+7(999)472-32-33",
                        WhenAdded = DateTime.Now,
                        CompanyId = 3,
                        PositionId = 1
                    },
                    new Worker
                    {
                        Name = "Анастасия",
                        Surname = "Осипова",
                        Patronymic = "Ильнаровна",
                        BirthDate = birthDate.AddDays(1230),
                        PhoneNumber = "+7(990)353-65-73",
                        WhenAdded = DateTime.Now,
                        CompanyId = 1,
                        PositionId = 4
                    },
                    new Worker
                    {
                        Name = "Ибрагим",
                        Surname = "Макаров",
                        Patronymic = "Рашитович",
                        BirthDate = birthDate.AddDays(7590),
                        PhoneNumber = "+7(985)435-42-73",
                        WhenAdded = DateTime.Now,
                        CompanyId = 2,
                        PositionId = 7
                    }
                };

                await context.AddRangeAsync(workers);
                await context.SaveChangesAsync();
            }
        }
    }
}