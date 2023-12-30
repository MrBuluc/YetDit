using MediatR;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Commands.Comment.IncrementUpVoteCountComment
{
    public class IncrementUpVoteCountCommentCommandHandler : IRequestHandler<IncrementUpVoteCountCommentCommandRequest, IncrementUpVoteCountCommentCommandResponse>
    {
        private readonly ICommentReadRepository _readRepository;
        private readonly ICommentWriteRepository _writeRepository;

        public IncrementUpVoteCountCommentCommandHandler(ICommentWriteRepository writeRepository, ICommentReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<IncrementUpVoteCountCommentCommandResponse> Handle(IncrementUpVoteCountCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comment comment = await _readRepository.GetByIdAsync(request.Id);
            if (!comment.IsDeleted)
            {
                comment.UpVoteCount++;
                comment.ModifiedByUserId = request.UserId;
                await _writeRepository.SaveAsync();
                return new()
                {
                    Succeeded = true,
                    NewUpVoteCount = comment.UpVoteCount,
                };

            }
            return new() { Succeeded = false, };
        }
    }
}
