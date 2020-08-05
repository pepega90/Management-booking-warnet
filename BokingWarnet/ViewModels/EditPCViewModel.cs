using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.ViewModels
{
    public class EditPCViewModel : AddPCViewModel
    {
        public int Id { get; set; }
        public List<SelectListItem> StatusPC { get; set; } = new List<SelectListItem>();

        // Properti  untuk status pc yang dipilih di selecte tag
        public string Stats { get; set; }
    }
}
