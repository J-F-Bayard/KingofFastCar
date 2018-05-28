using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolBox.DbContact;

namespace KFC_MGMT.Models.Forms
{ 
    public class EditHistoryForm : Attribute
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int IdHistory { get; set; }

        [Required]
        [Display(Name = "Voiture")]
        public string CarName { get; set; }
        public IEnumerable<SelectListItem> CarList { get; set; }

        [Required]
        [Display(Name = "Vendeur")]
        public string SellerName { get; set; }
        public IEnumerable<SelectListItem> SellerList { get; set; }

        [Required]
        [Display(Name = "Acheteur")]
        public string BuyerName { get; set; }
        public IEnumerable<SelectListItem> BuyerList { get; set; }

        [Display(Name = "Prix d'achat")]
        [Required]
        public int BuyPrice { get; set; }

        [Display(Name = "Facture d'achat")]
        [Required]
        public string BuyBill { get; set; }

        [Display(Name = "Date d'achat")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BuyDate { get; set; }

        [Display(Name = "Prix de vente")]
        [Required]
        public int SoldPrice { get; set; }

        [Display(Name = "Facture de vente")]
        public string SoldBill { get; set; }

        [Display(Name = "Date de vente")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SoldDate { get; set; }

    }
    
}
