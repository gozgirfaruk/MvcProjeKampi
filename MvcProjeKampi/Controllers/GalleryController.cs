using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
         IMegaMenager mm = new IMegaMenager(new EfImageFileDal());
        public ActionResult Index()
        {
            var values = mm.GetList();
            return View(values);
        }
    }
}