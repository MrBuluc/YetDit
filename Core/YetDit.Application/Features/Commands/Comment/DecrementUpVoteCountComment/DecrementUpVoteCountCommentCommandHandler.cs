using MediatR;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Commands.Comment.DecrementUpVoteCountComment
{
    public class DecrementUpVoteCountCommentCommandHandler : IRequestHandler<DecrementUpVoteCountCommentCommandRequest, DecrementUpVoteCountCommentCommandResponse>
    {
        private readonly ICommentReadRepository _readRepository;
        private readonly ICommentWriteRepository _writeRepository;
        private readonly IUserService _userService;

        public DecrementUpVoteCountCommentCommandHandler(ICommentWriteRepository writeRepository, ICommentReadRepository readRepository, IUserService userService)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _userService = userService;
        }

        public async Task<DecrementUpVoteCountCommentCommandResponse> Handle(DecrementUpVoteCountCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comment? comment = await _readRepository.GetByIdAsync(request.Id);
            if (comment is not null)
            {
                if (!comment.IsDeleted)
                {
                    comment.UpVoteCount--;
                    comment.ModifiedByUserId = (await _userService.GetIdFromClaim(request.Claim)).ToString();
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
            throw new NotFoundException("Comment");
        }
    }
}
