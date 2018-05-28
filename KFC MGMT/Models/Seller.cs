namespace KFC_MGMT.Models
{
    using System;

    public partial class Seller
    {
        public int IdSeller { get; set; }
        public string Name { get; set; }
        public int Tva { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int Zip { get; set; }
        public string Locality { get; set; }
        public string Country { get; set; }
        public string Account { get; set; }
        public bool Active { get; set; }
    }
}
