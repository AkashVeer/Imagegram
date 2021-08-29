using AutoMapper;
using Imagegram.Database.Repositories;
using Imagegram.Domain;
using Imagegram.Model.Dtos.Comments;
using Imagegram.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task AddComment(CommentCreateDomainModel model)
        {
            try
            {
                var comment = _mapper.Map<Comment>(model);
                await _commentRepository.AddComment(comment);
            }
            catch(Exception ex)
            {
                throw new HandleException("Exception in AddComment method : " + ex.Message);
            }
        }

        public async Task DeleteComment(Guid id)
        {
            var comment = await _commentRepository.GetComment(id);
            if(comment is not null)
            {
                await _commentRepository.DeleteComment(comment);
            }
        }
    }
}
