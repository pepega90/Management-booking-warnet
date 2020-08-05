using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Models.DomainClass
{
    public class OrangBooking
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public DateTime? TanggalBoking { get; set; }

        public int? KomputerId { get; set; }
        public Komputer Komputer { get; set; }

    }
}
