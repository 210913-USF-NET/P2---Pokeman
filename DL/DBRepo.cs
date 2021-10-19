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

        public DBRepo(PokeMatchDb context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();

            return user;
        }

        public async Task<ElementGroup> CreateElementGroupAsync(ElementGroup newElementGroup)
        {
            await _context.AddAsync(newElementGroup);
            await _context.SaveChangesAsync();
            return newElementGroup;
        }

        public async Task<List<ElementGroup>> ListOfElementGroupsAsync()
        {
            return await _context.ElementGroups.Select(
                elementGroups => new ElementGroup()
                {
                    Id = elementGroups.Id,
                    Element = elementGroups.Element,
                    ElementID = elementGroups.ElementID
                }
            ).ToListAsync();
        }
    }
}
