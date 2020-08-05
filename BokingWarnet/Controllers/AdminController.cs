using BokingWarnet.Models;
using BokingWarnet.Models.DomainClass;
using BokingWarnet.Models.Repository;
using BokingWarnet.Utility;
using BokingWarnet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Controllers
{
    public class AdminController : Controller
    {
        private readonly IKomputerRepository komputerRepository;
        private readonly IOrangBookingRepository orangBookingRepo;
        private readonly AppDbContext appDbContext;

        public AdminController(IKomputerRepository komputerRepository
                                , IOrangBookingRepository orangBooking,
                                    AppDbContext appDbContext)
        {
            this.komputerRepository = komputerRepository;
            orangBookingRepo = orangBooking;
            this.appDbContext = appDbContext;
        }

        public IActionResult Booking()
        {
            var bokingViewModel = new BokingViewModel();
            foreach (var item in komputerRepository.GetAllKomputer())
            {
                bokingViewModel.komputers.Add(item);
            }

            foreach (var orang in appDbContext.OrangBooking.ToList())
            {
                bokingViewModel.listOrangBooking.Add(orang);
            }

            return View(bokingViewModel);
        }

        [HttpGet]
        public IActionResult TambahBokingan(int pcId)
        {
            ViewBag.pcId = pcId;

            var komputer = appDbContext.Komputers.Find(pcId);

            var model = new List<BookingKomViewModel>();

            foreach (var item in appDbContext.OrangBooking.ToList())
            {

                var bookingViewModel = new BookingKomViewModel
                {
                    OrangId = item.Id,
                    NamaOrang = item.Nama,
                    IsSelected = false
                };

                model.Add(bookingViewModel);
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult TambahBokingan(List<BookingKomViewModel> model, int pcId)
        {

            var komputer = appDbContext.Komputers.Find(pcId);

            var selectedOrang = model.Where(e => e.IsSelected).Select(e => e);

            foreach (var item in selectedOrang)
            {
                OrangBooking orang = new OrangBooking()
                {
                    Id = item.OrangId,
                    Nama = item.NamaOrang,
                    KomputerId = komputer.Id,
                    TanggalBoking = item.JamBooking
                };

                komputer.OrangBookings.Add(orang);
            }

            appDbContext.SaveChanges();

            return RedirectToAction("Booking");
        }

        [HttpPost]
        public IActionResult HapusBookingKom(int orangId)
        {
            var orangBooking = appDbContext.OrangBooking.Find(orangId);

            orangBooking.KomputerId = null;

            appDbContext.SaveChanges();

            return RedirectToAction("Booking");
        }

        [HttpGet]
        public IActionResult AddPC()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPC(AddPCViewModel model)
        {
            if (ModelState.IsValid)
            {
                var komputer = new Komputer()
                {
                    NamaKomputer = model.NamaPC,
                    Status = "Berfungsi"
                };
                komputerRepository.AddKomputer(komputer);
                return RedirectToAction("ListKomputer");
            }
            return View();
        }


        [HttpGet]
        public IActionResult EditPC(int Id)
        {
            Komputer komputer = appDbContext.Komputers.Find(Id);


            EditPCViewModel model = new EditPCViewModel()
            {
                Id = komputer.Id,
                NamaPC = komputer.NamaKomputer,
                StatusPC = StatusPC.GetStatus().Select(status => new SelectListItem()
                {
                    Value = status,
                    Text = status
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditPC(EditPCViewModel model)
        {

            if (ModelState.IsValid)
            {
                Komputer komputer = appDbContext.Komputers.Find(model.Id);
                komputer.NamaKomputer = model.NamaPC;
                komputer.Status = model.Stats;

                komputerRepository.EditKomputer(komputer);

                return RedirectToAction("ListKomputer");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult HapusKomputer(int Id)
        {
            komputerRepository.HapusKomputer(Id);
            return RedirectToAction("ListKomputer");
        }


        public IActionResult ListKomputer()
        {
            var model = komputerRepository.GetAllKomputer();
            return View(model);
        }


        [HttpGet]
        public IActionResult AddOrang()
        {
            //var model = new AddOrangViewModel();
            //model.Komputers = komputerRepository.GetAllKomputer()
            //                    .Select(x => new SelectListItem()
            //                    {
            //                        Value = x.Id.ToString(),
            //                        Text = x.NamaKomputer
            //                    }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddOrang(AddOrangViewModel model)
        {
            if (ModelState.IsValid)
            {

                OrangBooking orangBooking = new OrangBooking()
                {
                    Nama = model.Nama
                };
                orangBookingRepo.TambahOrang(orangBooking);
                return RedirectToAction("ListBokingan");
            }
            return View();
        }


        [HttpGet]
        public IActionResult EditOrang(int Id)
        {
            OrangBooking orangBooking = appDbContext.Find<OrangBooking>(Id);

            var komputerInfo = komputerRepository.FindKomputerById(Convert.ToInt32(orangBooking.KomputerId));

            EditOrangViewModel model = new EditOrangViewModel
            {
                Id = orangBooking.Id,
                Nama = orangBooking.Nama,
                namaPc = komputerInfo.NamaKomputer
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditOrang(EditOrangViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            OrangBooking orangBooking = appDbContext.OrangBooking.Find(model.Id);
            orangBooking.Nama = model.Nama;

            orangBookingRepo.EditOrang(orangBooking);

            return RedirectToAction("ListBokingan");
        }

        [HttpPost]
        public IActionResult HapusOrang(int Id)
        {
            orangBookingRepo.HapusOrang(Id);
            return RedirectToAction("ListBokingan");
        }


        public IActionResult ListBokingan()
        {
            var model = orangBookingRepo.GetAllOrangBookings();
            return View(model);
        }
    }
}
