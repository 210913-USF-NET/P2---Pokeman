using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DL;

namespace BL
{
    public interface IBL
    {
        public User createUser(User newUser);

        public List<User> ListOfUsers();

        public User SearchUser(User user);
    }
}
