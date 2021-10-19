using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface IRepo
    {
        Task<User> AddUserAsync(User resto);
        public User createUser(User newUser);

        public List<User> ListOfUsers();

        public User SearchUser(User user);

        public Task<ElementGroup> CreateElementGroupAsync(ElementGroup newElementGroup);
    }
}

