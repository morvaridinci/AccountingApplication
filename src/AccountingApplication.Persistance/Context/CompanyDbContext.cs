using AccountingApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AccountingApplication.Persistance.Context
{
    public class CompanyDbContext : DbContext
    {
        private string _connectionString = "";
        private readonly DatabaseContext _databaseContext;
        
        public CompanyDbContext(Company company = null)
        {
            if (company != null)
            {
                if (company != null && company.UserId.HasValue)
                    _connectionString =
                        $"Server ={company.ServerName};" +
                        $" Database ={company.DatabaseName};" +
                        $" Trusted_Connection = True;" +
                        $" TrustServerCertificate = True";
                else
                    _connectionString =
                        $"Server ={company.ServerName};" +
                        $"Database ={company.DatabaseName}; " +
                        $"User Id={company.UserId};" +
                        $"Password={company.Password};" +
                        $"Trusted_Connection = True; " +
                        $"TrustServerCertificate = True";
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            public CompanyDbContext CreateDbContext(string[] args)
            {
                return new CompanyDbContext();
            }
        }
    }
}
