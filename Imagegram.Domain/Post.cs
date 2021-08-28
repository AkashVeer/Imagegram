using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Caption { get; set; }
        public byte[] Image { get; set; }
        public Guid Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Comment> Comments { get; set; }
        [ForeignKey("Creator")]
        public Account Account { get; set; }
    }
}
