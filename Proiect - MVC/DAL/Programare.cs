//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Programare
    {
        public int id { get; set; }
        [Display(Name = "Data")]
        [Required(ErrorMessage = "Data este obligatorie!")]
        public System.DateTime Data_Ora { get; set; }
        public Nullable<int> id_Serviciu { get; set; }
        public Nullable<int> id_Client { get; set; }
        public Nullable<bool> Rezolvat { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Serviciu Serviciu { get; set; }
    }
}