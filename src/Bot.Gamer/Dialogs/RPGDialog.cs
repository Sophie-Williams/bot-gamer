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

        public const string EmptyField = "⚪️";
        public const string RedField = "🔴";
        public const string BlueField = "🔵";
        //("I win! 😈")
        //Text = "You can't play with yourself! ( ͡° ͜ʖ ͡°)"

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("-=-=- Battle Adventure v1.0 -=-=-");
            await context.PostAsync(EmptyField + RedField + BlueField);
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            //var activity = await result as Activity;
            PromptDialog.Text(context, CallBack, "\n\n\n\nO = Olhar ao redor, A = Atacar, S = Sair" +
                                                 "\n\n\nPontuação [] Nível [] Action [O,A,S]: ");
        }

        private async Task CallBack(IDialogContext context, IAwaitable<string> value)
        {
            var message = await value;

            if (message.ToLower() != "o" && message.ToLower() != "a" && message.ToLower() != "s")
            {
                await context.PostAsync("Mano, não é muito difícil jogar comigo...acompanha comigo:\n\n" +
                                        "* **O** - Para olhar ao redor\n\n" +
                                        "* **A** - Para atarcar, caso você veja um monstro\n\n" +
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
            if (command == "o")
            {
                var explore = Rpg.Explore();

                foreach (var item in explore.Response)
                {
                    await context.PostAsync(item);
                }

                var points = explore.Status;

                if (points > 0)
                {
                    await context.PostAsync("Você ganhou " + points + "!");

                    _score += points;
                }
            }
            else if (command == "a")
            {
                var battle = Rpg.Battle();

                foreach (var item in battle.Response)
                {
                    await context.PostAsync(item);
                }

                var rounds = battle.Status;
                if (rounds > 0)
                {
                    var points = 10 - rounds;
                    if (points < 0)
                    {
                        points = 0;
                    }
                    _score += points;

                    await context.PostAsync("Você ganhou " + points + "!");
                }
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

            if (command != "s")
            {
                PromptDialog.Text(context, CallBack, "\n\n\n\nO = Olhar ao redor, A = Atacar, S = Sair" +
                                                     "\n\n\nPontuação [] Nível [] Action [O,A,S]: ");
            }
        }

        private async Task CallBackQuit(IDialogContext context, IAwaitable<bool> value)
        {
            var command = await value;

            if (command)
            {
                var message = context.MakeMessage();
                var attachment = GetChubasCard();
                message.Attachments.Add(attachment);
                await context.PostAsync(message);
                context.Done<string>(null);
            }
            else
            {
                await context.PostAsync("Ok, pediu para **Sair** por que então?!?");

                PromptDialog.Text(context, CallBack, "\n\n\n\nO = Olhar ao redor, A = Atacar, S = Sair" +
                                                     "\n\n\nPontuação [] Nível [] Action [O,A,S]: ");
            }
        }

        private static Attachment GetChubasCard()
        {
            var heroCard = new HeroCard
            {
                Title = "LOSER",
                Subtitle = "😈 Loser Loser Loser",
                Text = BlueField + " Seu status no jogo foi: Nível 10 Pontuação 90",

                Images = new List<CardImage> { new CardImage("http://meriatblob.blob.core.windows.net/demos/robot.png") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Vitor Meriat", value: "http://vitormeriat.com.br") }
            };

            return heroCard.ToAttachment();
        }
    }
}