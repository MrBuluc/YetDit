using MediatR;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, UpdatePostCommandResponse>
    {
        private readonly IPostReadRepository _readRepository;
        private readonly IPostWriteRepository _writeRepository;
        private readonly IUserService _userService;

        public UpdatePostCommandHandler(IPostReadRepository readRepository, IPostWriteRepository writeRepository, IUserService userService)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _userService = userService;
        }
        public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post? post = await _readRepository.GetByIdAsync(request.Id);
            
            if (post is not null)
            {
                if (!post.IsDeleted)
                {
                    Guid userId = await _userService.GetIdFromClaim(request.Claim!);
                    if (post.UserId == userId)
                    {
                        post.Title = request.Title == "" ? post.Title : request.Title;
                        post.Description = request.Description == "" ? post.Description : request.Description;
                        post.ModifiedOn = DateTime.UtcNow;
                        post.ModifiedByUserId = userId.ToString();
                        await _writeRepository.SaveAsync();
                        return new()
                        {
                            Succeeded = true,
                        };
                    }
                    throw new NotBelongsToUserException("Post");
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
