using MediatR;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, UpdatePostCommandResponse>
    {
        private readonly IPostReadRepository _readRepository;
        private readonly IPostWriteRepository _writeRepository;

        public UpdatePostCommandHandler(IPostReadRepository readRepository, IPostWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post post = await _readRepository.GetByIdAsync(request.Id);
            post.Title = request.Title;
            post.Description = request.Description;
            post.ModifiedOn = DateTime.UtcNow;
            post.ModifiedByUserId = request.UserId;
            await _writeRepository.SaveAsync();
            return new()
            {
                Succeeded = true,
            };
        }
    }
}
