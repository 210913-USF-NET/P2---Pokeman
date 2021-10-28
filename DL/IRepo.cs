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

        //------------------------------------Methods For Getting List--------------------------------------

        Task<List<User>> GetUserListAsync();

        Task<List<Element>> GetElementListAsync();

        Task<List<Move>> GetMoveListAsync();

        Task<List<Message>> GetMessagesAsync();

        Task<List<Match>> GetMatchesAsync();

        Task<List<Pokemon>> GetPokemonAsync();

        //------------------------------------Methods For Getting Data by Id--------------------------------

        Task<User> GetUserByIdAsync(int id);

        Task<Element> GetElementByIdAsync(int id);

        Task<Move> GetMovesFromElementIdAsync(int id);

        Task<List<Message>> GetMessagesFromMatchIdAsync(int id);

        Task<Message> GetMessageByIdAsync(int id);

        Task<Match> GetMatchByIdAsync(int id);

        Task<Pokemon> GetPokemonByIdAsync(int id);

        //------------------------------------Methods for Adding To DB--------------------------------------

        Task<User> AddUserAsync(User user);

        Task<Element> AddElementAsync(Element ele);

        Task<Move> AddMoveAsync(Move move);

        Task<Message> AddMessageAsync(Message message);

        Task<Match> AddMatchAsync(Match match);

        Task<Pokemon> AddPokemonAsync(Pokemon pokemon);


        //------------------------------------Methods for Updating DB--------------------------------------

        Task<User> UpdateUserAsync(User user);

        Task<Element> UpdateElementAsync(Element element);

        Task<Pokemon> UpdatePokemonAsync(Pokemon pokemon);

        //------------------------------------Methods for Deleting From DB---------------------------------

        Task DeleteMoveAsync(int id);

        Task DeletePokemonAsync(int id);

        Task DeleteUserAsync(int id);

        Task DeleteElementAsync(int id);

        Task DeleteMessageAsync(int id);

        Task DeleteMatchAsync(int id);
        
    }
}

