using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrMsg = "Oops! Halaman Tidak ditemukan";
                    break;
            }

            return View("NotFound");
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
