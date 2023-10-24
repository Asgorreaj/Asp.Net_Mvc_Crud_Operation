using Antlr.Runtime.Misc;
using Microsoft.Ajax.Utilities;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication12.EF;

namespace WebApplication12.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult showAllDetails()
        {
            var db = new trydborderEntities();
            var data = db.Products.ToList();

            return View(data);
        }

        public ActionResult showAllDetailsEdit()
        {
            var db = new trydborderEntities();
            var data = db.Products.ToList();

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
            
        }
        [HttpPost]
        public ActionResult Create(Product p) { 
            var db  = new trydborderEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("showAllDetails");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new trydborderEntities();
            var ex = (from p in db.Products
                      where p.product_id == id 
                      select p).SingleOrDefault();
            return View(ex);
            
        }
        [HttpPost]
        public ActionResult Edit(Product p) { 
            var db  = new trydborderEntities();
            var exdata = db.Products.Find(p.product_id);
            exdata.product_name = p.product_name;
            exdata.price = p.price;
            db.SaveChanges();
            return RedirectToAction("showAllDetails");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new trydborderEntities();
            var exdata = db.Products.Find(id);
            return View(exdata);

        }
        [HttpPost]
        public ActionResult Delete(int id, string action)
        {
            if (action == "Delete")
            {
                var db = new trydborderEntities();
                var exdata = db.Products.Find(id);
                db.Products.Remove(exdata);
                db.SaveChanges();
                return RedirectToAction("showAllDetails");
            }
            else
            {
                return RedirectToAction("showAllDetails");
            }
        }

        [HttpGet]
        public ActionResult AddToCart(int? id)
        {
            var db  = new trydborderEntities();
            var data = (from products in db.Products
                        where products.product_id == id
                        select products).SingleOrDefault();
            if (data != null)
            {
                var cart = Session["key"] as List<Product>;
                if (cart == null)
                {
                    cart = new List<Product>();
                }
                cart.Add(data);

                Session["key"] = cart;
            }
            return RedirectToAction("showAllDetails");
        }

        [HttpGet]
        public ActionResult showCart()
        {
            var cart = Session["key"];
            return View(cart);
        }
        
       








    }
}