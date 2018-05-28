using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFC_MGMT.Models.Forms.Charges
{
    public class AddChargeForm : Attribute
    {
        [Required]
        [Display(Name = "Nom du dossier")]
        public string HistoryName { get; set; }
        public IEnumerable<SelectListItem> HistoryList{get; set;}

        [Required]
        [Display(Name = "Nom du fournisseur")]
        public string ProviderName { get; set; }
        public IEnumerable<SelectListItem> ProviderList { get; set; }

        [Display(Name = "Libellé")]
        [Required]
        [MinLength(2)]
        public string Entitled { get; set; }

        [Display(Name = "Montant")]
        [Required]     
        public double Amount { get; set; }

        [Display(Name = "Numero de facture")]
        [Required]        
        public string BillNumber { get; set; }

        [Display(Name = "Date de prestation")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        
    }
}


