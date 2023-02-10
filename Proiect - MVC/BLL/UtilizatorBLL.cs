using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI.WebControls;
using Proiect___MVC.DAL;
using Proiect___MVC.Models;

namespace Proiect___MVC.BLL
{
    
    public class UtilizatorBLL
    {
        private BD_Entities bd;

        public UtilizatorBLL()
        {
            bd = new BD_Entities();
        }

        public Utilizator Login(Utilizator user)
        {
            var user_curent = bd.Utilizator.Where(un => un.nume_utilizator.Equals(user.nume_utilizator)
            && un.parola.Equals(user.parola)).FirstOrDefault();
            return user_curent;
        }
        public Utilizator Register(UtilizatorNouModel userModel)
        {
            Utilizator user = new Utilizator() { nume_utilizator = userModel.nume_utilizator, parola= userModel.parola, email=userModel.email,
            id_Rol=2};
            bd.Utilizator.Add(user);
            Client client = new Client() { Nume = userModel.Nume, id_Utilizator = user.id};
            bd.Client.Add(client);
            bd.SaveChanges();
            return user;
        }
        
    }

}