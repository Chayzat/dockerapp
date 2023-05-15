using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public partial class Post
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author? Author {get; set;}
    }
}