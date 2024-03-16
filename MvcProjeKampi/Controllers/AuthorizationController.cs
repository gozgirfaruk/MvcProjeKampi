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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminMenager adminMenager = new AdminMenager(new EfAdminDal());


        public ActionResult Index()
        {
            var adminvalues = adminMenager.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueAdminRole = new List<SelectListItem>();
            valueAdminRole.Add(new SelectListItem
            {
                Text = "1",
                Value = "1"

            });
            valueAdminRole.Add(new SelectListItem
            {
                Text = "2",
                Value = "2"

            });
            valueAdminRole.Add(new SelectListItem
            {
                Text = "3",
                Value = "3"

            });
            ViewBag.vlc = valueAdminRole;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adminMenager.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueAdminRole = new List<SelectListItem>();
            valueAdminRole.Add(new SelectListItem
            {
                Text = "1",
                Value = "1"

            });
            valueAdminRole.Add(new SelectListItem
            {
                Text = "2",
                Value = "2"

            });
            valueAdminRole.Add(new SelectListItem
            {
                Text = "3",
                Value = "3"

            });
            ViewBag.vlc = valueAdminRole;
            var adminvalue = adminMenager.GetByID(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adminMenager.AdminUpdate(p);
            return RedirectToAction("Index");
        }

      
    }
}