using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripGuide.Models.Class;
namespace TripGuide.Controllers
{
    public class AboutController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var data = context.Abouts.ToList(); // hakkımızda değerleri listeleme
            return View(data);
        }
    }
}
