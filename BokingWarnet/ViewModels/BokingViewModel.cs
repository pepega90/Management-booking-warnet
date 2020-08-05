using BokingWarnet.Models.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.ViewModels
{
    public class BokingViewModel
    {
        public IList<Komputer> komputers { get; set; } = new List<Komputer>();

        public IList<OrangBooking> listOrangBooking { get; set; } = new List<OrangBooking>();
    }
}
