using MediatR;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Queries.Post.GetByIdPost
{
    public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, GetByIdPostQueryResponse>
    {
        private readonly IPostReadRepository _readRepository;

        public GetByIdPostQueryHandler(IPostReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetByIdPostQueryResponse> Handle(GetByIdPostQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post post = await _readRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                UpVoteCount = post.UpVoteCount,
                UserId = post.UserId.ToString(),
                Comments = post.Comments,
                CreatedOn = post.CreatedOn,
                UpdatedOn = post.ModifiedOn
            };
        }
    }
}
