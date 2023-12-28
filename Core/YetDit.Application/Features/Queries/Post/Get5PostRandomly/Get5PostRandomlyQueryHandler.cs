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
            int count = _readRepository.GetAll().Count();
            List<int> ids = new();

            for (int i = 0; i < 5; i++)
            {
                int id = random.Next(count);
                while (ids.Contains(id))
                {
                    id = random.Next(count);
                }

                posts.Add(await _readRepository.GetByIdAsync(id.ToString()));
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
                })
            };
        }
    }
}
