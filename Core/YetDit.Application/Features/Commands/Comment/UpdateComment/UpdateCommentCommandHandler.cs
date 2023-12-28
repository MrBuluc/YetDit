using MediatR;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
    {
        private readonly ICommentReadRepository _readRepository;
        private readonly ICommentWriteRepository _writeRepository;

        public UpdateCommentCommandHandler(ICommentWriteRepository writeRepository, ICommentReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comment comment = await _readRepository.GetByIdAsync(request.Id);
            if (!comment.IsDeleted)
            {
                if (comment.UserId.ToString() == request.UserId)
                {
                    comment.Content = request.Content == "" ? comment.Content : request.Content;
                    comment.ModifiedByUserId = request.UserId;
                    await _writeRepository.SaveAsync();
                    return new()
                    {
                        Succeeded = true,
                    };
                }
                throw new NotBelongsToUserException("Comment");
            }
            return new() { Succeeded = false };
        }
    }
}
