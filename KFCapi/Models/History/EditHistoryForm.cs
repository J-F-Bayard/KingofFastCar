using KFCapi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToolBox.DbContact;

namespace KFC_MGMT.Models.Forms
{ 
    public class EditHistoryForm : Attribute
    {
        [Display(Name = "Dossier")]
        [Required]
        public int IdHistory { get; set; }

        [Display(Name = "Voiture")]
            
        public int IdCar { get; set; }

        [Display(Name = "Vendeur")]
       
        public int IdSeller { get; set; }

        [Display(Name = "Acheteur")]
       
        public int IdBuyer { get; set; }

        [Display(Name = "Prix d'achat")]
     
        public double BuyPrice { get; set; }

        [Display(Name = "Prix de vente")]
      
        public double SoldPrice { get; set; }

        [Display(Name = "Actif")]
       
        public bool Active { get; set; }
     
    }
    
}
