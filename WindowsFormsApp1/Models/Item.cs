using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsFormsApp1.Models
{
    public partial class Item
    {
        public Item()
        {
            Orders = new HashSet<Order>();
        }

        public int IdItem { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public int? Location { get; set; }
        public int Category { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual Warehouse LocationNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
