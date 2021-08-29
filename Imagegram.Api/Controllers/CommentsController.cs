using AutoMapper;
using Imagegram.Application.Services;
using Imagegram.Model.Dtos.Comments;
using Imagegram.Model.ViewModels.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagegram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentCreateViewModel request)
        {
            var comment = _mapper.Map<CommentCreateDomainModel>(request);
            await _commentService.AddComment(comment);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _commentService.DeleteComment(id);
            return Ok();
        }
    }
}
