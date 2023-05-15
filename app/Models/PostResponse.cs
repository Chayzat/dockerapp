using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class PostResponse
    {
        public List<Post> Posts { get; set; } = new List<Post>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}