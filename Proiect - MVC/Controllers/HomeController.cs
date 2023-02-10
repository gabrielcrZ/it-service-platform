using Proiect___MVC.BLL;
using Proiect___MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proiect___MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if (Session["user_name"] == null)
            //{
            //    return RedirectToRoute("Login");
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult Autentificare()
        {
            return RedirectToRoute("Login");
        }
    }
}