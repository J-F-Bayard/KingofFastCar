using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolBox.DbContact;

namespace KFC_MGMT.Models.Forms
{ 
    public class GetHistoryForm : Attribute
    {
        [Display(Name = "Numéro du dossier")]
        [Key]
        public int IdHistory { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdCar { get; set; }

        [Display(Name = "Voiture")]
        public string CarName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdSeller { get; set; }

        [Display(Name = "Nom du vendeur")]
        public string SellerName { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public int IdBuyer { get; set; }

        [Display(Name = "Nom de l'acheteur")]
        public string BuyerName { get; set; }

        [Display(Name = "Prix d'achat")]     
        public int BuyPrice { get; set; }

        [Display(Name = "Facture d'achat")]
        public string BuyBill { get; set; }

        [Display(Name = "Date d'achat")]
        [DataType(DataType.Date)]
        public DateTime BuyDate { get; set; }

        [Display(Name = "Prix de vente")]      
        public int SoldPrice { get; set; }

        [Display(Name = "Facture de vente")]
        public string SoldBill { get; set; }

        [Display(Name = "Date de vente")]
        [DataType(DataType.Date)]
        public DateTime SoldDate { get; set; }

    }
    
}
