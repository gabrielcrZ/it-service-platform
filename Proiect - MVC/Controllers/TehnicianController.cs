using Proiect___MVC.BLL;
using Proiect___MVC.DAL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Proiect___MVC.Controllers
{

    public class TehnicianController : Controller
    {
        TehnicianBLL objTehnicianBLL = new TehnicianBLL();
        // GET: Tehnician
        public ActionResult Index(HttpUnauthorizedResult httpUnauthorizedResult)
        {
            if (Session["user_rol"].Equals(1))
            {
                return View();
            }
            else
            {
                return httpUnauthorizedResult;
            }

        }
        public ActionResult ListaClienti(HttpUnauthorizedResult httpUnauthorizedResult, string nume_client)
        {
            if (Session["user_rol"].Equals(1))
            {
                List<Client> lista_clienti = objTehnicianBLL.ListaClienti();
                if (!string.IsNullOrEmpty(nume_client))
                {
                    lista_clienti = objTehnicianBLL.CautaClient(nume_client);
                }
                return View(lista_clienti);
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpPost]
        public ActionResult StergeClient(HttpUnauthorizedResult httpUnauthorizedResult, Int64 cod_client, Int64 cod_utilizator)
        {
            if (Session["user_rol"].Equals(1))
            {
                objTehnicianBLL.StergeClient(cod_client, cod_utilizator);
                return RedirectToAction("ListaClienti");
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpGet]
        public ActionResult ModificaClient(HttpUnauthorizedResult httpUnauthorizedResult, Int64 cod_client)
        {
            if (Session["user_rol"].Equals(1))
            {
                ViewBag.Utilizatori = objTehnicianBLL.DLLutilizatori();
                Client client = objTehnicianBLL.getClientbyId(cod_client);
                return View(objTehnicianBLL.getClientbyId(cod_client));
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpPost]
        public ActionResult ModificaClient(Client client)
        {
            objTehnicianBLL.ModificaClient(client);
            return RedirectToAction("ListaClienti");
        }
        public ActionResult ModificaUtilizator(HttpUnauthorizedResult httpUnauthorizedResult, Int64 cod_client)
        {
            if (Session["user_rol"].Equals(1))
            {
                ViewBag.Roluri = objTehnicianBLL.DLLroluri();
                Utilizator utilizator = objTehnicianBLL.getUtilizatorbyClientId(cod_client);
                return View(utilizator);
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpPost]
        public ActionResult ModificaUtilizator(Utilizator utilizator)
        {
            objTehnicianBLL.ModificaUtilizator(utilizator);
            return RedirectToAction("ListaClienti");
        }

        public ActionResult ListaTehnicieni(HttpUnauthorizedResult httpUnauthorizedResult, string nume_tehnician)
        {
            if (Session["user_rol"].Equals(1))
            {
                List<Tehnician> lista_tehnicieni = objTehnicianBLL.ListaTehnicieni();
                if (!string.IsNullOrEmpty(nume_tehnician))
                {
                    lista_tehnicieni = objTehnicianBLL.CautaTehnician(nume_tehnician);
                }
                return View(lista_tehnicieni);
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpGet]
        public ActionResult ModificaTehnician(HttpUnauthorizedResult httpUnauthorizedResult, Int64 cod_tehnician)
        {
            if (Session["user_rol"].Equals(1))
            {
                ViewBag.Utilizatori = objTehnicianBLL.DLLutilizatori();
                Tehnician tehnician = objTehnicianBLL.getTehnicianbyId(cod_tehnician);
                return View(objTehnicianBLL.getTehnicianbyId(cod_tehnician));
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpPost]
        public ActionResult ModificaTehnician(Tehnician tehnician)
        {
            objTehnicianBLL.ModificaTehnician(tehnician);
            return RedirectToAction("ListaTehnicieni");
        }
        [HttpPost]
        public ActionResult StergeTehnician(HttpUnauthorizedResult httpUnauthorizedResult, Int64 cod_tehnician, Int64 cod_utilizator)
        {
            if (Session["user_rol"].Equals(1))
            {
                objTehnicianBLL.StergeTehnician(cod_tehnician, cod_utilizator);
                return RedirectToAction("ListaTehnicieni");
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        public ActionResult ModificaUtilizator1(HttpUnauthorizedResult httpUnauthorizedResult, Int64 cod_tehnician)
        {
            if (Session["user_rol"].Equals(1))
            {
                ViewBag.Roluri = objTehnicianBLL.DLLroluri();
                Utilizator utilizator = objTehnicianBLL.getUtilizatorbyTehnicianId(cod_tehnician);
                return View(utilizator);
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpPost]
        public ActionResult ModificaUtilizator1(Utilizator utilizator)
        {
            objTehnicianBLL.ModificaUtilizator(utilizator);
            return RedirectToAction("ListaTehnicieni");
        }
        public ActionResult ListaCategorii(HttpUnauthorizedResult httpUnauthorizedResult)
        {
            if (Session["user_rol"].Equals(1))
            {
                List<CategorieServiciu> lista_categorii = objTehnicianBLL.ListaCategorii();
                return View(lista_categorii);
            }
            else
            {
                return httpUnauthorizedResult;
            }

        }
        [HttpPost]
        public ActionResult StergeCategorie(HttpUnauthorizedResult httpUnauthorizedResult, Int64 cod_categorie)
        {
            if (Session["user_rol"].Equals(1))
            {
                objTehnicianBLL.StergeCategorie(cod_categorie);
                return RedirectToAction("ListaCategorii");
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        public ActionResult ModificaCategorie(HttpUnauthorizedResult httpUnauthorizedResult, Int64 cod_categorie)
        {
            if (Session["user_rol"].Equals(1))
            {
                CategorieServiciu categorieServiciu = objTehnicianBLL.getCategorieById(cod_categorie);
                return View(categorieServiciu);
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpPost]
        public ActionResult ModificaCategorie(CategorieServiciu categorieServiciu)
        {
            objTehnicianBLL.ModificaCategorie(categorieServiciu);
            return RedirectToAction("ListaCategorii");
        }
        public ActionResult AdaugaCategorie(HttpUnauthorizedResult httpUnauthorizedResult)
        {
            if (Session["user_rol"].Equals(1))
            {
                CategorieServiciu categorieServiciu = new CategorieServiciu();
                return View(categorieServiciu);
            } else
            {
                return httpUnauthorizedResult;
            }
      
        }
        [HttpPost]
        public ActionResult AdaugaCategorie(CategorieServiciu categorieServiciu)
        {
            objTehnicianBLL.AdaugaCategorie(categorieServiciu);
            return RedirectToAction("ListaCategorii");
        }
        public ActionResult ListaServicii(HttpUnauthorizedResult httpUnauthorizedResult)
        {
            if (Session["user_rol"].Equals(1))
            {
                List<Serviciu> lista_servicii = objTehnicianBLL.ListaServicii();
                return View(lista_servicii); 
            } else
            {
                return View(httpUnauthorizedResult);
            }
        }
        [HttpPost]
        public ActionResult StergeServiciul(HttpUnauthorizedResult httpUnauthorizedResult,Int64 cod_serviciu)
        {
            if (Session["user_rol"].Equals(1))
            {
                objTehnicianBLL.StergeServiciul(cod_serviciu);
                return RedirectToAction("ListaServicii");
            } else
            {
                return httpUnauthorizedResult;
            }
        }
        public ActionResult ModificaServiciul(HttpUnauthorizedResult httpUnauthorizedResult,Int64 cod_serviciu)
        {
            if (Session["user_rol"].Equals(1))
            {
                ViewBag.Categorii = objTehnicianBLL.DLLcategorii();
                Serviciu serviciu = objTehnicianBLL.getServiciuById(cod_serviciu);
                return View(serviciu);
            } else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpPost]
        public ActionResult ModificaServiciul(Serviciu serviciu)
        {
            objTehnicianBLL.ModificaServiciul(serviciu);
            return RedirectToAction("ListaServicii");
        }
        public ActionResult AdaugaServiciu(HttpUnauthorizedResult httpUnauthorizedResult)
        {
            if (Session["user_rol"].Equals(1))
            {
                ViewBag.Categorii = objTehnicianBLL.DLLcategorii();
                Serviciu serviciu = new Serviciu();
                return View(serviciu);
            }
            else
            {
                return httpUnauthorizedResult;
            }

        }
        [HttpPost]
        public ActionResult AdaugaServiciu(Serviciu serviciu)
        {
            objTehnicianBLL.AdaugaServiciu(serviciu);
            return RedirectToAction("ListaServicii");
        }
        public ActionResult ListaProgramari(HttpUnauthorizedResult httpUnauthorizedResult,String  nume_client)
        {
            if (Session["user_rol"].Equals(1))
            {
                List<Programare> lista_Programari = objTehnicianBLL.ListaProgramari();
                if (!string.IsNullOrEmpty(nume_client))
                {
                    lista_Programari = objTehnicianBLL.CautaProgramare(nume_client);
                }
                return View(lista_Programari);
            } else
            {
                return httpUnauthorizedResult;
            }
        }
        public ActionResult ProgramariAnterioare(HttpUnauthorizedResult httpUnauthorizedResult, String nume_client)
        {
            if (Session["user_rol"].Equals(1))
            {
                List<Programare> lista_Programari = objTehnicianBLL.ProgramariAnterioare();
                if (!string.IsNullOrEmpty(nume_client))
                {
                    lista_Programari = objTehnicianBLL.CautaProgramareAnterioara(nume_client);
                }
                return View(lista_Programari);
            }
            else
            {
                return httpUnauthorizedResult;
            }
        }
        public ActionResult ModificaProgramare(HttpUnauthorizedResult httpUnauthorizedResult, Int64 cod_programare)
        {
            if (Session["user_rol"].Equals(1))
            {
                ViewBag.Clienti = objTehnicianBLL.DLLclienti();
                ViewBag.Servicii = objTehnicianBLL.DLLservicii();
                Programare programare = objTehnicianBLL.getProgramareById(cod_programare);
                return View(programare);
            } else
            {
                return httpUnauthorizedResult;
            }
        }
        [HttpPost]
        public ActionResult ModificaProgramare(Programare programare)
        {
            objTehnicianBLL.ModificaProgramare(programare);
            return RedirectToAction("ListaProgramari");
        }
        [HttpPost]
        public ActionResult StergeProgramarea(HttpUnauthorizedResult httpUnauthorizedResult,Int64 cod_programare)
        {
            if (Session["user_rol"].Equals(1))
            {
                Programare programare = objTehnicianBLL.getProgramareById(cod_programare);
                objTehnicianBLL.StergeProgramarea(programare);
                return RedirectToAction("ListaProgramari");
            } else
            {
                return httpUnauthorizedResult;
            }
        }
    }
}
