using MediatR;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.IncrementUpVoteCount
{
    public class IncrementUpVoteCountCommandHandler : IRequestHandler<IncrementUpVoteCountCommandRequest, IncrementUpVoteCountCommandResponse>
    {
        private readonly IPostReadRepository _readRepository;
        private readonly IPostWriteRepository _writeRepository;

        public IncrementUpVoteCountCommandHandler(IPostReadRepository readRepository, IPostWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        public async Task<IncrementUpVoteCountCommandResponse> Handle(IncrementUpVoteCountCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post post = await _readRepository.GetByIdAsync(request.Id);
            post.UpVoteCount++;
            post.ModifiedOn = DateTime.UtcNow;
            post.ModifiedByUserId = request.UserId;
            await _writeRepository.SaveAsync();
            return new()
            {
                Succeeded = true,
                NewUpVoteCount = post.UpVoteCount,
            };
        }
    }
}
