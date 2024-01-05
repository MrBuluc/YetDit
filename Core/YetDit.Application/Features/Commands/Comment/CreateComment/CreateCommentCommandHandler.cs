using MediatR;
using System.Net;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Comment;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _writeRepository;
        private readonly IPostReadRepository _postReadRepository;
        private readonly IUserService _userService;

        public CreateCommentCommandHandler(ICommentWriteRepository writeRepository, IUserService userService, IPostReadRepository postReadRepository)
        {
            _writeRepository = writeRepository;
            _userService = userService;
            _postReadRepository = postReadRepository;
        }

        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = await _userService.GetIdFromClaim(request.Claim!);

            Domain.Entities.Post? post = await _postReadRepository.GetByIdAsync(request.PostId.ToString());


            if (post is not null)
            {
                if (post.IsDeleted == false)
                {
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
                else throw new Exception("Post was deleted.");
            }
            else throw new NotFoundException("Post");

        }
    }
}
