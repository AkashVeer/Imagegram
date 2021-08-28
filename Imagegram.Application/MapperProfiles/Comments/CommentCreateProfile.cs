using AutoMapper;
using Imagegram.Domain;
using Imagegram.Model.Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.MapperProfiles.Comments
{
    public class CommentCreateProfile : Profile
    {
        public CommentCreateProfile()
        {
            CreateMap<CommentCreateDomainModel, Comment>();
        }
    }
}
