using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace WebApp.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var b = configuration.GetConnectionString("sqlConnection");
            var builder = new DbContextOptionsBuilder<RepositoryContext>().
                UseSqlServer(configuration.GetConnectionString("sqlConnection"), c => c.MigrationsAssembly("Auth"));
            
            return new RepositoryContext(builder.Options);
        }
    }
}
