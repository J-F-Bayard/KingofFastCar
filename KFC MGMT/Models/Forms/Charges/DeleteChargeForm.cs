using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFC_MGMT.Models.Forms.Charges
{
    public class DeleteChargeForm : Attribute
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int IdCharge { get; set; }

        public int IdHistory { get; set; }
        [Display(Name = "Nom du dossier")]
        public string HistoryName { get; set; }

        public int IdProvider { get; set; }
        [Display(Name = "Nom du fournisseur")]
        public string ProviderName { get; set; }

        [Display(Name = "Libellé")]
        public string Entitled { get; set; }

        [Display(Name = "Montant")]
        public double Amount { get; set; }

        [Display(Name = "Numéro de facture")]
        public string BillNumber { get; set; }

        [Display(Name = "Date de prestation")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }

    }
}


