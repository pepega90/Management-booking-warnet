using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Models.DomainClass
{
    public class Komputer
    {
        public int Id { get; set; }
        public string NamaKomputer { get; set; }
        public string Status { get; set; }

        public ICollection<OrangBooking> OrangBookings { get; set; } = new List<OrangBooking>();
    }
}
