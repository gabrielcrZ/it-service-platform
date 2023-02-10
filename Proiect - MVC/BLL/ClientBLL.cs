using Proiect___MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect___MVC.BLL
{
    public class ClientBLL
    {
        private BD_Entities bd;

        public ClientBLL()
        {
            bd = new BD_Entities();
        }
        public List<Programare> ListaProgramari(Int64 cod_client)
        {
            return bd.Programare.Where(p => p.Client.id == cod_client && p.Data_Ora >= DateTime.Now).ToList();
        }
        public Programare CreeazaProgramare()
        {
            Programare programare = new Programare();
            return programare;
        }
        public Programare ClientProgramare(Programare programare)
        {
            bd.Programare.Add(programare);
            bd.SaveChanges();
            return programare; 
        }
        public List<Serviciu> ListaServicii()
        {
            return bd.Serviciu.ToList();
        }
        public void AnuleazaProgramare(Int64 cod_programare)
        {
            Programare programare = bd.Programare.Where(p => p.id == cod_programare).FirstOrDefault();
            bd.Programare.Remove(programare);
            bd.SaveChanges();
        }
        public IEnumerable<Serviciu> DDLservicii()
        {
            IEnumerable<Serviciu> lista = bd.Serviciu.ToList();
            return lista;
        }
    }
}