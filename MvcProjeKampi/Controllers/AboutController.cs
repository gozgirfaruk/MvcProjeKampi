using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        AboutMenager abm = new AboutMenager(new EfAboutDal());


        public ActionResult Index()
        {
            var aboutvalue = abm.GetList();
            return View(aboutvalue);
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult StatusChange(int id)
        {
            var values = abm.GetByID(id);
            values.AboutStatus = true;
            abm.AboutUpdate(values);
            return RedirectToAction("Index");
        }
    }
}