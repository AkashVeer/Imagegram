using Imagegram.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Database.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ImagegramDbContext _dbContext;
        public PostRepository(ImagegramDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Post> AddPost(Post post)
        {
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return await GetPost(post.Id);
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _dbContext.Posts.OrderByDescending(x=>x.Comments.Count).Include(x => x.Comments.OrderByDescending(x => x.CreatedAt).Take(2)).ToListAsync();
        }

        public async Task<Post> GetPost(Guid id)
        {
            return await _dbContext.Posts.Include(x=>x.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Post>> GetPostsByAccount(Guid AccountId)
        {
            return await _dbContext.Posts.Where(x => x.Creator == AccountId).ToListAsync();
        }
        public async Task DeletePost(Post post)
        {
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }
    }
}
