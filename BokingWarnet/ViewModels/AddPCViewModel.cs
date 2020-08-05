using BokingWarnet.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.ViewModels
{
    public class AddPCViewModel
    {
        [Required(ErrorMessage = "Nama PC tidak boleh kosong!")]
        public string NamaPC { get; set; }
        public string Status { get; set; }
    }
}
