using BokingWarnet.Models.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Models.Repository
{
    public interface IOrangBookingRepository
    {
        OrangBooking TambahOrang(OrangBooking orangBooking);

        IEnumerable<OrangBooking> GetAllOrangBookings();

        OrangBooking EditOrang(OrangBooking orangBooking);

        void HapusOrang(int Id);
    }
}
