using MediatR;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Queries.Post.Get5PostRandomly
{
    public class Get5PostRandomlyQueryHandler : IRequestHandler<Get5PostRandomlyQueryRequest, Get5PostRandomlyQueryResponse>
    {
        private readonly IPostReadRepository _readRepository;

        public Get5PostRandomlyQueryHandler(IPostReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Get5PostRandomlyQueryResponse> Handle(Get5PostRandomlyQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Post> posts = new();
            Random random = new();
            List<PostId> allPosts = _readRepository.GetAll().Select(p => new PostId()
            {
                Id = p.Id,
            }).ToList();
            int count = allPosts.Count;
            List<int> ids = new();

            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(count);
                while (ids.Contains(index))
                {
                    index = random.Next(count);
                }

                ids.Add(index);
                posts.Add((await _readRepository.GetByIdAsync(allPosts[index].Id.ToString()))!);
            }

            return new()
            {
                Posts = posts.Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Description,
                    p.UserId,
                    p.CreatedOn,
                    p.ModifiedOn
                }).ToList()
            };

        }
    }

    public class PostId
    {
        public int Id { get; set; }
    }
}
