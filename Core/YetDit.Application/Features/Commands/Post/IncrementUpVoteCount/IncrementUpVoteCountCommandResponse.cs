namespace YetDit.Application.Features.Commands.Post.IncrementUpVoteCount
{
    public class IncrementUpVoteCountCommandResponse
    {
        public bool Succeeded { get; set; }
        public int NewUpVoteCount { get; set; }
    }
}
