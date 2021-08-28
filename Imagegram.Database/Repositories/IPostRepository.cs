using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Database.Repositories
{
    public interface IPostRepository
    {
        Task<Post> GetPost(Guid id);
        Task<List<Post>> GetPostsByAccount(Guid AccountId);
        Task<List<Post>> GetAllPosts();
        Task<Post> AddPost(Post post);
        Task DeletePost(Post post);
    }
}
