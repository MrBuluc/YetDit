namespace YetDit.Application.Features.Commands.Comment.DecrementUpVoteCountComment
{
    public class DecrementUpVoteCountCommentCommandResponse
    {
        public bool Succeeded { get; set; }
        public int NewUpVoteCount { get; set; }
    }
}
