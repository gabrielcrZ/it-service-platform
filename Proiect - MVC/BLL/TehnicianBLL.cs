using Proiect___MVC.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Proiect___MVC.Models;
using System.Web.Mvc;

namespace Proiect___MVC.BLL
{
    public class TehnicianBLL
    {
        private BD_Entities bd;
        public TehnicianBLL()
        {
            bd = new BD_Entities();
        }
        public List<Client> ListaClienti()
        {
            List<Client> lista_clienti = bd.Client.ToList();
            return lista_clienti;
        }

        public List<Client> CautaClient(string nume_client)
        {
            List<Client> clienti_gasiti = bd.Client.Where(nc => nc.Nume.Contains(nume_client)).ToList();
            return clienti_gasiti;
        }
        public void StergeClient(Int64 cod_client, Int64 cod_utilizator) 
        {
            Client client_deSters = bd.Client.Find(cod_client);
            Utilizator utilizator_deSters = bd.Utilizator.Find(cod_utilizator);
            bd.Client.Remove(client_deSters);
            bd.Utilizator.Remove(utilizator_deSters);
            bd.SaveChanges();
        }
        public Client getClientbyId(Int64 id_Client)
        {
            return bd.Client.Find(id_Client);
        }
        public void ModificaClient(Client client)
        {
            bd.Entry(client).State = EntityState.Modified;
            bd.SaveChanges();
        }
        public void ModificaUtilizator(Utilizator utilizator)
        {
            bd.Entry(utilizator).State = EntityState.Modified;
            bd.SaveChanges();
        }
        public Utilizator getUtilizatorbyClientId(Int64 cod_client)
        {
            Client client = bd.Client.Where(cl => cl.id == cod_client).FirstOrDefault();
            return (bd.Utilizator.Where(u => u.id == client.id_Utilizator).FirstOrDefault());
        }
        public Utilizator getUtilizatorbyTehnicianId(Int64 cod_tehnician)
        {
            Tehnician tehnician = bd.Tehnician.Where(th => th.id == cod_tehnician).FirstOrDefault();
            return (bd.Utilizator.Where(u => u.id == tehnician.id_Utilizator).FirstOrDefault());
        }
        public Tehnician getTehnicianbyId(Int64 id_tehnician)
        {
            return bd.Tehnician.Find(id_tehnician); 
        }
        public CategorieServiciu getCategorieById(Int64 cod_categorie)
        {
            return bd.CategorieServiciu.Find(cod_categorie);
        }

        public List<Tehnician> ListaTehnicieni()
        {
            List<Tehnician> lista_tehnicieni = bd.Tehnician.ToList();
            return lista_tehnicieni;
        }

