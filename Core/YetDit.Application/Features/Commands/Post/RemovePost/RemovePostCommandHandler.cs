using MediatR;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.RemovePost
{
    public class RemovePostCommandHandler : IRequestHandler<RemovePostCommandRequest, RemovePostCommandResponse>
    {
        private readonly IPostWriteRepository _writeRepository;
        private readonly IPostReadRepository _readRepository;
        private readonly IUserService _userService;

        public RemovePostCommandHandler(IPostWriteRepository writeRepository, IPostReadRepository readRepository, IUserService userService)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _userService = userService;
        }

        public async Task<RemovePostCommandResponse> Handle(RemovePostCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post? post = await _readRepository.GetByIdAsync(request.Id);
            if (post is not null)
            {
                if (!post.IsDeleted)
                {
                    Guid userId = await _userService.GetIdFromClaim(request.Claim!);
                    if (post.UserId == userId)
                    {
                        post.DeletedByUserId = userId.ToString();
                        post.DeletedOn = DateTime.UtcNow;
                        post.IsDeleted = true;
                        await _writeRepository.SaveAsync();
                        return new()
                        {
                            Succeeded = true
                        };
                    }
                    throw new NotBelongsToUserException("Post");
                }
                return new()
                {
                    Succeeded = true,
                };
            }
            throw new NotFoundException("Post");
        }
    }
}
