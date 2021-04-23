using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD_CW_7459.DAL.DBO;

namespace WAD_CW_7459.DAL.Repositories
{
    public class ReservationRepo : BaseRepo, IRepository<Reservation>
    {


        public ReservationRepo(TheBooksLibraryDbContext context) : base(context)
        {

        }
        public async Task CreateAsync(Reservation entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations
                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Reservation entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public bool Exists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
