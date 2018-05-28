using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFC_MGMT.Models.Forms.Charges
{
    public class EditChargeForm : Attribute
    {

        [HiddenInput(DisplayValue = false)]
        [Key]
        public int IdCharge { get; set; }

        [Required]
        [Display(Name = "Nom du dossier")]
        public string HistoryId { get; set; }
        public IEnumerable<SelectListItem> HistoryList { get; set; }

        [Required]
        [Display(Name = "Nom du fournisseur")]
        public string ProviderName { get; set; }
        public IEnumerable<SelectListItem> ProviderList { get; set; }

        [Display(Name = "Libellé")]
        [Required]
        [MinLength(2)]
        public string Entitled { get; set; }

        [Required]
        [Display(Name = "Montant")]    
        public double Amount { get; set; }

        [Display(Name = "Numéro de facture")]
        [Required]
        public string BillNumber { get; set; }

        [Display(Name = "Date de prestation")]
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }
        
    }
}


