using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DL;

namespace BL
{
    public class PokeBL : IBL
    {
        private IRepo _repo;
        public User createUser(User newUser) { return _repo.createUser(newUser); }
        public List<User> ListOfUsers() { return _repo.ListOfUsers(); }

        public User SearchUser(User user) { return _repo.SearchUser(user); }

        public PokeBL(IRepo irepo)
        {
            _repo = irepo;

        }
    }
}
