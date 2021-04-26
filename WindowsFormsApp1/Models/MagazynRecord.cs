using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsFormsApp1.Models
{
    public partial class MagazynRecord
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime? DateRented { get; set; }
        public DateTime? DataReturned { get; set; }
        public decimal? Cost { get; set; }
        public int? TypeOfCarId { get; set; }

        public virtual TypeOfCar TypeOfCar { get; set; }
    }
}
