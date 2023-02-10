using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proiect___MVC.DAL;
using Proiect___MVC.BLL;
using Proiect___MVC.Models;

namespace Proiect___MVC.Controllers
{
    public class UtilizatorController : Controller
    {
        UtilizatorBLL objUtilizatorBLL = new UtilizatorBLL();
        // GET: Utilizator
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Utilizator user)
        {
            Utilizator user_curent = objUtilizatorBLL.Login(user);
            if (ModelState.IsValid && user_curent != null && user_curent.id_Rol.Equals(1))
            {
                Session["user_name"] = user_curent.nume_utilizator.ToString();
                Session["user_id"] = user_curent.id;
                Session["user_rol"] = user_curent.id_Rol;
                
                return RedirectToAction("Index", "Tehnician");
            }
            else if (ModelState.IsValid && user_curent != null && !user_curent.id_Rol.Equals(1))
            {
                Session["user_name"] = user_curent.nume_utilizator.ToString();
                Session["user_id"] = user_curent.id;
                Session["user_rol"] = user_curent.id_Rol;
                return RedirectToAction("Index", "Client");
            }
            else
            {
                return RedirectToAction("Login", "Utilizator");
            }
        }
        public ActionResult Register()
        {
            UtilizatorNouModel user = new UtilizatorNouModel();
            return View(user);  
        }
        [HttpPost]
        public ActionResult Register(UtilizatorNouModel userModel) 
        {   
            if (ModelState.IsValid)
            {
                objUtilizatorBLL.Register(userModel);
                return RedirectToAction("Login");
            } else
            {
                return RedirectToAction("Register");
            }

        }
        public bool isLoggedIn()
        {
            if (string.IsNullOrEmpty(Session["user_name"].ToString()))
            {
                return false;
            } else
            {
                return true;
            }
        }
        public ActionResult Logout()
        {
            Session["user_name"] = null;
            Session["user_id"] = null;
            Session["user_rol"] = null;
            return RedirectToRoute("Login");
        }
    }
}