using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YetDit.Domain.Common;
using YetDit.Domain.Entities;
using YetDit.Domain.Identity;

namespace YetDit.Persistence.Contexts
{
    public class YetDitDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public YetDitDbContext(DbContextOptions<YetDitDbContext> options) : base(options) { }
        public YetDitDbContext() { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }


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
                }; ;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
