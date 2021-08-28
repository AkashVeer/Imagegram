using AutoMapper;
using Imagegram.Domain;
using Imagegram.Model.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.MapperProfiles.Posts
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDomainModel>();
        }
    }
}
