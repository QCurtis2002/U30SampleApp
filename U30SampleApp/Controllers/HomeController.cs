using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U30SampleApp.Models;
using MobileDAL;
using System.Data;

namespace U30SampleApp.Controllers
{
    public class HomeController : Controller
    {

        MobileDetailDAL _mdal = new MobileDetailDAL();
        DataTable dt;

        public ActionResult Index()
        {
            string mycmd = "SELECT * FROM Phones"; //Create the query

            dt = new DataTable(); // New datatable to store results
            dt = _mdal.SelectAll(mycmd); //Execute against the db
            List<Phones> list = new List<Phones>(); //New list of phones

            //Extract and arrange data for each database entry in result set
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Phones phone = new Phones();
                phone.PhoneID = Convert.ToInt32(dt.Rows[i]["PhoneID"]);
                phone.PhoneName = dt.Rows[i]["PhoneName"].ToString();
                phone.Manufacturer = dt.Rows[i]["PhoneDescription"].ToString();
                phone.Image = dt.Rows[i]["Image"].ToString();
                list.Add(phone);
            }

            return View(list); //Return data to the view
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

        public ActionResult ProductDetails(Phones m)
        {
            // Set the query
            string mycmd = "SELECT p.PhoneID, p.PhoneName, p.Image, s.Price, s.Colour, s.Storage FROM Phones p " + " INNER JOIN Storage s ON p.PhoneID = s.fkPhoneID WHERE p.PhoneID = " + m.PhoneID + "";
            DataTable dt = new DataTable();

            dt = _mdal.SelectAll(mycmd);

            List<ProductDetails> list = new List<ProductDetails>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductDetails mob = new ProductDetails();
                mob.PhoneID = Convert.ToInt32(dt.Rows[i]["PhoneID"]);
                mob.PhoneName = dt.Rows[i]["PhoneName"].ToString();
                mob.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                mob.Image = dt.Rows[i]["Image"].ToString();
                mob.Colour = (dt.Rows[i]["Colour"].ToString());
                mob.Storage = dt.Rows[i]["Storage"].ToString();

                list.Add(mob);
            }

            return View(list);
        }

    }
}