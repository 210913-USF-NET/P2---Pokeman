using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class DBRepo : IRepo
    {
        private PokeMatchDb _context;

        public DBRepo(PokeMatchDb context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        //Element
        public async Task<Element> AddElementAsync (Element ele)
        {
            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();

            return ele;
        }

        public async Task<Element> GetOneElementByIdAsync(int id)
        {
            return await _context.Elements
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Element>> GetAllElementsAsync()
        {
            return await _context.Elements.Select(e => e).ToListAsync();
        }
    }
}
