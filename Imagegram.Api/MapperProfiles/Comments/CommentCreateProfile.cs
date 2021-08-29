using AutoMapper;
using Imagegram.Model.Dtos.Comments;
using Imagegram.Model.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagegram.Api.MapperProfiles.Comments
{
    public class CommentCreateProfile : Profile
    {
        public CommentCreateProfile()
        {
            CreateMap<CommentCreateViewModel, CommentCreateDomainModel>();
        }
    }
}
