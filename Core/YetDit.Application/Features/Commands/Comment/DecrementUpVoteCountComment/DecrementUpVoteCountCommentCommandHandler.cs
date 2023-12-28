using MediatR;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Commands.Comment.DecrementUpVoteCountComment
{
    public class DecrementUpVoteCountCommentCommandHandler : IRequestHandler<DecrementUpVoteCountCommentCommandRequest, DecrementUpVoteCountCommentCommandResponse>
    {
        private readonly ICommentReadRepository _readRepository;
        private readonly ICommentWriteRepository _writeRepository;

        public DecrementUpVoteCountCommentCommandHandler(ICommentWriteRepository writeRepository, ICommentReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<DecrementUpVoteCountCommentCommandResponse> Handle(DecrementUpVoteCountCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comment comment = await _readRepository.GetByIdAsync(request.Id);
            if (!comment.IsDeleted)
            {
                comment.UpVoteCount--;
                comment.ModifiedByUserId = request.UserId;
                await _writeRepository.SaveAsync();
                return new()
                {
                    Succeeded = true,
                    NewUpVoteCount = comment.UpVoteCount
                };
            }
            return new()
            {
                Succeeded = false
            };
        }
    }
}
