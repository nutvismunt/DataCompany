using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCompany.Database;
using DataCompany.Database.Initializers;
using DataCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace DataCompany.Repositories
{
    public class CompanyRepository
    {
        private readonly RegistrationContext _context;

        public CompanyRepository()
        {
            _context = new RegistrationContext();
        }

        public async void Create(Company company)
        {
            using (_context)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
            }
        }

        public async void Update(Company company)
        {
            using (_context)
            {
                _context.Update(company);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Company>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public Company GetCompany(long company)
        {
            return _context.Companies.FirstOrDefault(m => m.Id == company);
        }

        public async void Delete(Company company)
        {
            using (_context)
            {
                _context.Remove(company);
                await _context.SaveChangesAsync();
            }
        }

        public async void DeleteMany(Company[] companies)
        {
            using (_context)
            {
                _context.RemoveRange(companies);
                await _context.SaveChangesAsync();
            }
        }
        public async void InitializeDatabase()
        {
            await CompaniesInitializer.InitializeAsync(_context);
        }
    }
}