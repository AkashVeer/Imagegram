using AutoMapper;
using Imagegram.Application.Services;
using Imagegram.Model.Dtos.Posts;
using Imagegram.Model.ViewModels.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Imagegram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]IFormFile image, [FromForm] string caption)
        {
            if (image.Length > 0 && IsAllowedExtension(image))
            {
                var request = new PostCreateDomainModel()
                {
                    Caption = caption,
                    CreatedAt = DateTime.UtcNow,
                    Creator = GetAccountId(),
                    Image = image
                };
                var post = _mapper.Map<PostViewModel>(await _postService.AddPost(request));
                return Ok(post);
            }
            else
            {
                return BadRequest();
            }           
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = _mapper.Map<List<PostViewModel>>(await _postService.GetAllPosts());
            return Ok(posts);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _postService.DeletePost(id);
            return Ok();
        }

        private Guid GetAccountId()
        {
            return Guid.Parse(HttpContext
                .User
                .FindFirstValue(ClaimTypes.Authentication));
        }

        private bool IsAllowedExtension(IFormFile image)
        {
            var imageExtension = image.ContentType.Split("/")[1].ToLower();
            if (imageExtension == "png" || imageExtension == "jpg" || imageExtension == "bmp")
            {
                return true;
            }
            return false;
        }
    }
}
