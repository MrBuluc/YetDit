using MediatR;
using System.Net;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _writeRepository;
        private readonly IUserService _userService;

        public CreateCommentCommandHandler(ICommentWriteRepository writeRepository, IUserService userService)
        {
            _writeRepository = writeRepository;
            _userService = userService;
        }

        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = await _userService.GetIdFromClaim(request.Claim!);
            Domain.Entities.Comment comment = new()
            {
                Content = request.Content,
                UserId = userId,
                PostId = request.PostId,
                CreatedByUserId = userId.ToString()
            };

            await _writeRepository.AddAsync(comment);
            await _writeRepository.SaveAsync();
            return new()
            {
                StatusCode = (int)HttpStatusCode.Created,
                CommentId = comment.Id.ToString(),
            };
        }
    }
}
