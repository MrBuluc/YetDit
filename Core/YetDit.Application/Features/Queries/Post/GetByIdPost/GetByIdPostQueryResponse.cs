namespace YetDit.Application.Features.Queries.Post.GetByIdPost
{
    public class GetByIdPostQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UpVoteCount { get; set; }
        public string UserId { get; set; }
        public object Comments { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set;}
    }
}
