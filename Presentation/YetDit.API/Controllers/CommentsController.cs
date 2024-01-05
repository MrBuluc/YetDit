using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using YetDit.Application.Features.Commands.Comment.CreateComment;
using YetDit.Application.Features.Commands.Comment.UpdateComment;
using YetDit.Application.Features.Commands.Post.CreatePost;
using YetDit.Application.Features.Commands.Post.UpdatePost;
using YetDit.Application.Features.Queries.Post.GetAllPost;

namespace YetDit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateComment(CreateCommentCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }
    }
}
