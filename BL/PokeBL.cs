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

        public PokeBL(IRepo irepo)
        {
            _repo = irepo;
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await _repo.AddUserAsync(user);
        }

        public async Task<ElementGroup> CreateElementGroupAsync(ElementGroup newElementGroup)
        {
            return await _repo.CreateElementGroupAsync(newElementGroup);
        }
    }
}
