using MediatR;
using YetDit.Application.Exceptions;
using YetDit.Application.Repositories.Comment;
using YetDit.Application.Repositories.Post;

namespace YetDit.Application.Features.Queries.Post.GetByIdPost
{
    public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, GetByIdPostQueryResponse>
    {
        private readonly IPostReadRepository _readRepository;
        private readonly ICommentReadRepository _commentReadRepository;

        public GetByIdPostQueryHandler(IPostReadRepository readRepository, ICommentReadRepository commentReadRepository)
        {
            _readRepository = readRepository;
            _commentReadRepository = commentReadRepository;
        }

        public async Task<GetByIdPostQueryResponse> Handle(GetByIdPostQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post? post = await _readRepository.GetByIdAsync(request.Id);
            

            if (post is not null)
            {
                if (!post.IsDeleted)
                {
                    var comments = _commentReadRepository.GetWhere(c => c.PostId.ToString() == request.Id && c.IsDeleted == false).Select(c => new
                    {
                        c.Id,
                        c.PostId,
                        c.Content,
                        c.UserId,
                        c.UpVoteCount,
                        c.CreatedOn,
                        c.ModifiedOn
                    }).Skip(request.Page * request.Size).Take(request.Size);

                    return new()
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Description = post.Description,
                        UpVoteCount = post.UpVoteCount,
                        UserId = post.UserId.ToString(),
                        Comments = comments,
                        CreatedOn = post.CreatedOn,
                        UpdatedOn = post.ModifiedOn
                    };
                }
            }

            throw new NotFoundException("Post");
        }
    }
}
