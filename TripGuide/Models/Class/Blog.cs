using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripGuide.Models.Class
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string BlogImage { get; set; }
        public ICollection<Comment> Comments { get; set; } // Blog tablosuyla Comment tablosuyla bire çok ilişkisi oluşturuyor
    }
}
