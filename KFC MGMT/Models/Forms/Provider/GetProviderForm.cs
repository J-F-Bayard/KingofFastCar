using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class GetProviderForm : Attribute
    {
        public int IdProvider { get; set; }

        [Display(Name = "Nom du fournisseur")]       
        public string Name { get; set; }

        [Display(Name = "Tva")]        
        public string Tva { get; set; }

        [Display(Name = "Email")]       
        public string Email { get; set; }

        [Display(Name = "Téléphone")]       
        public string Phone { get; set; }

        [Display(Name = "Rue")]        
        public string Street { get; set; }

        [Display(Name = "Numéro")]       
        public string Number { get; set; }

        [Display(Name = "CP")]      
        public int Zip { get; set; }

        [Display(Name = "Localité")]       
        public string Locality { get; set; }

        [Display(Name = "Pays")]
        public string Country { get; set; }

        [Display(Name = "Numéro de compte")]
        public string Account { get; set; }

        public bool Active { get; set; }
    }
}