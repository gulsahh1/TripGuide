using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripGuide.Models.Class;
namespace TripGuide.Controllers
{
    public class PageController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var blog = context.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return View(blog);
        }
        
    }
}
