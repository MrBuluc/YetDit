using MediatR;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.RemovePost
{
    public class RemovePostCommandHandler : IRequestHandler<RemovePostCommandRequest, RemovePostCommandResponse>
    {
        private readonly IPostWriteRepository _writeRepository;
        private readonly IPostReadRepository _readRepository;

        public RemovePostCommandHandler(IPostWriteRepository writeRepository, IPostReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<RemovePostCommandResponse> Handle(RemovePostCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post post = await _readRepository.GetByIdAsync(request.Id);
            if (!post.IsDeleted)
            {
                if (post.UserId.ToString() == request.UserId)
                {
                    post.DeletedByUserId = request.UserId;
                    post.DeletedOn = DateTime.UtcNow;
                    post.IsDeleted = true;
                    await _writeRepository.SaveAsync();
                }
                throw new NotBelongsToUserException("Comment");
            }
            return new()
            {
                Succeeded = true,
            };
        }
    }
}
