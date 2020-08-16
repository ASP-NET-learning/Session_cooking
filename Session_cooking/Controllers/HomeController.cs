using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Session_cooking.EfModels;
using Session_cooking.Models;

namespace Session_cooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //BlogContext db = new BlogContext();
            //var res = (from x in db.User select x).ToList();
            //ViewBag.users = res;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create() 
        {
            string key = "MyCookie";
            string value = "123";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append(key, value, cookieOptions);
            return View("Index");
        }
        public IActionResult Read()
        {
            string key = "MyCookie";
            var cookieValue = Request.Cookies[key];
            return View("Index");
        }

        public IActionResult Remove()
        {
            string key = "MyCookie";
            string value = "";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append(key, value, cookieOptions);
            return View("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
