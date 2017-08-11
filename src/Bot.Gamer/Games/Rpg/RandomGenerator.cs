using System;

namespace Bot.Gamer.Games.Rpg
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