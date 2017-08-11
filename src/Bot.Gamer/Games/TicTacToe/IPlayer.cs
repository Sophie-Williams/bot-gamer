using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;

namespace Bot.Gamer.Games.TicTacToe
{
    internal interface IPlayer
    {
        Task Play(bool?[] board, bool playerSymbol, IDialogContext context, string movement = "");
    }
}