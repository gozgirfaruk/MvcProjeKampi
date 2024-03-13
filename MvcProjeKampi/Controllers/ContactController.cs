using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactMenager cm = new ContactMenager(new EfContactDal());
        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public PartialViewResult SidePartial()
        {
            return PartialView();
        }


        public ActionResult GetContactDetails(int id)
        {
            var contactvalue = cm.GetByID(id);
            return View(contactvalue);
        }
    }
}