using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Model.Dtos.Posts
{
    public class PostCreateDomainModel
    {
        public string Caption { get; set; }
        public IFormFile Image { get; set; }
        public Guid Creator { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
