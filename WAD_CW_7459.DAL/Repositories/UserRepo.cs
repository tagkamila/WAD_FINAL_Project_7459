using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD_CW_7459.DAL.DBO;

namespace WAD_CW_7459.DAL.Repositories
{
  public class UserRepo : BaseRepo, IRepository<User>
    {
      

        public UserRepo(TheBooksLibraryDbContext context): base(context)
        {
            
        }
        public async Task CreateAsync(User entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.Include(u => u.Reservation).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Reservation)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public bool Exists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

    }
}
