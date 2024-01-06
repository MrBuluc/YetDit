using MediatR;
using Microsoft.Extensions.Caching.Memory;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Queries.Post.GetAllPost
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQueryRequest, GetAllPostQueryResponse>
    {
        private readonly IPostReadRepository _readRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions;
        private const string PostsCacheKey = "postList";

        public GetAllPostQueryHandler(IPostReadRepository readRepository, IMemoryCache memoryCache)
        {
            _readRepository = readRepository;
            _memoryCache = memoryCache;
            _cacheEntryOptions = new()
            {
                Priority = CacheItemPriority.High,
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30),
            };
        }

        public Task<GetAllPostQueryResponse> Handle(GetAllPostQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Post> postList = new();

            if (_memoryCache.TryGetValue(PostsCacheKey, out postList))
            {
                return Task.FromResult<GetAllPostQueryResponse>(new()
                {
                    Posts = postList,
                    TotalCount = postList.Count
                });
            }

            var posts = _readRepository.GetWhere(p => p.IsDeleted == false).Select(p => new
            {
                p.Id,
                p.Title,
                p.Description,
                p.UserId,
                p.CreatedOn,
                p.ModifiedOn
            }).Skip(request.Page * request.Size).Take(request.Size);
            
            _memoryCache.Set(PostsCacheKey, posts, _cacheEntryOptions);

            return Task.FromResult<GetAllPostQueryResponse>(new()
            {
                Posts = posts,
                TotalCount = posts.Count()
            });
        }
    }
}
