using Microsoft.AspNetCore.Identity;
using YetDit.Domain.Common;
using YetDit.Domain.Entities;
using YetDit.Domain.Enums;

namespace YetDit.Domain.Identity
{
    public class AppUser : IdentityUser<Guid>, IEntityBase<Guid>, ICreatedOn, IModifiedOn, IDeletedOn
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public string CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
        public string? DeletedByUserId { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
