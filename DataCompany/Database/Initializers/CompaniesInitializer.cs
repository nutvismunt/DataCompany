using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCompany.Models;
using Xamarin.Forms.Internals;

namespace DataCompany.Database.Initializers
{
    public static class CompaniesInitializer
    {
        // инициализатор Компаний
        public static async Task InitializeAsync(RegistrationContext context)
        {
            if (context.Companies.Any() == false)
            {
                ICollection<string> positions = new[]
                {
                    "OOO \"Восточная Транспортная Компания\"",
                    "ТК СКОРОСТЬ",
                    "ООО \"Карго Линк\""
                };
                positions.ForEach(x => context.AddAsync(new Company {CompanyName = x}));
                await context.SaveChangesAsync();
            }
        }
    }
}