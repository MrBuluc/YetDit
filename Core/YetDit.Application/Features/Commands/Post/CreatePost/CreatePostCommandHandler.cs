using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
    {
        private readonly IPostWriteRepository _writeRepository;
        private readonly IUserService _userService;

        public CreatePostCommandHandler(IPostWriteRepository writeRepository, IUserService userService)
        {
            _writeRepository = writeRepository;
            _userService = userService;
        }

        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = await _userService.GetIdFromClaim(request.Claim!);
            Domain.Entities.Post post = new()
            {
                Title = request.Title,
                Description = request.Description,
                UserId = userId,
                CreatedByUserId = userId.ToString(),
                CreatedOn = DateTime.UtcNow,
            };
            await _writeRepository.AddAsync(post);
            await _writeRepository.SaveAsync();
            return new()
            {
                PostId = post.Id.ToString(),
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
