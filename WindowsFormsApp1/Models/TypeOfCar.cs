using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsFormsApp1.Models
{
    public partial class TypeOfCar
    {
        public TypeOfCar()
        {
            MagazynRecords = new HashSet<MagazynRecord>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MagazynRecord> MagazynRecords { get; set; }
    }
}
