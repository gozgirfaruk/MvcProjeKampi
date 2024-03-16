using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        ContentMenager cm = new ContentMenager(new EfContentDal());
        // GET: Default
        HeadingMenager hm = new HeadingMenager(new EfHeadingDal());
        // GET: Default
        public ActionResult Headings()
        {
            var values = hm.GetList();
            return View(values);
        }

        public PartialViewResult PartialIndex(int id=1)
        {
            var contentlist = cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}