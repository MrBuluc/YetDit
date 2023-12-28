using MediatR;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Queries.Comment.GetByIdComment
{
    public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQueryRequest, GetByIdCommentQueryResponse>
    {
        private readonly ICommentReadRepository _readRepository;

        public GetByIdCommentQueryHandler(ICommentReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetByIdCommentQueryResponse> Handle(GetByIdCommentQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comment comment = await _readRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = comment.Id.ToString(),
                Content = comment.Content,
                UpVoteCount = comment.UpVoteCount,
                UserId = comment.UserId.ToString(),
                PostId = comment.PostId,
                CreatedOn = comment.CreatedOn,
                UpdatedOn = comment.ModifiedOn
            };
        }
    }
}
