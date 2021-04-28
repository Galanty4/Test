using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsFormsApp1.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int Sender { get; set; }
        public int Purchaser { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int OrderItem { get; set; }

        public virtual Adre FromNavigation { get; set; }
        public virtual Item OrderItemNavigation { get; set; }
        public virtual Person PurchaserNavigation { get; set; }
        public virtual Person SenderNavigation { get; set; }
        public virtual Adre ToNavigation { get; set; }
    }
}
