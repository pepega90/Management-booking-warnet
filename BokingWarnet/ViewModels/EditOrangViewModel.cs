using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.ViewModels
{
    public class EditOrangViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nama harus diisi!")]
        public string Nama { get; set; }
        public string namaPc { get; set; }
    }
}
