using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReferenceApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["MyTimeTemp"] = DateTime.Now.ToString();
            TempData["MyTimeTemp"] = DateTime.Now.ToString();
            ViewBag.MyTime = DateTime.Now.ToString();
            return RedirectToAction("GotoHome");
            
        }
        public ActionResult GotoHome()
        {
           // ViewData["MyTime"] = DateTime.Now.ToString();
           ViewBag.MyTime = DateTime.Now.ToString();
            return View();
        }
    }
}