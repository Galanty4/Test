using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsFormsApp1.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Items = new HashSet<Item>();
        }

        public int IdWarehouse { get; set; }
        public int WarehouseAdres { get; set; }
        public string WarehouseName { get; set; }
        public int Company { get; set; }

        public virtual Company CompanyNavigation { get; set; }
        public virtual Adre WarehouseAdresNavigation { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
