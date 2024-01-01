using MediatR;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.DecrementUpVoteCountPost
{
    public class DecrementUpVoteCountPostCommandHandler : IRequestHandler<DecrementUpVoteCountPostCommandRequest, DecrementUpVoteCountPostCommandResponse>
    {
        private readonly IPostReadRepository _readRepository;
        private readonly IPostWriteRepository _writeRepository;
        private readonly IUserService _userService;

        public DecrementUpVoteCountPostCommandHandler(IPostWriteRepository writeRepository, IPostReadRepository readRepository, IUserService userService)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _userService = userService;
        }

        public async Task<DecrementUpVoteCountPostCommandResponse> Handle(DecrementUpVoteCountPostCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post? post = await _readRepository.GetByIdAsync(request.Id);
            if (post is not null)
            {
                if (!post.IsDeleted)
                {
                    post.UpVoteCount--;
                    post.ModifiedByUserId = (await _userService.GetIdFromClaim(request.Claim)).ToString();
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
            throw new NotFoundException("Post");
        }
    }
}
