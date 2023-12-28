using MediatR;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.DecrementUpVoteCountPost
{
    public class DecrementUpVoteCountPostCommandHandler : IRequestHandler<DecrementUpVoteCountPostCommandRequest, DecrementUpVoteCountPostCommandResponse>
    {
        private readonly IPostReadRepository _readRepository;
        private readonly IPostWriteRepository _writeRepository;

        public DecrementUpVoteCountPostCommandHandler(IPostWriteRepository writeRepository, IPostReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<DecrementUpVoteCountPostCommandResponse> Handle(DecrementUpVoteCountPostCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post post = await _readRepository.GetByIdAsync(request.Id);
            if (!post.IsDeleted)
            {
                post.UpVoteCount--;
                post.ModifiedByUserId = request.UserId;
                post.ModifiedOn = DateTime.UtcNow;
                await _writeRepository.SaveAsync();
                return new()
                {
                    Succeeded = true,
                    NewUpVoteCount = post.UpVoteCount
                };
            }
            return new()
            {
                Succeeded = false
            };
        }
    }
}
