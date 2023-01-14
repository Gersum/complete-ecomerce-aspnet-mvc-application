using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAll();
            return View(allCinemas);
        }

        //Get: Cinemas/create
        public IActionResult Create()
        {
            return View();
        } 

        //Post : Cinemas/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));

        }

        //Get: Cinemas/Details/1
        public async Task <IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotExist");

            return View(cinemaDetails);
                        
        }

        //Get: Cinemas/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotExist");

            return View(cinemaDetails);

        }

        //Post : Cinemas/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            await _service.UpdateAsync(id,cinema);
            return RedirectToAction(nameof(Index));

        }

        //Get: Cinemas/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotExist");

            return View(cinemaDetails);

        }

        //Post : Cinemas/Delete/1
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
