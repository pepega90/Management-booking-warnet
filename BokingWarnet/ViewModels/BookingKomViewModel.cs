using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.ViewModels
{
    public class BookingKomViewModel
    {
        public int OrangId { get; set; }
        public string NamaOrang { get; set; }
        public int? KomputerId { get; set; }

        [DataType(DataType.Time)]
        public DateTime JamBooking { get; set; }
        public bool IsSelected { get; set; }
    }
}
