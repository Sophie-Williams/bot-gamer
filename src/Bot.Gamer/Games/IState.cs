using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Connector;

namespace Bot.Gamer.Games
{
    public interface IState
    {
        RPGResponse Explore();
        RPGResponse Battle(int level);
    }
}