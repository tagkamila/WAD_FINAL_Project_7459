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

namespace WAD_CW_7459.Controllers
{
    public class BooksController : Controller
    {
        private readonly IRepository<Book> _bookRepo;
        private readonly IRepository<Reservation> _reservationRepo;
        public BooksController(IRepository<Book> bookRepo, IRepository<Reservation> reservationRepo)
        {
            _bookRepo = bookRepo;
            _reservationRepo = reservationRepo;
           
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _bookRepo.GetAllAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepo.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ReservationId"] = new SelectList(await _reservationRepo.GetAllAsync(), "Id", "Title");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Authors,YearPublished,Publisher,Category,ReservationId")] Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookRepo.CreateAsync(book);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReservationId"] = new SelectList(await _reservationRepo.GetAllAsync(), "Id", "Title", book.ReservationId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepo.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["ReservationId"] = new SelectList(await _reservationRepo.GetAllAsync(), "Id", "Title", book.ReservationId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Authors,YearPublished,Publisher,Category,ReservationId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookRepo.UpdateAsync(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_bookRepo.Exists(book.Id))
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
            ViewData["ReservationId"] = new SelectList(await _reservationRepo.GetAllAsync(), "Id", "Title", book.ReservationId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepo.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
