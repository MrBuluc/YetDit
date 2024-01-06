using MediatR;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Commands.Comment.RemoveComment
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommandRequest, RemoveCommentCommandResponse>
    {
        private readonly ICommentReadRepository _readRepository;
        private readonly ICommentWriteRepository _writeRepository;
        private readonly IUserService _userService;
        public RemoveCommentCommandHandler(ICommentWriteRepository writeRepository, ICommentReadRepository readRepository, IUserService userService)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _userService = userService;
        }

        public async Task<RemoveCommentCommandResponse> Handle(RemoveCommentCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comment? comment = await _readRepository.GetByIdAsync(request.Id);
            
            if (comment is null) throw new NotFoundException("Comment");

            if (!comment.IsDeleted)
            {
                Guid userId = await _userService.GetIdFromClaim(request.Claim!);
                if (comment.UserId == userId)
                {
                    comment.DeletedByUserId = userId.ToString();
                    comment.DeletedOn = DateTime.UtcNow;
                    comment.IsDeleted = true;
                    await _writeRepository.SaveAsync();

                }
                else throw new NotBelongsToUserException("Comment");
            }
            return new()
            {
                Succeeded = true,
            };
        }
    }
}
