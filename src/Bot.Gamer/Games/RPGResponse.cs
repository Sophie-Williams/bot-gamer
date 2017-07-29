using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot.Gamer.Games
{
    public class RPGResponse
    {
        public int Status { get; set; }
        public List<string> Response { get; set; }

        public RPGResponse()
        {
            this.Response = new List<string>();
        }
    }
}