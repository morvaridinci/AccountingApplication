using AccountingApplication.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountingApplication.Persistance.Context
{
    public class DatabaseContext : IdentityDbContext<User, Role, Guid>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
             .HasMany(u => u.Companies)
             .WithMany(c => c.Users)
             .UsingEntity<UserCompany>(
                 j => j.ToTable("UsersCompanies")
                       .HasKey(t => new { t.UserId, t.CompanyId })
             );
        }
    }
}
