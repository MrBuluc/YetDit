using MediatR;
using YetDit.Application.Repositories.Comment;

namespace YetDit.Application.Features.Queries.Comment.GetAllComments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQueryRequest, GetAllCommentsQueryResponse>
    {
        private readonly ICommentReadRepository _readRepository;

        public GetAllCommentsQueryHandler(ICommentReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public Task<GetAllCommentsQueryResponse> Handle(GetAllCommentsQueryRequest request, CancellationToken cancellationToken)
        {
            var comments = _readRepository.GetWhere(p => p.PostId == request.Id && p.IsDeleted == false).Select(p => new
            {
                p.Id,
                p.PostId,
                p.Content,
                p.UserId,
                p.UpVoteCount,
                p.CreatedOn,
                p.ModifiedOn
            }).Skip(request.Page * request.Size).Take(request.Size);
            return Task.FromResult<GetAllCommentsQueryResponse>(new()
            {
                Comments = comments,
                TotalCount = comments.Count()
            });
        }
    }
}
