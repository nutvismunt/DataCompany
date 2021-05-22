using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCompany.Database;
using DataCompany.Database.Initializers;
using DataCompany.Models;
using DataCompany.Services;
using Microsoft.EntityFrameworkCore;

namespace DataCompany.Repositories
{
    public class WorkerRepository
    {
        private readonly RegistrationContext _context;

        public WorkerRepository()
        {
            _context = new RegistrationContext();
        }

        public async void Create(Worker member)
        {
            using (_context)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
            }
        }

        public async void Update(Worker member)
        {
            using (_context)
            {
                _context.Update(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Worker>> GetWorkers()
        {
            return await _context.Workers.ToListAsync();
        }

        public Worker GetMember(Worker member)
        {
            return _context.Workers.FirstOrDefault(m => m.Id == member.Id);
        }

        public async void Delete(Worker member)
        {
            using (_context)
            {
                _context.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        public async void DeleteMany(Worker[] forms)
        {
            using (_context)
            {
                _context.RemoveRange(forms);
                await _context.SaveChangesAsync();
            }
        }

        public List<string> IsDataValid(Worker form)
        {
            var errors = new List<string>();
            errors.Add("Имя;" + form.Name.ValidateLength(30, 1));
            errors.Add("Фамилия;" + form.Surname.ValidateLength(30, 1));
            errors.Add("Отчество;" + form.Patronymic.ValidateLength(30, 1));
            errors.Add("Дата рождения;" + form.BirthDate.Date.ToString().ValidateAge());
            return errors;
        }
        
        public async void InitializeDatabase()
        {
            await WorkersInitializer.InitializeAsync(_context);
        }
    }
}