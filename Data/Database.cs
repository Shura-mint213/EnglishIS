using Microsoft.EntityFrameworkCore;
using Models.Database;
using Static.Static;

namespace Data
{
    public class Database : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public Database() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(SettingsApp.ConnectionString);
        }
    }
}