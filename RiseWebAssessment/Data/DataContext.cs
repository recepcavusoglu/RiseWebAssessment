
using RiseWebAssessment.Model;
using RiseWebAssessment.Core;
using Microsoft.EntityFrameworkCore;

namespace RiseWebAssessment.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //TODO: can this Enum be better?
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(c => new { c.Id });
            modelBuilder.Entity<Contact>().HasKey(c => new { c.Id });
            modelBuilder.HasPostgresEnum<Enums.InfoType>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
