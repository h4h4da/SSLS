using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSLS.Domain.Abstract;

using SSLS.WebUI.Models;
using SSLS.Domain.Concrete;

namespace SSLS.WebUI.Controllers
{
    public class BookController : Controller
    {
        private ILibrarysRepository repository;

        public int PageSize = 5;

        public BookController(ILibrarysRepository p)
        {
            repository = p;
        }
   
        public ActionResult Index()
        {
            return View();
        }
       
       [HttpPost]
        public ViewResult List(BooksListViewModel model)
        {

            IQueryable<Book> productlist = repository.Books;
            if (model.SearchBookStr != null) {
                productlist = repository.Books.Where(p => p.Name.Contains(model.SearchBookStr));
            }
            BooksListViewModel viewModel = new BooksListViewModel
            {
                Books = productlist.OrderBy(P => P.Id).Skip((0) * PageSize).Take(PageSize),
                paginginfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = PageSize,
                    TotalItems = productlist.Count()
                },
                CurrentCategoryId = -1
            };
            return View("List",viewModel);
        }

        public ActionResult List(int categoryId = 0, int page = 1)
        {

            IQueryable<Book> productlist = repository.Books;
            if(categoryId > 0)
            {
                productlist = repository.Books.Where(p => p.CategoryId == categoryId);
            }

            BooksListViewModel viewModel = new BooksListViewModel
            {
                Books = productlist.OrderBy(P => P.Id).Skip((page - 1) * PageSize).Take(PageSize),
                paginginfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = productlist.Count()
                },
                CurrentCategoryId = categoryId
            };
            return View(viewModel);
        }
    }
}