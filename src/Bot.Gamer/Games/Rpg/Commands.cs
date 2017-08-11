using System;
using System.Collections.Generic;
using System.Linq;

namespace Bot.Gamer.Games.Rpg
{
    [Serializable]
    public class Commands
    {
        private static readonly List<string> CommandListO = new List<string>() { "o", "observar", "olhar", "ver", "andar", "procurar" };

        private static readonly List<string> CommandListA = new List<string>() { "a", "atacar", "lutar", "brigar", "matar", "destruir" };

        private static readonly List<string> CommandListH = new List<string>() { "h", "help", "ajuda", "arrego" };

        private static readonly List<string> CommandListS = new List<string>() { "s", "sair", "abandonar", "desistir" };

        public static bool ValidateCommand(string command)
        {
            return O(command) || A(command) || S(command) || H(command);
        }

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

        private static string ListWords(IEnumerable<string> word)
        {
            return word.Aggregate<string, string>(null, (current, item) => current + $" [{item}] ");
        }

        public override string ToString()
        {
            return $"{Emoji.TheFace} - segue a lista dos comandos\n\n" +
                    $"**O** {ListWords(CommandListO)}\n\n" +
                    $"**A** {ListWords(CommandListA)}\n\n" +
                    $"**S** {ListWords(CommandListS)}\n\n" +
                    $"**H** {ListWords(CommandListH)}";
        }
    }
}