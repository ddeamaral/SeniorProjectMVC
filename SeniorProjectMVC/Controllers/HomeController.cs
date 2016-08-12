using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorProjectMVC.Models;

namespace SeniorProjectMVC.Controllers
{
    public class HomeController : Controller
    {

        private DataBass db = new DataBass();
        

        public ActionResult Index()
        {
            //not customized/logged in; return default view that all users will see.
            ViewBag.UserName = "Dylan";
            ViewBag.FeaturedProducts = db.Products.Where(product => product.Featured);
            ViewBag.Categories = db.Categories.ToList();
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

        public ActionResult CategoryMenu()
        {

            CategoryMenuModel categoryMenu = new CategoryMenuModel(db.Products.Where(product => product.Featured).ToList(), db.Categories.ToList());

            //ViewBag.FeaturedProducts = db.Products.Where(product => product.Featured);
            //ViewBag.Categories = db.Categories.ToList();

            return View(categoryMenu);
        }
    }
}