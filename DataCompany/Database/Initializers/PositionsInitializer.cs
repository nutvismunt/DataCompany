using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCompany.Models;
using Xamarin.Forms.Internals;

namespace DataCompany.Database.Initializers
{
    public static class PositionsInitializer
    {
        // инициализатор Должностей
        public static async Task InitializeAsync(RegistrationContext context)
        {

            if (context.Positions.Any() == false)
            {
                ICollection<string> positions = new[]
                {
                    "Директор",
                    "Менеджер",
                    "Секретарь",
                    "Документовед",
                    "Администратор",
                    "Дизайнер",
                    "Программист",
                    "Бухгалтер"
                };
                
                positions.ForEach(x => context.AddAsync(new Position {PositionName = x}));
                await context.SaveChangesAsync();
            }
        }
    }
}