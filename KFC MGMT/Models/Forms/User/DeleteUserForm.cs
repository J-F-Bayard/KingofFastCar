using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class DeleteUserForm : Attribute
    {
        [Display(Name = "Id du user")]
        [Required]
        public int IdUser { get; set; }
                
    }
}