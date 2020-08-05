using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.ViewModels
{
    public class LoginPageViewModel
    {
        [Required(ErrorMessage = "Username tidak boleh kosong!")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password tidak boleh kosong!")]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
