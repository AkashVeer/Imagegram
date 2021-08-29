using Imagegram.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Database.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ImagegramDbContext _dbContext;
        public CommentRepository(ImagegramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddComment(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteComment(Comment comment)
        {
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Comment> GetComment(Guid id)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
