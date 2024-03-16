using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
        Context c = new Context();

        public ActionResult Index()
        {
            string p = (string)Session["WriterMail"];
            ViewBag.d = c.Contacts.Count();
            TempData["a"] = p;
            ViewBag.a = c.Messages.Where(x => x.ReceiverMail == p).Count();
            ViewBag.b = c.Messages.Where(x => x.SenderMail == p).Count();

            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public PartialViewResult SidePartial()
        {
            var deger = TempData["a"];
            ViewBag.a = c.Messages.Where(x=>x.ReceiverMail==deger).Count();
            ViewBag.b = c.Messages.Where(x => x.SenderMail == deger).Count();
            ViewBag.d = c.Contacts.Count();
            return PartialView();
        }


        public ActionResult GetContactDetails(int id)
        {
            var contactvalue = cm.GetByID(id);
            return View(contactvalue);
        }
    }
}