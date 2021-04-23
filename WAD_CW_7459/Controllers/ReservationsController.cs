
















using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WAD_CW_7459.DAL;
using WAD_CW_7459.DAL.DBO;
using WAD_CW_7459.DAL.Repositories;
using WAD_CW_7459.Models;

namespace WAD_CW_7459.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IRepository<Reservation> _reservationRepo;


        public ReservationsController(IRepository<Reservation> reservationRepo)
        {
            
            _reservationRepo = reservationRepo;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            return View(await _reservationRepo.GetAllAsync());
           
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _reservationRepo.GetByIdAsync(id.Value);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateOfReservation,Title,UserId,BookId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                await _reservationRepo.CreateAsync(reservation);
              
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _reservationRepo.GetByIdAsync(id.Value);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfReservation,Title,UserId,BookId")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _reservationRepo.UpdateAsync(reservation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_reservationRepo.Exists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _reservationRepo.GetByIdAsync(id.Value);
              
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _reservationRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

     
    }
}
