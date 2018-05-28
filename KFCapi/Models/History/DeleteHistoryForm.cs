using KFCapi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToolBox.DbContact;

namespace KFC_MGMT.Models.Forms
{ 
    public class DeleteHistoryForm : Attribute
    {
        [Display(Name = "Dossier")]
        [Required]
        public int IdHistory { get; set; }       

    }
    
}
