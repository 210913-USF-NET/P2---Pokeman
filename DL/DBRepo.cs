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
        
        //Users
        public User createUser(User newUser)
        {
            newUser = _context.Add(newUser).Entity;
            _context.SaveChanges();
            return newUser;
        }

        public List<User> ListOfUsers()
        {
            return _context.Users.Select(
                users => new User()
                {
                    Id = users.Id,
                    Username = users.Username,
                    Password = users.Password,
                    Email = users.Email,
                    ElementId = users.ElementId
                }
            ).ToList();
        }

        public User SearchUser(User user)
        {
            List<User> userList = ListOfUsers();
            for (int i = 0; i < userList.Count; i++)
            {
                if (user.Username == userList[i].Username && user.Password == userList[i].Password)
                {
                    return new User
                    {
                        Id = userList[i].Id,
                        Username = userList[i].Username,
                        Password = userList[i].Password,
                        Email = userList[i].Email,
                        ElementId = userList[i].ElementId
                    };
                }
            }
            return null;
        }

        //Element
        public async Task<Element> AddElementAsync (Element ele)
        {
            await _context.AddAsync(ele);

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
