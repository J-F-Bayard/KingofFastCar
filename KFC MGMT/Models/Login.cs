using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Models
{
    public partial class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Authentified { get; set; }
    }
}