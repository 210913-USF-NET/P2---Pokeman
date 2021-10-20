using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Element
    {
        public int Id { get; set; }

        public string Name { get; set; }

        List<User> Users { get; set; }

        List<Move> Moves { get; set; }

    }
}
