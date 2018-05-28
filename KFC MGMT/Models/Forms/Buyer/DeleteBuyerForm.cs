using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class DeleteBuyerForm : Attribute
    {
        [Display(Name = "Id de l'acheteur")]
        [Required]
       
        public int IdBuyer { get; set; }
    }
}