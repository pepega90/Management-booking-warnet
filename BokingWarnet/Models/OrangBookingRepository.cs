using BokingWarnet.Models.DomainClass;
using BokingWarnet.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Models
{
    public class OrangBookingRepository : IOrangBookingRepository
    {
        private readonly AppDbContext appDbContext;

        public OrangBookingRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public OrangBooking EditOrang(OrangBooking orangBooking)
        {
            appDbContext.OrangBooking.Update(orangBooking);
            appDbContext.SaveChanges();
            return orangBooking;
        }

        public IEnumerable<OrangBooking> GetAllOrangBookings()
        {
            return appDbContext.OrangBooking;
        }

        public void HapusOrang(int Id)
        {
            var deletedOrang = appDbContext.OrangBooking.Find(Id);
            appDbContext.OrangBooking.Remove(deletedOrang);
            appDbContext.SaveChanges();
        }

        public OrangBooking TambahOrang(OrangBooking orangBooking)
        {
            appDbContext.OrangBooking.Add(orangBooking);
            appDbContext.SaveChanges();
            return orangBooking;
        }
    }
}
