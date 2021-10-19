using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public class DBRepo : IRepo
    {
        private PokeMatchDb _context;

        public async Task<User> AddUserAsync(User user)
        {
            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
