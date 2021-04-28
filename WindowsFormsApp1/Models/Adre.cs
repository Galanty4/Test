using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsFormsApp1.Models
{
    public partial class Adre
    {
        public Adre()
        {
            Companies = new HashSet<Company>();
            OrderFromNavigations = new HashSet<Order>();
            OrderToNavigations = new HashSet<Order>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int IdAdres { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string Local { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Order> OrderFromNavigations { get; set; }
        public virtual ICollection<Order> OrderToNavigations { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
