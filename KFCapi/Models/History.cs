namespace KFCapi.Models
{
    using System;
   
    public partial class History
    {
        public int IdHistory { get; set; }
        public int IdCar { get; set; }
        public int IdSeller { get; set; }
        public int IdBuyer { get; set; }        
        public int BuyPrice { get; set; }
        public int SoldPrice { get; set; }
        public bool Active { get; set; }
        public string BuyBill { get; set; }
        public string SoldBill { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SoldDate { get; set; }

    }
}
