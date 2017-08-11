using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;

namespace Bot.Gamer.Games.TicTacToe
{
    internal class PlayerAiRandom : IPlayer
    {
        public async Task Play(bool?[] board, bool playerSymbol, IDialogContext context, string movement = "")
        {
            var r = new Random();

            while (true)
            {
                var v = r.Next(0, 9);
                if (board[v] == null)
                {
                    board[v] = playerSymbol;
                    break;
                }
            }
        }
    }
}