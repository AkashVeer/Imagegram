using AutoMapper;
using Imagegram.Database.Repositories;
using Imagegram.Domain;
using Imagegram.Model.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostDomainModel> AddPost(PostCreateDomainModel model)
        {
            byte[] byteImg;
            using (var ms = new MemoryStream())
            {
                await model.Image.CopyToAsync(ms);
                byteImg = ms.ToArray();
            }
            var post = new Post()
            {
                Caption = model.Caption,
                CreatedAt = model.CreatedAt,
                Creator = model.Creator,
                Image = byteImg
            };
            var response = _mapper.Map<PostDomainModel>(await _postRepository.AddPost(post));
            return response;
        }

        public async Task<List<PostDomainModel>> GetAllPosts()
        {
            var posts = _mapper.Map<List<PostDomainModel>>(await _postRepository.GetAllPosts());
            return posts;
        }
        public async Task DeletePost(Guid id)
        {
            var post = await _postRepository.GetPost(id);
            if(post is not null)
            {
                await _postRepository.DeletePost(post);
            }
        }
    }
}
