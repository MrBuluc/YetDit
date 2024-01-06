using MediatR;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Commands.Comment.IncrementUpVoteCountComment
{
    public class IncrementUpVoteCountCommentCommandHandler : IRequestHandler<IncrementUpVoteCountCommentCommandRequest, IncrementUpVoteCountCommentCommandResponse>
    {
        private readonly ICommentReadRepository _readRepository;
        private readonly ICommentWriteRepository _writeRepository;
        private readonly IUserService _userService;

        public IncrementUpVoteCountCommentCommandHandler(ICommentWriteRepository writeRepository, ICommentReadRepository readRepository, IUserService userService)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _userService = userService;
        }

        public async Task<IncrementUpVoteCountCommentCommandResponse> Handle(IncrementUpVoteCountCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comment? comment = await _readRepository.GetByIdAsync(request.Id);
            if (comment is not null)
            {
                if (!comment.IsDeleted)
                {
                    if (!comment.Post.IsDeleted)
                    {
                        comment.UpVoteCount += 1;
                        comment.ModifiedByUserId = (await _userService.GetIdFromClaim(request.Claim!)).ToString();
                        await _writeRepository.SaveAsync();
                        return new()
                        {
                            Succeeded = true,
                            NewUpVoteCount = comment.UpVoteCount
                        };
                    }
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
