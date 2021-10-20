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


        //------------------------------------Methods For Getting List--------------------------------------

        public async Task<List<User>> GetUserListAsync()
        {
            return await _context.Users
                .Select(r => r).ToListAsync();
        }

        public async Task<List<Element>> GetElementListAsync()
        {
            return await _context.Elements.Select(e => e).ToListAsync();
        }

        public async Task<List<Move>> GetMoveListAsync()
        {
            return await _context.Moves
                .Select(r => r).ToListAsync();
        }

        //------------------------------------Methods For Getting Data by Id--------------------------------

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Element> GetOneElementByIdAsync(int id)
        {
            return await _context.Elements
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Move> GetMovesFromElementIdAsync(int id)
        {
            return await _context.Moves
                .AsNoTracking()
                .Include(r => r.ElementGroupId)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        //------------------------------------Methods for Adding To DB--------------------------------------

        public async Task<Element> AddElementAsync(Element ele)
        {
            await _context.AddAsync(ele);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return ele;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return user;
        }

        public async Task<Move> AddMoveAsync(Move move)
        {
            await _context.AddAsync(move);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return move;
        }

        //------------------------------------Methods for Updating DB--------------------------------------



        //------------------------------------Methods for Deleting From DB---------------------------------

        public async Task RemoveMoveAsync(int id)
        {
            _context.Moves.Remove(await GetMovesFromElementIdAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
    }
}
