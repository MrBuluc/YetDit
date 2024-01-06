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
            var comments = _readRepository.GetWhere(c => c.PostId == request.Id && c.IsDeleted == false).Select(c => new
            {
                c.Id,
                c.PostId,
                c.Content,
                c.UserId,
                c.UpVoteCount,
                c.CreatedOn,
                c.ModifiedOn
            }).Skip(request.Page * request.Size).Take(request.Size);

            return Task.FromResult<GetAllCommentsQueryResponse>(new()
            {
                Comments = comments,
                TotalCount = comments.Count()
            });
        }
    }
}
