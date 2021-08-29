using AutoMapper;
using Imagegram.Model.Dtos.Posts;
using Imagegram.Model.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagegram.Api.MapperProfiles.Posts
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostDomainModel, PostViewModel>();
        }
    }
}
