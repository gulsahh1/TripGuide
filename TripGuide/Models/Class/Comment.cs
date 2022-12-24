using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripGuide.Models.Class
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; } // her yorum eklediğimizde bir blog eklemesin diye...
        public virtual Blog Blog { get; set; } // blog toblosundan gelen değeri tutuyor.Bire bir ilişki var.

    }
}
