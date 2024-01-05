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
            List<Domain.Entities.Post> allPosts = _readRepository.GetAll().ToList();
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
                posts.Add(allPosts[index]);
            }

            return new Get5PostRandomlyQueryResponse()
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
}
