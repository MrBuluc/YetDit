using MediatR;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.DecrementUpVoteCountCommand
{
    public class DecrementUpVoteCountCommandHandler : IRequestHandler<DecrementUpVoteCountCommandRequest, DecrementUpVoteCountCommandResponse>
    {
        private readonly IPostReadRepository _readRepository;
        private readonly IPostWriteRepository _writeRepository;

        public DecrementUpVoteCountCommandHandler(IPostWriteRepository writeRepository, IPostReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<DecrementUpVoteCountCommandResponse> Handle(DecrementUpVoteCountCommandRequest request, CancellationToken cancellationToken)
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
