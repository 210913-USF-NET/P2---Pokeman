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

        public async Task<ElementGroup> CreateElementGroup(ElementGroup newElementGroup)
        {
            await _context.AddAsync(newElementGroup);
            await _context.SaveChangesAsync();
            return newElementGroup;
        }

        public async Task<List<ElementGroup>> ListOfElementGroups()
        {
            return await _context.ElementGroups.Select(
                elementgroups => new ElementGroup()
                {
                    Id = elementgroups.Id,
                    Element = elementgroups.Element,
                    ElementID = elementgroups.ElementID
                }
            ).ToListAsync();
        }
    }
}
