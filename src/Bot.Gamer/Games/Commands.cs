using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot.Gamer.Games
{
    public class Commands
    {
        private static readonly List<string> CommandListO = new List<string>() { "o", "observar", "olhar", "ver", "andar", "procurar" };

        private static readonly List<string> CommandListA = new List<string>() { "a", "atacar", "lutar", "brigar", "matar", "destruir" };

        private static readonly List<string> CommandListH = new List<string>() { "h", "help", "ajuda", "arrego" };

        private static readonly List<string> CommandListS = new List<string>() { "s", "sair", "abandonar", "desistir" };

        public static bool O(string command)
        {
            return CommandListO.Exists(c => c == command);
        }

        public static bool A(string command)
        {
            return CommandListA.Exists(c => c == command);
        }

        public static bool H(string command)
        {
            return CommandListH.Exists(c => c == command);
        }

        public static bool S(string command)
        {
            return CommandListS.Exists(c => c == command);
        }
    }
}