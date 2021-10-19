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

        public async Task<Element> AddElementAsync(Element ele)
        {
            return await _repo.AddElementAsync(ele);
        }

        public async Task<Element> GetOneElementByIdAsync(int id)
        {
            return await _repo.GetOneElementByIdAsync(id);
        }

        public async Task<List<Element>> GetAllElementsAsync()
        {
            return await _repo.GetAllElementsAsync();
        }
    }
}

