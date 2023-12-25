using MediatR;
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
            post.DeletedByUserId = request.UserId;
            post.DeletedOn = DateTime.UtcNow;
            post.IsDeleted = true;
            await _writeRepository.SaveAsync();
            return new()
            {
                Succeeded = true,
            };
        }
    }
}
