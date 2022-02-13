
using RiseWebAssessment.Model;
using RiseWebAssessment.Core;
using Microsoft.EntityFrameworkCore;

namespace RiseWebAssessment.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Enums.InfoType>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Enums.InfoType>();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            modelBuilder.Entity<User>().HasKey(c => new { c.Id });
            modelBuilder.Entity<Contact>().HasKey(c => new { c.Id });            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
