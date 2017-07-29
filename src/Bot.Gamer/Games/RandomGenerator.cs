using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot.Gamer.Games
{
    public static class RandomGenerator
    {
        private static Random random = new Random();
        public static int GetRandomNumber(int maxValue)
        {
            return random.Next(maxValue);
        }
    }
}