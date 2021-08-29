using AutoMapper;
using Imagegram.Database.Repositories;
using Imagegram.Domain;
using Imagegram.Model.Dtos.Posts;
using Imagegram.Model.Exceptions;
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
            try
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
            catch(Exception ex)
            {
                throw new HandleException("Exception in AddPost method : " + ex.Message);
            }
        }

        public async Task<List<PostDomainModel>> GetAllPosts()
        {
            try
            {
                var posts = _mapper.Map<List<PostDomainModel>>(await _postRepository.GetAllPosts());
                return posts;
            }
            catch (Exception ex) 
            { 
                throw new HandleException("Exception in GetAllPosts method : " + ex.Message);
            }
        }
        public async Task DeletePost(Guid id)
        {
            try
            {
                var post = await _postRepository.GetPost(id);
                if (post is not null)
                {
                    await _postRepository.DeletePost(post);
                }
            }
            catch (Exception ex)
            {
                throw new HandleException("Exception in DeletePost method : " + ex.Message);
            }
        }
    }
}
