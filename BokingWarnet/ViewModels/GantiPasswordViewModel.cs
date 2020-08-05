using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.ViewModels
{
    public class GantiPasswordViewModel
    {
        [Required(ErrorMessage = "Masukkan Password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Masukkan Password Baru")]
        [DataType(DataType.Password)]
        public string PasswordBaru { get; set; }

        [Required(ErrorMessage = "Konfirmasi Password")]
        [DataType(DataType.Password)]
        [Compare("PasswordBaru", ErrorMessage = "Konfirmasi Password tidak sama dengan Password!")]
        public string KonfirmasiPassword { get; set; }

    }
}
