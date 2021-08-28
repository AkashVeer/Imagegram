using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Creator")]
        public Account Account { get; set; }
    }
}
