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
       

        public async Task<Move> CreateMoveAsync(Move move)
        {
            await _context.AddAsync(move);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return move;
        }

        public async Task<List<Move>> GetAllMovesAsync()
        {
            return await _context.Moves
                .Select(r => r).ToListAsync();
        }

        public async Task<Move> GetMovesFromElementIdAsync(int id)
        {
            return await _context.Moves
                //this include method joins reviews table with the restaurant table
                //and grabs all reviews that references the selected restaurant
                //by restaurantId
                // .Include("Reviews")
                .AsNoTracking()
                //.Include(r => r.Element)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
