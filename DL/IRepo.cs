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
        
        Task<List<Element>> GetElementListAsync();

        Task<List<Move>> GetMoveList();

        //------------------------------------Methods For Getting Data by Id--------------------------------

        Task<Element> GetOneElementByIdAsync(int id);

        Task<Move> GetMovesFromElementIdAsync(int id);

        //------------------------------------Methods for Adding To DB--------------------------------------

        Task<User> AddUserAsync(User user);

        Task<Element> AddElementAsync(Element ele);

        Task<Move> AddMoveAsync(Move move);


        //------------------------------------Methods for Updating DB--------------------------------------


        //------------------------------------Methods for Deleting From DB---------------------------------

        Task RemoveMoveAsync(int id);
    }
}

