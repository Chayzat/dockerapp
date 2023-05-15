using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Avatar { get; set; }

        public virtual Post Post {get; set;}

    }
}