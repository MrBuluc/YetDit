using MediatR;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Queries.Post.GetAllPost
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQueryRequest, GetAllPostQueryResponse>
    {
        private readonly IPostReadRepository _readRepository;

        public GetAllPostQueryHandler(IPostReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public Task<GetAllPostQueryResponse> Handle(GetAllPostQueryRequest request, CancellationToken cancellationToken)
        {
            var posts = _readRepository.GetWhere(p => p.IsDeleted == false).Select(p => new
            {
                p.Id,
                p.Title,
                p.Description,
                p.UserId,
                p.CreatedOn,
                p.ModifiedOn
            }).Skip(request.Page * request.Size).Take(request.Size);
            return Task.FromResult<GetAllPostQueryResponse>(new()
            {
                Posts = posts,
                TotalCount = posts.Count()
            });
        }
    }
}
