using YetDit.Domain.Common;
using YetDit.Domain.Identity;

namespace YetDit.Domain.Entities
{
    public class Post : EntityBase<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UpVoteCount { get; set; }

        public AppUser User { get; set; }
        public Guid UserId { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
