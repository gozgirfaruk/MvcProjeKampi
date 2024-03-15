using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentMenager cm = new ContentMenager(new EfContentDal());
        public ActionResult MyContent()
        {
            var contentvalues = cm.GetListByWriter();
            return View(contentvalues);
        }
    }
}