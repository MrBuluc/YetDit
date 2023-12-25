using MediatR;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Commands.Post.RemovePost
{
    public class RemovePostCommandHandler : IRequestHandler<RemovePostCommandRequest, RemovePostCommandResponse>
    {
        private readonly IPostWriteRepository _writeRepository;

        public RemovePostCommandHandler(IPostWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<RemovePostCommandResponse> Handle(RemovePostCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.RemoveAsync(int.Parse(request.Id));
            await _writeRepository.SaveAsync();
            return new RemovePostCommandResponse()
            {
                Succeeded = true,
            };
        }
    }
}
