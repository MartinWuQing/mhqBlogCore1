using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mhq.Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Top()
        {
            return View();
        }
        public IActionResult Left()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }




    }
}