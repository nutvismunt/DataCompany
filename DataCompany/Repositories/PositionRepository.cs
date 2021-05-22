using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCompany.Database;
using DataCompany.Database.Initializers;
using DataCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace DataCompany.Repositories
{
    public class PositionRepository
    {
        private readonly RegistrationContext _context;

        public PositionRepository()
        {
            _context = new RegistrationContext();
        }

        public async void Create(Position position)
        {
            using (_context)
            {
                _context.Add(position);
                await _context.SaveChangesAsync();
            }
        }

        public async void Update(Position position)
        {
            using (_context)
            {
                _context.Update(position);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Position>> GetPositions()
        {
            return await _context.Positions.ToListAsync();
        }

        public Position GetMember(long position)
        {
            return _context.Positions.FirstOrDefault(m => m.Id == position);
        }

        public async void Delete(Position position)
        {
            using (_context)
            {
                _context.Remove(position);
                await _context.SaveChangesAsync();
            }
        }

        public async void DeleteMany(Position[] positions)
        {
            using (_context)
            {
                _context.RemoveRange(positions);
                await _context.SaveChangesAsync();
            }
        }
        
        public async void InitializeDatabase()
        {
            await PositionsInitializer.InitializeAsync(_context);
        }
    }
}