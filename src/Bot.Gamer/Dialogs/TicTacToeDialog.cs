using Bot.Gamer.Games;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bot.Gamer.Games.TicTacToe;

namespace Bot.Gamer.Dialogs
{
    [Serializable]
    public class TicTacToeDialog : IDialog<object>
    {
        private static IPlayer[] players;
        private static bool?[] board;
        public static int boardIndex;

        public async Task StartAsync(IDialogContext context)
        {
            InitGame();
            await context.PostAsync("-=-=- Tic Tac Toe v1.0 -=-=-");
            context.Wait(StartTicTacToeAsync);
        }

        public static void InitGame()
        {
            boardIndex = 0;
            players = new IPlayer[]
            {
                new PlayerAiRandom(),
                new PlayerHuman()
                //new PlayerAiExtreme()
            };

            board = new bool?[9];
        }

        private async Task ResumeReceivedAsync(IDialogContext context, IAwaitable<long> result)
        {
            var movement = await result;

            await context.PostAsync($"Movimento {boardIndex + 1}:");

            var playerIndex = boardIndex % 2;

            await players[playerIndex].Play(board, playerIndex == 0, context, movement.ToString());

            await ResumeCallback(context, playerIndex);

            await StartTicTacToeAsync(context, new AwaitableFromItem<object>(movement));

        }

        private async Task StartTicTacToeAsync(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync($"Movimento {boardIndex + 1}:");

            var playerIndex = boardIndex % 2;

            await players[playerIndex].Play(board, playerIndex == 0, context);

            await ResumeCallback(context, playerIndex);

            PromptDialog.Number(context, ResumeReceivedAsync, "Informe seu movimento (1-9): ");
        }

        private async Task ResumeCallback(IDialogContext context, int playerIndex)
        {
            if (TicTacToe.DoesPlayerWins(board, playerIndex == 0))
            {
                await context.PostAsync(TicTacToe.ShowBoard(board));
                var p = playerIndex == 0 ? "X" : "O";
                await context.PostAsync($"O jogador '{players[playerIndex]}' com '{p}'  venceu o jogo");
            }
            else if (TicTacToe.DoesPlayerWins(board, playerIndex != 0))
            {
                await context.PostAsync(TicTacToe.ShowBoard(board));
                var l = playerIndex != 0 ? "X" : "O";
                await context.PostAsync($"O jogador '{players[playerIndex]}' com '{l}'  venceu o jogo");
            }
            else if (board.All(p => p != null))
            {
                await context.PostAsync("Draw");
            }
            else
            {
                await context.PostAsync(TicTacToe.ShowBoard(board));
            }

            boardIndex++;

            if (boardIndex < 9)
            {
                //await RunD(context);
            }
        }

    }
}