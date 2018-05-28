using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class DeleteSellerForm : Attribute
    {
        public int IdSeller { get; set; }
                
    }
}