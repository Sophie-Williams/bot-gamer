using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bot.Gamer.Games;

namespace Bot.Gamer.Dialogs
{
    public class Dialogs
    {
        public enum DialogsTypes
        {
            Consciencia,
            Ajuda
        }

        private static readonly List<string> ConscienciaDialogs = new List<string>()
        {
            "Não se esqueça, eu sou um **BOT**, mas você pode me chamar de **GamerBot**.\n\nNão entendo tudo mas posso te ajudar a jogar.\n\nEm que posso te ajudar?",
            "Eu sou o poderoso **GamerBot**, o destruidor de humanos. Muitos tentaram, mas poucos conseguiram a honra de vencer!\n\nQuer ternar humano?",
            "É sério? Que pergunta hein... eu sou um **bot**, o **GamerBot**. Você quer jogar ou quer ficar tagarelando? ",
            "ಠ╭╮ಠ",
            "🐍",
            "😈"
        };

        private static readonly List<string> AjudaDialogs = new List<string>()
        {
            "Não se esqueça, eu sou um **BOT**, mas você pode me chamar de **GamerBot**.\n\nNão entendo tudo mas posso te ajudar a jogar.\n\nEm que posso te ajudar?",
            "Eu sou o poderoso **GamerBot**, o destruidor de humanos. Muitos tentaram, mas poucos conseguiram a honra de vencer!\n\nQuer ternar humano?",
            "É sério? Que pergunta hein... eu sou um **bot**, o **GamerBot**. Você quer jogar ou quer ficar tagarelando? ",
            "ಠ╭╮ಠ",
            "🐍",
            "😈"
        };

        public static string Chola(DialogsTypes types)
        {
            switch (types)
            {
                case DialogsTypes.Consciencia:
                    var ran = RandomGenerator.GetRandomNumber(ConscienciaDialogs.Count);
                    return ConscienciaDialogs[ran];
                case DialogsTypes.Ajuda:
                    ran = RandomGenerator.GetRandomNumber(ConscienciaDialogs.Count);
                    return AjudaDialogs[ran];
                default:
                    throw new ArgumentOutOfRangeException(nameof(types), types, null);
            }
        }
    }
}