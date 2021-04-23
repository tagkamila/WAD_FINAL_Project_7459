using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD_CW_7459.DAL.DBO;

namespace WAD_CW_7459.DAL.Repositories
{
    public abstract class BaseRepo
    {
        protected readonly TheBooksLibraryDbContext _context;
        protected BaseRepo(TheBooksLibraryDbContext context)
        {
            _context = context;
        }
    }
}
