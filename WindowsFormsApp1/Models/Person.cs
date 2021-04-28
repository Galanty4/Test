using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsFormsApp1.Models
{
    public partial class Person
    {
        public Person()
        {
            OrderPurchaserNavigations = new HashSet<Order>();
            OrderSenderNavigations = new HashSet<Order>();
        }

        public int IdPeople { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public byte[] Pesel { get; set; }
        public int? Job { get; set; }

        public virtual Company JobNavigation { get; set; }
        public virtual ICollection<Order> OrderPurchaserNavigations { get; set; }
        public virtual ICollection<Order> OrderSenderNavigations { get; set; }
    }
}
