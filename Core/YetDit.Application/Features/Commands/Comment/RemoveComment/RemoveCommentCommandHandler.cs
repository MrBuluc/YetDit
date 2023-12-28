using MediatR;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Commands.Comment.RemoveComment
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommandRequest, RemoveCommentCommandResponse>
    {
        private readonly ICommentReadRepository _readRepository;
        private readonly ICommentWriteRepository _writeRepository;

        public RemoveCommentCommandHandler(ICommentWriteRepository writeRepository, ICommentReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<RemoveCommentCommandResponse> Handle(RemoveCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comment comment = await _readRepository.GetByIdAsync(request.Id);
            if (!comment.IsDeleted)
            {
                comment.DeletedByUserId = request.UserId;
                comment.DeletedOn = DateTime.UtcNow;
                comment.IsDeleted = true;
                await _writeRepository.SaveAsync();
            }
            return new()
            {
                Succeeded = true,
            };
        }
    }
}
