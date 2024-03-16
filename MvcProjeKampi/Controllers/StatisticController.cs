using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.one = db.Categories.Count();
            ViewBag.two = db.Headings.Where(x => x.CategoryID == 4).Count();
            ViewBag.three = db.Writers.Where(x => x.FirstName.Contains("a")).Count();
            var plus = db.Categories.Where(x => x.Status == true).Count();
            var minus = db.Categories.Where(x => x.Status == false).Count();
            ViewBag.result = plus - minus;
            ViewBag.five = db.Categories.Where(x => x.Status == true).Count();
            ViewBag.six = db.Admins.Count();
            ViewBag.seven = db.Admins.Where(x => x.Role == "1").Count();
            ViewBag.eight = db.Admins.Where(x => x.Role == "2").Count();
            ViewBag.nine = db.ImageFiles.Count();
            ViewBag.ten = db.Contacts.Count();
            ViewBag.eleven = db.Contents.Count();
            ViewBag.twelve = db.Writers.Count();
            return View();
        }
    }
}