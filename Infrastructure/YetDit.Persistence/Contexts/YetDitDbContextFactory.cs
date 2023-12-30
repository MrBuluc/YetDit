using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace YetDit.Persistence.Contexts
{
    public class YetDitDbContextFactory : IDesignTimeDbContextFactory<YetDitDbContext>
    {
        public YetDitDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<YetDitDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new YetDitDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
