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
    public class CartController : Controller
    {
        // GET: Cart
   

        private ILibrarysRepository repository;
       
        public CartController(ILibrarysRepository repositoryParam)
        {
            this.repository = repositoryParam;
       
        }

        

        public ViewResult Index(string returnUrl,Cart cart)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });

        }

        public int AddToCart(Cart cart, int id, string returnUrl)
        {
            Book product = repository.Books.FirstOrDefault(p => p.Id == id);
            if (product != null) return cart.AddSingleItem(product);
            else return -2;
        }
       

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            Book product = repository.Books.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("index", new { returnUrl });
        }

    }
}