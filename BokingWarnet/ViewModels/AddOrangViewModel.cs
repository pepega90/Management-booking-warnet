using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.ViewModels
{
    public class AddOrangViewModel
    {
        [Required(ErrorMessage = "Nama Pelangan Harus diisi")]
        public string Nama { get; set; }

        //public List<SelectListItem> Komputers { get; set; }
    }
}