        public List<Tehnician> CautaTehnician(string nume_tehnician)
        {
            List<Tehnician> tehnicieni_gasiti = bd.Tehnician.Where(nc => nc.Nume.Contains(nume_tehnician)).ToList();
            return tehnicieni_gasiti;
        }
        public void ModificaTehnician(Tehnician tehnician)
        {
            bd.Entry(tehnician).State = EntityState.Modified;
            bd.SaveChanges();
        }
        public void StergeTehnician(Int64 cod_tehnician, Int64 cod_utilizator)
        {
            Tehnician tehnician_deSters = bd.Tehnician.Find(cod_tehnician);
            Utilizator utilizator_deSters = bd.Utilizator.Find(cod_utilizator);
            bd.Tehnician.Remove(tehnician_deSters);
            bd.Utilizator.Remove(utilizator_deSters);
            bd.SaveChanges();
        }
        public void ModificaUtilizator1(Utilizator utilizator)
        {
            bd.Entry(utilizator).State = EntityState.Modified;
            bd.SaveChanges();
        }
        public List<CategorieServiciu> ListaCategorii()
        {
            List<CategorieServiciu> lista_categorii = bd.CategorieServiciu.ToList();
            return lista_categorii;
        }
        public void StergeCategorie(Int64 cod_categorie)
        {
            CategorieServiciu categorieServiciu = bd.CategorieServiciu.Where(cs => cs.id == cod_categorie).FirstOrDefault();
            bd.CategorieServiciu.Remove(categorieServiciu);
            bd.SaveChanges();
        }
        public void ModificaCategorie(CategorieServiciu categorieServiciu)
        {
            bd.Entry(categorieServiciu).State = EntityState.Modified;
            bd.SaveChanges(); ;
        }
        public CategorieServiciu AdaugaCategorie(CategorieServiciu categorieServiciu)
        {
            bd.CategorieServiciu.Add(categorieServiciu);
            bd.SaveChanges();
            return categorieServiciu;
        }
        public List<Serviciu> ListaServicii()
        {
            List<Serviciu> lista_servicii = bd.Serviciu.ToList();
            return lista_servicii;
        }
        public void StergeServiciul(Int64 cod_serivciu)
        {
            Serviciu serviciu = bd.Serviciu.Where(s => s.id == cod_serivciu).FirstOrDefault();
            bd.Serviciu.Remove(serviciu);
            bd.SaveChanges();
        }
        public void ModificaServiciul(Serviciu serviciu)
        {
            bd.Entry(serviciu).State = EntityState.Modified;
            bd.SaveChanges();
        }
        public Serviciu getServiciuById(Int64 cod_serviciu)
        {
            return bd.Serviciu.Find(cod_serviciu);
        }
        public Serviciu AdaugaServiciu(Serviciu serviciu)
        {
            bd.Serviciu.Add(serviciu);
            bd.SaveChanges();
            return serviciu;
        }
        public List<Programare> ListaProgramari()
        {
            List<Programare> lista_Programari = bd.Programare.Where(lp => lp.Data_Ora >= DateTime.Now).ToList();
            return lista_Programari;
        }

        public List<Programare> CautaProgramare (string nume_client)
        {
            List<Programare> programari_Gasite = bd.Programare.Where(pg => pg.Client.Nume.Contains(nume_client) && pg.Data_Ora >= DateTime.Now).ToList();
            return programari_Gasite;
        }
        public List<Programare> ProgramariAnterioare()
        {
            List<Programare> lista_Programari = bd.Programare.Where(lp => lp.Data_Ora < DateTime.Now).ToList();
            return lista_Programari;
        }

        public List<Programare> CautaProgramareAnterioara(string nume_client)
        {
            List<Programare> programari_Gasite = bd.Programare.Where(pg => pg.Client.Nume.Contains(nume_client) && pg.Data_Ora < DateTime.Now).ToList();
            return programari_Gasite;
        }
        public void ModificaProgramare(Programare programare)
        {
            bd.Entry(programare).State = EntityState.Modified;
            bd.SaveChanges();
        }
        public Programare getProgramareById(Int64 cod_programare)
        {
            return bd.Programare.Where(p => p.id == cod_programare).FirstOrDefault();
        }
        public void StergeProgramarea(Programare programare)
        {
            bd.Programare.Remove(programare);
            bd.SaveChanges();
        }
        public IEnumerable<Utilizator> DLLutilizatori()
        {
            IEnumerable<Utilizator> lista = bd.Utilizator.ToList();
            return lista;
        }
        public IEnumerable<Rol> DLLroluri()
        {
            IEnumerable<Rol> lista = bd.Rol.ToList();
            return lista;
        }
        public IEnumerable<CategorieServiciu> DLLcategorii()
        {
            IEnumerable<CategorieServiciu> lista = bd.CategorieServiciu.ToList();
            return lista;
        }
        public IEnumerable<Client> DLLclienti()
        {
            IEnumerable<Client> lista = bd.Client.ToList();
            return lista;
        }
        public IEnumerable<Serviciu> DLLservicii()
        {
            IEnumerable<Serviciu> lista = bd.Serviciu.ToList();
            return lista;
        }


    }
}