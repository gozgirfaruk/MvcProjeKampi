﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.Name == p.Name && x.Password == p.Password);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.Name, false);
                Session["AdminUserName"] = adminuserinfo.Name;
                return RedirectToAction("Index", "AdminCategory");
            }

            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}