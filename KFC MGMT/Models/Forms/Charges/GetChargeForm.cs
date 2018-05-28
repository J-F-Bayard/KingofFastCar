using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFC_MGMT.Models.Forms.Charges
{
    public class GetChargeForm : Attribute
    {

        public int IdCharge { get; set; }

        [Display(Name = "Numéro du dossier")]  
        [Required]
        public int IdHistory { get; set; }

        [Display(Name = "Voiture du dossier")]        
        public string Carname { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdProvider { get; set; }

        [Display(Name = "Nom du fournisseur")]
        [MinLength(2)]
        public string ProviderName { get; set; }       

        [Display(Name = "Libellé")]
        [Required]
        public string Entitled { get; set; }

        [Display(Name = "Montant")]
        [Required]
        public double Amount { get; set; }

        [Display(Name = "Numéro de facture")]
        [Required]
        public string BillNumber { get; set; }

        [Display(Name = "Date de prestation")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DeliveryDate { get; set; }
        
    }
}


