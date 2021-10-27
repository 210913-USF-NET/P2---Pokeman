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

        public async Task<List<Message>> GetMessageAsync()
        {
            return await _repo.GetMessagesAsync();
        }

        public async Task<List<Match>> GetMatchAsync()
        {
            return await _repo.GetMatchesAsync();
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

        public async Task<List<Message>> GetMessagesFromMatchIdAsync(int id)
        {
            return await _repo.GetMessagesFromMatchIdAsync(id);
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            return await _repo.GetMessageByIdAsync(id);
        }

        public async Task<Match> GetMatchByIdAsync(int id)
        {
            return await _repo.GetMatchByIdAsync(id);
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

        public async Task<Message> AddMessageAsync(Message message)
        {
            return await _repo.AddMessageAsync(message);
        }

        public async Task<Match> AddMatchAsync(Match match)
        {
            return await _repo.AddMatchAsync(match);
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

        public async Task DeleteMoveAsync(int id)
        {
            await _repo.DeleteMoveAsync(id);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _repo.DeleteUserAsync(id);
        }

        public async Task DeleteElementAsync(int id)
        {
            await _repo.DeleteElementAsync(id);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _repo.DeleteMessageAsync(id);
        }

        public async Task DeleteMatchAsync(int id)
        {
            await _repo.DeleteMatchAsync(id);
        }
    }
}
