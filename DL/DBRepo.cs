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
                .Select(r => new User() {
                    Id = r.Id,
                    Username = r.Username,
                    Email = r.Email,
                    Password = r.Password,
                    Gender = r.Gender,
                    Interest = r.Interest,
                    ElementId = r.ElementId,
                    profilepic = r.profilepic,

                    Matches = r.Matches.Select(a => new Match()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        ImgUrl = a.ImgUrl,
                        Messages = a.Messages,
                        UserId = a.UserId,
                        UserId2 = a.UserId2

                    }).ToList(),

                    Pokemons = r.Pokemons.Select(a => new Pokemon()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Hp = a.Hp,
                        ImgUrl = a.ImgUrl,
                        UserId = a.UserId

                    }).ToList()
                }).ToListAsync();
        }

        public async Task<List<Pokemon>> GetPokemonAsync()
        {
            return await _context.Pokemons
                .Select(r => r).ToListAsync();
        }

        public async Task<List<Element>> GetElementListAsync()
        {
            return await _context.Elements
                .Include(r => r.Users)
                .Include(r => r.Moves)
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
                        profilepic = e.profilepic,

                        Matches = e.Matches.Select(a => new Match() 
                        {
                            Id = a.Id,
                            Name = a.Name,
                            ImgUrl = a.ImgUrl,
                            Messages = a.Messages,
                            UserId = a.UserId,
                            UserId2 = a.UserId2

                        }).ToList(),

                        Pokemons = e.Pokemons.Select(a => new Pokemon() 
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Hp = a.Hp,
                            ImgUrl = a.ImgUrl,
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

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _context.Messages
                .Select(r => r).ToListAsync();
        }

        public async Task<List<Match>> GetMatchesAsync()
        {
            return await _context.Matches
                .Include(r => r.Messages)
                .Select(r => new Match()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImgUrl = r.ImgUrl,
                    UserId = r.UserId,
                    UserId2 = r.UserId2,

                    Messages = r.Messages.Select(e => new Message()
                    {
                        Id = e.Id,
                        MatchId = e.MatchId,
                        ToUser = e.ToUser,
                        FromUser = e.FromUser,
                        Recieve = e.Recieve,
                        Send = e.Send
                    }).ToList()

                }).ToListAsync();
        }

        //------------------------------------Methods For Getting Data by Id--------------------------------

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(r => r.Matches)
                .Include(r => r.Pokemons)
                .AsNoTracking()
                .Select(r => new User() 
                {
                    Id = r.Id,
                    Username = r.Username,
                    Email = r.Email,
                    Password = r.Password,
                    Gender = r.Gender,
                    Interest = r.Interest,
                    ElementId = r.ElementId,
                    profilepic = r.profilepic,

                    Matches = r.Matches.Select(a => new Match()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        ImgUrl = a.ImgUrl,
                        Messages = a.Messages,
                        UserId = a.UserId,
                        UserId2 = a.UserId2

                    }).ToList(),

                    Pokemons = r.Pokemons.Select(a => new Pokemon()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Hp = a.Hp,
                        ImgUrl = a.ImgUrl,
                        UserId = a.UserId

                    }).ToList()
                })
                .FirstOrDefaultAsync(r => r.Id == id);
        }



        public async Task<Element> GetElementByIdAsync(int id)
        {
            return await _context.Elements
            .Include(r => r.Users)
            .Include(r => r.Moves)
            .AsNoTracking()
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
                    profilepic = e.profilepic,


                    Matches = e.Matches.Select(a => new Match()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        ImgUrl = a.ImgUrl,
                        Messages = a.Messages,
                        UserId = a.UserId,
                        UserId2 = a.UserId2
                    }).ToList(),

                    Pokemons = e.Pokemons.Select(a => new Pokemon()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Hp = a.Hp,
                        ImgUrl = a.ImgUrl,
                        UserId = a.UserId

                    }).ToList()

                }).ToList(),

                Moves = r.Moves.Select(a => new Move()
                {
                    Id = a.Id,
                    action = a.action,
                    ElementId = a.ElementId
                }).ToList()
            })
            .FirstOrDefaultAsync(e => e.Id == id);
        }
        
        public async Task<Move> GetMovesFromElementIdAsync(int id)
        {
            return await _context.Moves
                .AsNoTracking()
                .Include(r => r.ElementId)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Pokemon> GetPokemonByIdAsync(int id)
        {
            return await _context.Pokemons
                .AsNoTracking()
                .Include(r => r.UserId)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Message>> GetMessagesFromMatchIdAsync(int id)
        {
            return await _context.Messages
                .AsNoTracking()
                .Select(r => r)
                .Where(r => r.MatchId == id).ToListAsync();
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            return await _context.Messages
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);

        }

        public async Task<Match> GetMatchByIdAsync(int id)
        {
            return await _context.Matches
                .Include(r => r.Messages)
                .Select(r => new Match()
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImgUrl = r.ImgUrl,
                    UserId = r.UserId,
                    UserId2 = r.UserId2,
                    Messages = r.Messages.Select(e => new Message()
                    {
                        Id = e.Id,
                        MatchId = e.MatchId,
                        ToUser = e.ToUser,
                        FromUser = e.FromUser,
                        Recieve = e.Recieve,
                        Send = e.Send
                    }).ToList()

                }).FirstOrDefaultAsync(r => r.Id == id);
        }

        //------------------------------------Methods for Adding To DB--------------------------------------

        public async Task<Element> AddElementAsync(Element ele)
        {
            await _context.AddAsync(ele);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return ele;
        }

        public async Task<Pokemon> AddPokemonAsync(Pokemon pokemon)
        {
            await _context.AddAsync(pokemon);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return pokemon;
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

        public async Task<Message> AddMessageAsync(Message message)
        {
            await _context.AddAsync(message);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return message;
        }

        public async Task<Match> AddMatchAsync(Match match)
        {
            await _context.AddAsync(match);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return match;
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
                ElementId = user.ElementId,
                profilepic = user.profilepic,
                Pokemons = user.Pokemons
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

        public async Task<Pokemon> UpdatePokemonAsync(Pokemon pokemon)
        {
            _context.Pokemons.Update(pokemon);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return new Pokemon()
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                Hp = pokemon.Hp,
                ImgUrl = pokemon.ImgUrl,
                UserId = pokemon.UserId
            };
        }

        //------------------------------------Methods for Deleting From DB---------------------------------

        public async Task DeleteMoveAsync(int id)
        {
            _context.Moves.Remove(await GetMovesFromElementIdAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task DeletePokemonAsync(int id)
        {
            _context.Pokemons.Remove(await GetPokemonByIdAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task DeleteUserAsync(int id)
        {
            _context.Users.Remove(await GetUserByIdAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task DeleteElementAsync(int id)
        {
            _context.Elements.Remove(await GetElementByIdAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task DeleteMessageAsync(int id)
        {
            _context.Messages.Remove(await GetMessageByIdAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task DeleteMatchAsync(int id)
        {
            _context.Matches.Remove(await GetMatchByIdAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

      
    }
}
