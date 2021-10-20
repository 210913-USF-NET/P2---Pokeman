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
            return await _context.Elements
                .Include(r => r.Users)
                .Select(r => new Element()
                {
                    Id = r.Id,
                    Name = r.Name, 

                    Users = r.Users.Select(e => new User()
                    {
                        Id = e.Id,
                        Username = e.Username,
                        Email = e.Email,
                        Password = e.Password,
                        Gender = e.Gender,
                        Interest = e.Interest,
                        ElementId = e.ElementId,

                        Matches = e.Matches.Select(a => new Match() 
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Messages = a.Messages,
                            UserId = a.UserId

                        }).ToList(),

                        Pokemons = e.Pokemons.Select(a => new Pokemon() 
                        {
                            Id = a.Id,
                            Name = a.Name,
                            UserId = a.UserId
                            
                        }).ToList()
                    }).ToList(),

                    Moves = r.Moves.Select(e => new Move() 
                    {
                        Id = e.Id,
                        action = e.action,
                        ElementId = e.ElementId
                    }).ToList()

                }).ToListAsync();
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

        public async Task<Element> GetElementByIdAsync(int id)
        {
            return await _context.Elements
            .Include(r => r.Users)
            .FirstOrDefaultAsync(e => e.Id == id);

            
        }

        public async Task<Move> GetMovesFromElementIdAsync(int id)
        {
            return await _context.Moves
                .AsNoTracking()
                .Include(r => r.ElementId)
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

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return new User()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Gender = user.Gender,
                Interest = user.Interest,
                ElementId = user.ElementId
            };
        }

        public async Task<Element> UpdateElementAsync(Element element)
        {
            _context.Elements.Update(element);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return new Element()
            {
                Id = element.Id,
                Name = element.Name
            };
        }

        //------------------------------------Methods for Deleting From DB---------------------------------

        public async Task RemoveMoveAsync(int id)
        {
            _context.Moves.Remove(await GetMovesFromElementIdAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
    }
}
