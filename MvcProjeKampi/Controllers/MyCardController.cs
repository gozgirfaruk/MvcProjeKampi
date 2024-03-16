using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MyCardController : Controller
    {
        // GET: MyCard
        SkillMenager sm = new SkillMenager(new EfSkillDal());
        public ActionResult Index()
        {
            var values = sm.GetList();
            return View(values);
        }
    }
}