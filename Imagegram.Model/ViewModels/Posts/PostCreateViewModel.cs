using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Model.ViewModels.Posts
{
    public class PostCreateViewModel
    {
        public string Caption { get; set; }
        public Guid Creator { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
