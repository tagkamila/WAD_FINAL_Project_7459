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
    public class UsersController : Controller
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Reservation> _reservationRepo;

        public UsersController(IRepository<User> userRepo, IRepository<Reservation> reservationRepo)
        {
            _userRepo = userRepo;
            _reservationRepo = reservationRepo;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
           
            return View(await _userRepo.GetAllAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepo.GetByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ReservationId"] = new SelectList( await _reservationRepo.GetAllAsync(), "Id", "Title");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PassportNumber,TelNumber,Email,ReservationId")] User user)
        {
            if (ModelState.IsValid)
            {
                await _userRepo.CreateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReservationId"] = new SelectList(await _reservationRepo.GetAllAsync(), "Id", "Title", user.ReservationId);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepo.GetByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["ReservationId"] = new SelectList(await _reservationRepo.GetAllAsync(), "Id", "Title", user.ReservationId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PassportNumber,TelNumber,Email,ReservationId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userRepo.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_userRepo.Exists(user.Id))
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
            ViewData["ReservationId"] = new SelectList(await _reservationRepo.GetAllAsync(), "Id", "Title", user.ReservationId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepo.GetByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
