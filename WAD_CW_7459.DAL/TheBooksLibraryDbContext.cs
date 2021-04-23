using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_CW_7459.DAL.DBO;

namespace WAD_CW_7459.DAL
{
    public class TheBooksLibraryDbContext : DbContext
    {
        public TheBooksLibraryDbContext(DbContextOptions<TheBooksLibraryDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}
