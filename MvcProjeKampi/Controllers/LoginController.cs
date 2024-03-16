using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        WriterLoginMenager wlm = new WriterLoginMenager(new EfWriterDal());
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
            
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.eMail == p.eMail && x.Password == p.Password);
            var writeruserinfo = wlm.GetWriter(p.eMail, p.Password);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.eMail, false);
                Session["WriterMail"] = writeruserinfo.eMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }

            else
            {
                return RedirectToAction("WriterLogin");
            }
        
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }     
    }
}