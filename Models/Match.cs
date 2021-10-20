using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Match
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        List<Message> Messages { get; set; }

    }
}
