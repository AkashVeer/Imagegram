using Imagegram.Model.Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Services
{
    public interface ICommentService
    {
        Task AddComment(CommentCreateDomainModel model);
        Task DeleteComment(Guid id);
    }
}
