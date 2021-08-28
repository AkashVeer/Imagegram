using Imagegram.Model.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Services
{
    public interface IPostService
    {
        Task<PostDomainModel> AddPost(PostCreateDomainModel model);
        Task<List<PostDomainModel>> GetAllPosts();
        Task DeletePost(Guid id);
    }
}
