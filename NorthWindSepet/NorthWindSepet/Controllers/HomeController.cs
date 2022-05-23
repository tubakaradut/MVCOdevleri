using NorthWindSepet.Helpers;
using NorthWindSepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWindSepet.Controllers
{
    public class HomeController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            return View(db.Products.Where(x => x.CategoryID != null && x.UnitsInStock > 0).ToList());
        }

        public ActionResult AddToCart(int id)
        {
            try
            {
                Product product = db.Products.Find(id);
                Cart c = null;
                if (Session["scart"] == null)
                {
                    c = new Cart();
                }
                else
                {
                    c = Session["scart"] as Cart;
                }

                CartItem ci = new CartItem();
                ci.Id = product.ProductID;
                ci.ProductName = product.ProductName;
                ci.Price = product.UnitPrice;
                c.AddItem(ci);
                Session["scart"] = c;

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["error"] = $"{id} karşılık gelen bir ürün bulunamadı!";
                return View();

            }
        }

        public ActionResult MyCart()
        {
            if (Session["scart"] != null)
            {
                return View();
            }
            else
            {
                TempData["error"] = "sepetinizde ürün bulunmamaktadır!";
                return RedirectToAction("Index");
            }
        }
        public ActionResult DeleteCartItem(int id)
        {
            Cart cart = Session["scart"] as Cart;

            if (cart != null)
            {
                cart.DeleteItem(id);
            }

            return RedirectToAction("MyCart");
        }
        public ActionResult CompleteCart()
        {
            Cart cart = Session["scart"] as Cart;
            User user = Session["user"] as User;
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (cart != null)
            {
                string productList = "";
                foreach (var item in cart.myCart)
                {
                    Product product = db.Products.Find(item.Id);
                    product.UnitsInStock -= Convert.ToInt16(item.Quantity);
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    productList += $"<li>{item.ProductName} -- {item.Price}</li>";
                }

                Random rnd = new Random();
                ViewBag.OrderNumber = rnd.Next(1, 1000);
                string content = $"Alışveriş Listeniz; <br> Sipariş Numaranız: {ViewBag.OrderNumber} <br/> <ul>{productList}</ul>";
                MailHelper.SendEmail(user.Email, "Sipariş Maili", content);

                Session.Remove("scart");
            }
            return View();
        }


    }
}