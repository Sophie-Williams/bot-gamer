using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;

namespace Bot.Gamer.Games.TicTacToe
{
    [Serializable]
    public class TicTacToe
    {
        private static IPlayer[] players;
        private static bool?[] board;
        public static int boardIndex;

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

        public static async Task RunD(IDialogContext context)
        {
            await context.PostAsync($"Movimento {boardIndex + 1}:");

            var playerIndex = boardIndex % 2;

            await players[playerIndex].Play(board, playerIndex == 0, context);

            if (DoesPlayerWins(board, playerIndex == 0))
            {
                await context.PostAsync(ShowBoard(board));
                var p = playerIndex == 0 ? "X" : "O";
                await context.PostAsync($"O jogador '{players[playerIndex]}' com '{p}'  venceu o jogo");
                //break;
            }
            else if (DoesPlayerWins(board, playerIndex != 0))
            {
                await context.PostAsync(ShowBoard(board));
                var l = playerIndex != 0 ? "X" : "O";
                await context.PostAsync($"O jogador '{players[playerIndex]}' com '{l}'  venceu o jogo");
                //break;
            }
            else if (board.All(p => p != null))
            {
                await context.PostAsync("Draw");
                //break;
            }
            else
            {
                await context.PostAsync(ShowBoard(board));
            }

            boardIndex++;

            if (boardIndex < 9)
            {
                //await RunD(context);
            }
        }

        public static async Task RunC(IDialogContext context)
        {
            await context.PostAsync($"Movimento {boardIndex + 1}:");

            var playerIndex = boardIndex % 2;

            await players[playerIndex].Play(board, playerIndex == 0, context);

            if (DoesPlayerWins(board, playerIndex == 0))
            {
                await context.PostAsync(ShowBoard(board));
                var p = playerIndex == 0 ? "X" : "O";
                await context.PostAsync($"O jogador '{players[playerIndex]}' com '{p}'  venceu o jogo");
                //break;
            }
            else if (DoesPlayerWins(board, playerIndex != 0))
            {
                await context.PostAsync(ShowBoard(board));
                var l = playerIndex != 0 ? "X" : "O";
                await context.PostAsync($"O jogador '{players[playerIndex]}' com '{l}'  venceu o jogo");
                //break;
            }
            else if (board.All(p => p != null))
            {
                await context.PostAsync("Draw");
                //break;
            }
            else
            {
                await context.PostAsync(ShowBoard(board));
            }

            boardIndex++;

            if (boardIndex < 9)
            {
                //await RunD(context);
            }
        }

        public static async Task Run(IDialogContext context)
        {
            InitGame();

            for (int boardIndex = 0; boardIndex < 9; boardIndex++)
            {
                await context.PostAsync($"Movimento {boardIndex + 1}:");

                var playerIndex = boardIndex % 2;

                await players[playerIndex].Play(board, playerIndex == 0, context);

                if (DoesPlayerWins(board, playerIndex == 0))
                {
                    await context.PostAsync(ShowBoard(board));
                    var p = playerIndex == 0 ? "X" : "O";
                    await context.PostAsync($"O jogador '{players[playerIndex]}' com '{p}'  venceu o jogo");
                    break;
                }
                else if (DoesPlayerWins(board, playerIndex != 0))
                {
                    await context.PostAsync(ShowBoard(board));
                    var l = playerIndex != 0 ? "X" : "O";
                    await context.PostAsync($"O jogador '{players[playerIndex]}' com '{l}'  venceu o jogo");
                    break;
                }
                else if (board.All(p => p != null))
                {
                    await context.PostAsync("Draw");
                    break;
                }
                else
                {
                    await context.PostAsync(ShowBoard(board));
                }
            }
        }

        public static string ShowBoard(bool?[] board)
        {
            var sb = new StringBuilder();

            for (int boardIndex = 0; boardIndex < 9; boardIndex++)
            {
                if ((1 + boardIndex) % 3 == 0)
                {
                    sb.AppendLine("\n\n" + BoardValue(board, boardIndex));
                    continue;
                }
                //\n
                sb.AppendFormat("{0}|", BoardValue(board, boardIndex));
            }

            return sb.ToString();
        }

        public static string BoardValue(bool?[] board, int boardIndex)
        {
            return board[boardIndex] == null ? " " : (board[boardIndex].Value ? "X" : "O");
        }

        public static bool IsGameFinished(bool?[] board)
        {
            return DoesPlayerWins(board, true) ||
                   DoesPlayerWins(board, false) ||
                   board.All(p => p != null);
        }

        public static bool DoesPlayerWins(bool?[] board, bool playerSymbol)
        {
            var winnningPossibilities = new List<int[]>
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
                new[] {7, 8, 9},
                new[] {1, 4, 7},
                new[] {2, 5, 8},
                new[] {3, 6, 9},
                new[] {1, 5, 9},
                new[] {7, 5, 3},
            };

            foreach (var possibility in winnningPossibilities)
            {
                var won = true;

                foreach (var posItem in possibility)
                {
                    //zero based
                    var i = posItem - 1;

                    if (board[i] == null || board[i].Value != playerSymbol)
                        won = false;
                }

                if (won)
                    return true;
            }

            return false;
        }
    }
}