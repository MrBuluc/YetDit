namespace YetDit.Application.Features.Commands.Comment.IncrementUpVoteCountComment
{
    public class IncrementUpVoteCountCommentCommandResponse
    {
        public bool Succeeded { get; set; }
        public int NewUpVoteCount { get; set; }
    }
}
