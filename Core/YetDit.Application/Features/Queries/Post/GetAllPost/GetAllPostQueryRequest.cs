using MediatR;

namespace YetDit.Application.Features.Queries.Post.GetAllPost
{
    public class GetAllPostQueryRequest : IRequest<GetAllPostQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
