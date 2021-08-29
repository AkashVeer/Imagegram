using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Model.ViewModels.Comments
{
    public class CommentCreateViewModel
    {
        public string Content { get; set; }
        public Guid Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid PostId { get; set; }
    }
}
