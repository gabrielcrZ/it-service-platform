﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proiect___MVC.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BD_Entities : DbContext
    {
        public BD_Entities()
            : base("name=BD_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategorieServiciu> CategorieServiciu { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Programare> Programare { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Serviciu> Serviciu { get; set; }
        public virtual DbSet<Tehnician> Tehnician { get; set; }
        public virtual DbSet<Utilizator> Utilizator { get; set; }
    }
}
