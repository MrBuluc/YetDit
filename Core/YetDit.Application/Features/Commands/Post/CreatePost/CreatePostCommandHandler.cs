using MediatR;
using System.Net;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
    {
        private readonly IPostWriteRepository _writeRepository;

        public CreatePostCommandHandler(IPostWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            int id = await _writeRepository.AddAsync(new Domain.Entities.Post()
            {
                Title = request.Title,
                Description = request.Description,
                UserId = Guid.Parse(request.UserId)
            });
            await _writeRepository.SaveAsync();
            return new()
            {
                PostId = id.ToString(),
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
