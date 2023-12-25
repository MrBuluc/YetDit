using YetDit.Domain.Common;
using YetDit.Domain.Identity;

namespace YetDit.Domain.Entities
{
    public class Comment : EntityBase<Guid>
    {
        public string Content { get; set; }
        public int UpVoteCount { get; set; }
        public AppUser User { get; set; }
        public Guid UserId { get; set; }
    }
}
