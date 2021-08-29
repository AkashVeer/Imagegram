using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Model.ViewModels.Posts
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Caption { get; set; }
        public byte[] Image { get; set; }
        public Guid Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Comment> Comments { get; set; }
        public Account Account { get; set; }
    }
}
