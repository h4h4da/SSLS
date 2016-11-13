using SSLS.Domain.Abstract;
using SSLS.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSLS.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private ILibrarysRepository repository;
        public AdminController(ILibrarysRepository r)
        {
            repository = r;
        }


        private IEnumerable<SelectListItem> GetCategorySelectList()
        {
            return
                repository.Categories.ToList().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
        }
        public ActionResult BookIndex()
        {
            return View(repository.Books.ToList());
        }

        public ActionResult CategoryIndex()
        {
            return View(repository.Categories.ToList());
        }

        public ActionResult BookEdit(int id)
        {
            Book book = repository.Books.FirstOrDefault(p => p.Id == id);
            ViewBag.CategoryList = GetCategorySelectList();
            return View(book);
        }

        [HttpPost]
        public ActionResult BookEdit(Book b)
        {

            if (ModelState.IsValid)
            {
                repository.SaveBook(b);
                TempData["msg"] = string.Format("{0} 保存成功", b.Name);
                return View("CategoryIndex");
            }
            else
            {
                IEnumerable<SelectListItem> selectListItem = GetCategorySelectList();
                ViewBag.CategoryList = selectListItem;
                return View(b);

            }
        }

        public ActionResult BookCreate()
        {
            ViewBag.CategoryList = GetCategorySelectList();
            return View("BookEdit", new Book());
        }

        public ActionResult CategoryEdit(int id)
        {
            Category category = repository.Categories.FirstOrDefault(c => c.Id == id);

            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(category);
                TempData["msg"] = string.Format("{0} 保存成功", category.Name);
                return View("CategoryIndex");
            }
            else {
                return View(category);
            }
            
        }

        public ActionResult CategoryCreate()
        {
            return View("CategoryEdit",new Category());
        }
    }
}