namespace YetDit.Application.Features.Commands.Post.DecrementUpVoteCountCommand
{
    public class DecrementUpVoteCountCommandResponse
    {
        public bool Succeeded { get; set; }
        public int NewUpVoteCount { get; set; }
    }
}
