using SSLS.Domain.Abstract;
using SSLS.Domain.Concrete;
using SSLS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSLS.WebUI.Controllers
{
    public class ReaderController : Controller
    {
        private ILibrarysRepository repository;
        // GET: Reader

        public ReaderController(ILibrarysRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginTest()
        {
            return View();
        }

        [HttpPost]
        public string GetDate()
        {
            //Save User Code Here
            //......

            return "Save Complete!";
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Reader readerEntry = repository.Readers.FirstOrDefault(c => c.Id == model.UserName && c.Password == model.PassWord);
                if (readerEntry != null)
                {
                    HttpContext.Session["Reader"] = readerEntry;
                    return Redirect(returnUrl ?? Url.Action("List", "Book"));
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码不正确");
                    return View();
                }
            }
            else
                return View();
        }
    }
}