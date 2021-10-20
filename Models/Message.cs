using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Message
    {
        public int Id { get; set; }

        public string ToUser { get; set; }

        public string FromUser { get; set; }

        public string Send { get; set; }

        public string Recieve { get; set; }

        public int MatchId { get; set; }

    }
}
