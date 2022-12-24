using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripGuide.Models.Class
{
    public class BlogCommentList
    {
        public IEnumerable<Blog> Value1 { get; set; }
        public IEnumerable<Comment> Value2 { get; set; }
        public IEnumerable<Blog> Value3 { get; set; }
        // bir view içerisinde birden fazla tablodan veri çekiyoruz.
    }
}
