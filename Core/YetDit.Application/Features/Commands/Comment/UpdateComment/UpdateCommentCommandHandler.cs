using MediatR;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
    {
        private readonly ICommentReadRepository _readRepository;
        private readonly ICommentWriteRepository _writeRepository;
        private readonly IUserService _userService;

        public UpdateCommentCommandHandler(ICommentWriteRepository writeRepository, ICommentReadRepository readRepository, IUserService userService)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _userService = userService;
        }

        public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            
            Domain.Entities.Comment? comment = await _readRepository.GetByIdAsync(request.Id);

            if (comment is null) throw new NotFoundException("Comment");

            if (!comment.IsDeleted)
            {
                Guid userId = await _userService.GetIdFromClaim(request.Claim!);
                if (comment.UserId == userId)
                {
                    comment.Content = request.Content == "" ? comment.Content : request.Content;
                    comment.ModifiedByUserId = userId.ToString();
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
