using MediatR;
using System.Net;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _writeRepository;

        public CreateCommentCommandHandler(ICommentWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Guid commentId = await _writeRepository.AddAsync(new()
            {
                Content = request.Content,
                UserId = Guid.Parse(request.UserId),
                CreatedByUserId = request.UserId
            });
            await _writeRepository.SaveAsync();
            return new()
            {
                StatusCode = (int)HttpStatusCode.Created,
                CommentId = commentId.ToString(),
            };
        }
    }
}
