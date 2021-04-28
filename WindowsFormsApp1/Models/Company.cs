using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsFormsApp1.Models
{
    public partial class Company
    {
        public Company()
        {
            People = new HashSet<Person>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int IdCompany { get; set; }
        public string CompanyNape { get; set; }
        public string Nip { get; set; }
        public int CompanAdres { get; set; }

        public virtual Adre CompanAdresNavigation { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
