namespace YetDit.Application.Features.Commands.Post.DecrementUpVoteCountPost
{
    public class DecrementUpVoteCountPostCommandResponse
    {
        public bool Succeeded { get; set; }
        public int NewUpVoteCount { get; set; }
    }
}
