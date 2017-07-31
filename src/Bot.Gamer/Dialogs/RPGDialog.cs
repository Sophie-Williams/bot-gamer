using Bot.Gamer.Games;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bot.Gamer.Dialogs
{
    [Serializable]
    public class RPGDialog : IDialog<object>
    {
        private static readonly RPGController Rpg = new RPGController();
        private static int _score = 0;
        private static int _nextLevel = 10;

        //public const string EmptyField = "⚪️";
        //public const string RedField = "🔴";
        //public const string BlueField = "🔵 🔥 🐍";

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync($"-=-=- Battle Adventure {Emoji.Fire} v1.0 -=-=-");

            await context.PostAsync("Algumas instruções básicas:\n\n" +
                                    "**O** = Olhar ao redor, **A** = Atacar, **S** = Sair\n\n" +
                                    "Digite ajuda ou help para relembrar os comandos, se precisar");
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            //var activity = await result as Activity;
            PromptDialog.Text(context, CallBack, "\n\n\n\nO = Olhar ao redor, A = Atacar, S = Sair" +
                                                 "\n\n\nPontuação [**" + _score + "**] Nível [**" + Rpg.GetLevel() + "**] Action [O,A,S]:");
        }

        private async Task CallBack(IDialogContext context, IAwaitable<string> value)
        {
            var message = await value;

            if (Commands.ValidateCommand(message.ToLower()))
            {
                await context.PostAsync("Mano, não é muito difícil jogar...acompanha comigo:\n\n" +
                                        "* **O** - Para olhar ao redor\n\n" +
                                        "* **A** - Para atarcar, caso você veja um monstro\n\n" +
                                        "* **H** - Caso precise de ajuda, ou queira lembrar os comandos\n\n" +
                                        "* **S** - Para pedir arrego, caso você seja um franguinho!\n\n" +
                                        "Blz?!? Simples né? Mais fácil que seu código meia boca ;)");
            }
            else
            {
                await DoActionAsync(context, message.ToLower());
            }
        }

        private async Task DoActionAsync(IDialogContext context, string command)
        {
            if (Commands.O(command))
            {
                var explore = Rpg.Explore();

                foreach (var item in explore.Response)
                {
                    await context.PostAsync(item);
                }

                var points = explore.Status;

                if (points > 0)
                {
                    _score += points;
                    await context.PostAsync("Você ganhou " + points + "!");
                }
            }
            else if (Commands.A(command))
            {
                var battle = Rpg.Battle();

                foreach (var item in battle.Response)
                    await context.PostAsync(item);

                var rounds = battle.Status;
                if (rounds > 0)
                {
                    var points = 10 - rounds;

                    if (points < 0)
                        points = 0;

                    _score += points;

                    await context.PostAsync("Você ganhou " + points + "!");
                }
            }
            else if (Commands.H(command))
            {
                await context.PostAsync(new Commands().ToString());
            }
            else
            {
                PromptDialog.Confirm(context, CallBackQuit, "Você quer realmente sair?");
            }

            if (_score >= _nextLevel)
            {
                Rpg.SetLevel(Rpg.GetLevel() + 1);
                _nextLevel = Rpg.GetLevel() * 10;

                await context.PostAsync("Sua maravilhosa experiência ganhou um level! Level " + Rpg.GetLevel());
            }

            if (!Commands.S(command))
                PromptDialog.Text(context, CallBack, $"{Emoji.EmptyField} Pontuação [**{_score}**] Nível [**{Rpg.GetLevel()}**] Action [O,A,S]: ");

        }

        private async Task CallBackQuit(IDialogContext context, IAwaitable<bool> value)
        {
            var command = await value;

            if (command)
            {
                var message = context.MakeMessage();
                message.Attachments.Add(GetChubasCard());
                await context.PostAsync(message);
                context.Done<string>(null);
            }
            else
            {
                await context.PostAsync("Ok, pediu para **Sair** por que então?!?");

                PromptDialog.Text(context, CallBack, "\n\n\n\nO = Olhar ao redor, A = Atacar, S = Sair" +
                                                     $"\n\n\n{Emoji.EmptyField} Pontuação [**{_score}**] Nível [**{Rpg.GetLevel()}**] Action [O,A,S]:");
            }
        }

        private static Attachment GetChubasCard()
        {
            var heroCard = new HeroCard
            {
                Title = "LOSER",
                Subtitle = "😈 Loser ಠ╭╮ಠ Loser",
                Text = Emoji.RedField + " Seu status no jogo foi: Pontuação [**" + _score + "**] Nível [**" + Rpg.GetLevel() + "**]",
                Images = new List<CardImage> { new CardImage("http://meriatblob.blob.core.windows.net/demos/robot.png") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Vitor Meriat", value: "http://vitormeriat.com.br") }
            };

            return heroCard.ToAttachment();
        }
    }
}