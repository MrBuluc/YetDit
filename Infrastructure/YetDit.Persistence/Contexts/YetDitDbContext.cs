using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YetDit.Domain.Common;
using YetDit.Domain.Entities;
using YetDit.Domain.Identity;

namespace YetDit.Persistence.Contexts
{
    public class YetDitDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        public YetDitDbContext(DbContextOptions<YetDitDbContext> options) : base(options) { }
        public YetDitDbContext() { }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<EntityBase<Guid>>();
            foreach (var entry in datas)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedOn = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.ModifiedOn = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
