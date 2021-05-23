using DataCompany.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Xamarin.Essentials;

namespace DataCompany.Database
{
    public sealed class RegistrationContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Position> Positions { get; set; }

        public RegistrationContext()
        {
            SQLitePCL.Batteries_V2.Init();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "DataCompanyDb.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
