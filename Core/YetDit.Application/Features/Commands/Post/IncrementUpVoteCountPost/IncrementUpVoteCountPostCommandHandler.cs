using MediatR;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.IncrementUpVoteCount
{
    public class IncrementUpVoteCountPostCommandHandler : IRequestHandler<IncrementUpVoteCountPostCommandRequest, IncrementUpVoteCountPostCommandResponse>
    {
        private readonly IPostReadRepository _readRepository;
        private readonly IPostWriteRepository _writeRepository;
        private readonly IUserService _userService;

        public IncrementUpVoteCountPostCommandHandler(IPostReadRepository readRepository, IPostWriteRepository writeRepository, IUserService userService)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _userService = userService;
            _userService = userService;
        }
        public async Task<IncrementUpVoteCountPostCommandResponse> Handle(IncrementUpVoteCountPostCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post post = await _readRepository.GetByIdAsync(request.Id);
            if (!post.IsDeleted)
            {
                post.UpVoteCount++;
                post.ModifiedOn = DateTime.UtcNow;
                post.ModifiedByUserId = (await _userService.GetIdFromClaim(request.Claim)).ToString();
                await _writeRepository.SaveAsync();
                return new()
                {
                    Succeeded = true,
                    NewUpVoteCount = post.UpVoteCount,
                };
            }
            return new() { Succeeded = false, };
        }
    }
}
