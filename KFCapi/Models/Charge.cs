namespace KFCapi.Models
{
    using System;
    
    public partial class Charge
    {
        public int IdCharge { get; set; }
        public int IdHistory { get; set; }
        public int IdProvider { get; set; }
        public string Entitled { get; set; }
        public double Amount { get; set; }
        public string BillNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool Active { get; set; }
    
    }
}
