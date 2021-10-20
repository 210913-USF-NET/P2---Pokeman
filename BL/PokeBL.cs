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

        //------------------------------------Methods For Getting List--------------------------------------

        public async Task<List<User>> GetUserListAsync()
        {
            return await _repo.GetUserListAsync();
        }

        public async Task<List<Element>> GetElementListAsync()
        {
            return await _repo.GetElementListAsync();
        }

        public async Task<List<Move>> GetMoveListAsync()
        {
            return await _repo.GetMoveListAsync();
        }

        //------------------------------------Methods For Getting Data by Id--------------------------------

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _repo.GetUserByIdAsync(id);
        }

        public async Task<Element> GetElementByIdAsync(int id)
        {
            return await _repo.GetElementByIdAsync(id);
        }

        public async Task<Move> GetMovesFromElementIdAsync(int id)
        {
            return await _repo.GetMovesFromElementIdAsync(id);
        }

        //------------------------------------Methods for Adding To DB--------------------------------------

        public async Task<User> AddUserAsync(User user)
        {
            return await _repo.AddUserAsync(user);

        }

        public async Task<Element> AddElementAsync(Element ele)
        {
            return await _repo.AddElementAsync(ele);
        }

        public async Task<Move> AddMoveAsync(Move move)
        {
            return await _repo.AddMoveAsync(move);
        }


        //------------------------------------Methods for Updating DB--------------------------------------

        public async Task<User> UpdateUserAsync(User user)
        {
            return await _repo.UpdateUserAsync(user);
        }

        public async Task<Element> UpdateElementAsync(Element element)
        {
            return await _repo.UpdateElementAsync(element);
        }

        //------------------------------------Methods for Deleting From DB---------------------------------

        public async Task RemoveMoveAsync(int id)
        {
            await _repo.RemoveMoveAsync(id);
        }

    }
}
