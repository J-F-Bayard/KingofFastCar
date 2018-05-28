using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class GetBuyerForm : Attribute
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int IdBuyer { get; set; }

        [Display(Name = "Nom de l'acheteur")]      
        public string LastName { get; set; }

        [Display(Name = "Prénom")]       
        public string FirstName { get; set; }

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

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public bool Active { get; set; }
    }
}