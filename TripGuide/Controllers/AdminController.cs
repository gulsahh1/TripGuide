using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripGuide.Models.Class;
namespace TripGuide.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var blogList = context.Blogs.ToList();
            return View(blogList);
        }

        [HttpGet]
        public IActionResult NewBlog() // sayfa yüklendiği zaman calısıyor
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewBlog(Blog blog)
        {
            context.Blogs.Add(blog);
            context.SaveChanges(); // değişiklikleri kaydet
            return RedirectToAction("Index");
        }

        public IActionResult BlogDelete(int id)
        {
            var delete = context.Blogs.Find(id);
            context.Blogs.Remove(delete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BlogFind(int id)
        {
            var blog = context.Blogs.Find(id);
            return View("BlogFind", blog);
        }

        public IActionResult BlogUpdate(Blog blg)
        {
            var blogUpdate = context.Blogs.Find(blg.Id);
            blogUpdate.Title = blg.Title;
            blogUpdate.Description = blg.Description;
            blogUpdate.BlogImage = blg.BlogImage;
            blogUpdate.Date = blg.Date;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult CommentList()
        {
            var comment = context.Comments.Include(x=>x.Blog).ToList();
            return View(comment);
        }

        public IActionResult CommentDelete(int id)
        {
            var delete = context.Comments.Find(id);
            context.Comments.Remove(delete);
            context.SaveChanges();
            return RedirectToAction("CommentList");
        }
        public IActionResult CommentFind(int id)
        {
            var comment = context.Comments.Find(id);
            return View("CommentFind", comment);
        }

        public IActionResult CommentUpdate(Comment com)
        {
            var ComUpdate = context.Comments.Find(com.Id);
            ComUpdate.UserName = com.UserName;
            ComUpdate.Mail = com.Mail;
            ComUpdate.Description = com.Description;
            context.SaveChanges();
            return RedirectToAction("CommentList");

        }

    }
}
