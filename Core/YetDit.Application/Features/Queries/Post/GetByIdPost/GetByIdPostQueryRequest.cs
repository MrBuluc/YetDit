using MediatR;

namespace YetDit.Application.Features.Queries.Post.GetByIdPost
{
    public class GetByIdPostQueryRequest : IRequest<GetByIdPostQueryResponse>
    {
        public string Id { get; set; }

        public int Page { get; set; }
        public int Size { get; set; }
    }
}
