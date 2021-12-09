using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MobileDAL;
using U30SampleApp.Models;

namespace U30SampleApp.Controllers
{
    public class AddToOrderController : Controller
    {
        MobileDetailDAL _mdal = new MobileDetailDAL();

        // GET: AddToOrder
        public ActionResult Add(ProductDetails pd)
        {

            //If session does not exist, create new cart session
            if(Session["cart"] == null)
            {
                List<ProductDetails> li = new List<ProductDetails>();

                li.Add(pd);
                Session["cart"] = li;
                ViewBag.cart = li.Count();

                //Session to count products added
                Session["count"] = 1;
            }

            else
            {
                List<ProductDetails> li = (List<ProductDetails>)Session["cart"];
                li.Add(pd);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult OrderReview()
        {
            return View((List<ProductDetails>)Session["cart"]); //Return list of all items in cart
        }

        public ActionResult Remove(ProductDetails mob)
        {
            List<ProductDetails> li = (List<ProductDetails>)Session["cart"];
            li.RemoveAll(x => x.PhoneID == mob.PhoneID); //Find location of item to delete
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("OrderReview", "AddToOrder"); //Return to order details
        }
    }
}