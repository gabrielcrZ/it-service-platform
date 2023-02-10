using Proiect___MVC.BLL;
using Proiect___MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Proiect___MVC.Controllers
{
    public class ClientController : Controller
    {
        ClientBLL objClientBLL = new ClientBLL();
        // GET: Client
        public ActionResult Index()
        {
            if (Session["user_rol"].Equals(1) || Session["user_rol"].Equals(2))
            {
                return View();
            } else
            {
                return RedirectToRoute("Login");
            }
        }
        public ActionResult ListaProgramari()
        {
            Int64 cod_client = (int)Session["user_id"];
            List<Programare> lista_programari = objClientBLL.ListaProgramari(cod_client).ToList();
            return View(lista_programari);
        }
        public ActionResult ClientProgramare(HttpUnauthorizedResult httpUnauthorizedResult)
        {
            if (Session["user_rol"] != null)
            {
                ViewBag.Servicii = objClientBLL.DDLservicii();
                Programare programare = new Programare();
                return View(programare);
            } else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpPost]
        public ActionResult ClientProgramare(Programare programare)
        {
            programare.id_Client = (int)Session["user_id"];
            programare.Rezolvat = false;
            objClientBLL.ClientProgramare(programare);
            return RedirectToAction("Index");
        }
        public ActionResult ListaServicii(HttpUnauthorizedResult httpUnauthorizedResult)
        {
            if (Session["user_rol"] != null)
            {
                List<Serviciu> lista_servicii = objClientBLL.ListaServicii();
                return View(lista_servicii);
            } else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpPost]
        public ActionResult AnuleazaProgramare(Int64 cod_programare)
        {
            objClientBLL.AnuleazaProgramare(cod_programare);
            return RedirectToAction("ListaProgramari");
        }
    }
}