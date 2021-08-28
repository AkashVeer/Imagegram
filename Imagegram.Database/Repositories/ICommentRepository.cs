using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Database.Repositories
{
    public interface ICommentRepository
    {
        Task AddComment(Comment comment);
    }
}
