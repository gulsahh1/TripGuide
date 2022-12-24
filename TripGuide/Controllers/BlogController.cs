using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripGuide.Models.Class;
namespace TripGuide.Controllers
{
    public class BlogController : Controller
    {
        Context context = new Context();
        BlogCommentList commentList = new BlogCommentList();

        public IActionResult Index()
        {
            // var blog = context.Blogs.ToList();
            commentList.Value1 = context.Blogs.ToList();
            commentList.Value3 = context.Blogs.OrderByDescending(x=>x.Id).Take(2).ToList(); // son eklenen 2 blog alıyor
            return View(commentList);
        }
        public IActionResult BlogDetail(int id)
        {
            // var blogFind = context.Blogs.Where(x => x.Id == id).ToList();
            commentList.Value1 = context.Blogs.Where(x => x.Id == id).ToList();
            commentList.Value2 = context.Comments.Where(x => x.BlogId == id).ToList();
            return View(commentList);
        }
        [HttpGet]
        public PartialViewResult LeaveComment()
        {
            return PartialView();
        }

        [HttpPost]
       public PartialViewResult LeaveComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
            return PartialView();
        }
    }
}
