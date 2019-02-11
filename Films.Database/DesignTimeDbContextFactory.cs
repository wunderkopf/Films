using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Films.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseNpgsql("Host=192.168.1.10;Port=5432;Database=film;Username=film;Password=password");

            return new ApplicationContext(builder.Options);
        }
    }
}
