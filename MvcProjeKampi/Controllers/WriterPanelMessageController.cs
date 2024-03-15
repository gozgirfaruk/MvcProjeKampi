using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageMenager mm = new MessageMenager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public ActionResult Sendbox()
        {
            var messagelist = mm.GetListSendbox();
            return View(messagelist);
        }

        public ActionResult GetSendMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public PartialViewResult PartialMenu()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = messageValidator.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = "gozgirfaruk@gmail.com";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }

            return View();
        }
    }
}