
using KFCapi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToolBox.DbContact;

namespace KFC_MGMT.Models.Forms
{ 
    public class AddHistoryForm : Attribute
    {
  
        [Display(Name = "Voiture")]
        [Required]        
        public int IdCar { get; set; }

        [Display(Name = "Vendeur")]
        [Required]
        public int IdSeller { get; set; }

        [Display(Name = "Acheteur")]
        [Required]
        public int IdBuyer { get; set; }

        [Display(Name = "Prix d'achat")]
        [Required]
        public double BuyPrice { get; set; }

        [Display(Name = "Prix de vente")]
        [Required]
        public double SoldPrice { get; set; }

        [Display(Name = "Actif")]
        [Required]
        public bool Active { get; set; }
     
    }
    
}
