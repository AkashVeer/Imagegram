using Imagegram.Domain;
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
    }
}
