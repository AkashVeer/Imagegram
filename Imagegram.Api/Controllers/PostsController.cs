using AutoMapper;
using Imagegram.Api.CacheProvider;
using Imagegram.Application.Services;
using Imagegram.Model.Dtos.Posts;
using Imagegram.Model.ViewModels.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;

        public PostsController(IPostService postService, IMapper mapper, IMemoryCache cache)
        {
            _postService = postService;
            _mapper = mapper;
            _cache = cache;
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
                _cache.RemoveItemIfExists(CacheKey.POSTSCACHEKEY);
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
            var posts = (List<PostViewModel>)_cache.GetItem(CacheKey.POSTSCACHEKEY);
            if(posts is null)
            {
                posts = _mapper.Map<List<PostViewModel>>(await _postService.GetAllPosts());
                _cache.AddItemIfNotExists(CacheKey.POSTSCACHEKEY, posts);
            }           
            return Ok(posts);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _postService.DeletePost(id);
            _cache.RemoveItemIfExists(CacheKey.POSTSCACHEKEY);
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
