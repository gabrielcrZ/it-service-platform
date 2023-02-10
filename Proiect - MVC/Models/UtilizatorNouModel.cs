using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proiect___MVC.Models
{
    public class UtilizatorNouModel
    {
        [Required(ErrorMessage = "Numele de utilizator este obligatoriu!")]
        [Display(Name = "Nume Utilizator")]
        [StringLength(50,ErrorMessage = "Numele de utilizator trebuie sa contina cel putin 4 caractere!",MinimumLength = 4)]
        public string nume_utilizator { get; set; }
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola este obligatorie!")]
        [StringLength(50, ErrorMessage = "Parola trebuie sa contina cel putin 6 caractere!", MinimumLength = 6)]
        public string parola { get; set; }
        [Required(ErrorMessage = "Numele este obligatoriu!")]
        [StringLength(50, ErrorMessage = "Numele trebuie sa contina cel putin 4 caractere!", MinimumLength = 4)]
        public string Nume { get; set; }
        [Display(Name = "Adresa email")]
        [Required(ErrorMessage = "Adresa de email este obligatorie!")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este valida!")]
        public string email { get; set; }
        public int id_Rol { get; set; }



    }
}