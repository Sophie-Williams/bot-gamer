using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot.Gamer.Games.TicTacToe
{
    [Serializable]
    internal class PlayerHuman : IPlayer
    {
        public bool?[] Board { get; set; }
        public bool PlayerSymbol { get; set; }

        public async Task Play(bool?[] board, bool playerSymbol, IDialogContext context, string movement)
        {
            //int move;
            //bool isNumber;

            Board = board;
            PlayerSymbol = playerSymbol;

            //var activity = context.Activity;

            int move;

            var isNumber = int.TryParse(movement, out move);

            //zero based
            move--;
            if (move < 0 || move >= 9)
            {
                //await context.PostAsync("Select a move (1-9): ");
                //context.Wait(ResumeReceivedAsync);
                PromptDialog.Number(context, ResumeReceivedAsync, "Informe seu movimento (1-9): ");
            }

            if (isNumber && Board[move] == null)
                Board[move] = PlayerSymbol;
        }

        private async Task ResumeReceivedAsync(IDialogContext context, IAwaitable<long> value)
        {
            var activity = await value;

            // calculate something for us to return
            //int length = (activity.Text ?? string.Empty).Length;

            int move;

            //var vStr = Console.ReadLine();
            var isNumber = int.TryParse(activity.ToString(), out move);

            //zero based
            move--;
            if (move < 0 || move >= 9)
            {
                //await context.PostAsync("Select a move (1-9): ");
                //context.Wait(ResumeReceivedAsync);
                PromptDialog.Number(context, ResumeReceivedAsync, "Select a move (1-9): ");
            }

            if (isNumber && Board[move] == null)
                Board[move] = PlayerSymbol;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result;

            // calculate something for us to return
            //int length = (activity.Text ?? string.Empty).Length;

            int move;

            //var vStr = Console.ReadLine();
            var isNumber = int.TryParse(activity.Text, out move);

            //zero based
            move--;
            if (move < 0 || move >= 9)
            {
                await context.PostAsync("Select a move (1-9): ");
                context.Wait(MessageReceivedAsync);
            }

            if (isNumber && Board[move] == null)
                Board[move] = PlayerSymbol;

            //context.Wait(MessageReceivedAsync);
        }
    }
}