namespace YetDit.Application.Features.Queries.Comment.GetByIdComment
{
    public class GetByIdCommentQueryResponse
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public int UpVoteCount { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
