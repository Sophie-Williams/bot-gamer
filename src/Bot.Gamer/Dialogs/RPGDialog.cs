using Bot.Gamer.Games;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bot.Gamer.Games.Rpg;

namespace Bot.Gamer.Dialogs
{
    [Serializable]
    public class RpgDialog : IDialog<object>
    {
        private readonly RpgController _rpg = new RpgController();
        private int _score;
        private int _nextLevel = 10;

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync($"-=-=- Battle Adventure {Emoji.Fire} v1.0 -=-=-");

            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Antes de começar, siga as instruções:\n\n" +
                                    "* **O** - Para olhar ao redor\n\n" +
                                    "* **A** - Para atarcar, caso você veja um monstro\n\n" +
                                    "* **H** - Caso precise de ajuda, ou queira lembrar os comandos\n\n" +
                                    "* **S** - Para sair ou pedir arrego\n\n");

            PromptDialog.Text(context, CallBack, "Hora de iniciar..." +
                                                 "\n\n\nPontuação [**" + _score + "**] Nível [**" + _rpg.GetLevel() + "**]\n\n\n" +
                                                 "O que você quer fazer agora? **Action [O,A,H,S]:**");
        }

        private async Task CallBack(IDialogContext context, IAwaitable<string> value)
        {
            var message = await value;

            if (!Commands.ValidateCommand(message.ToLower()))
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
            if (Commands.O(command)) // OBSERVAR
            {
                var explore = _rpg.Explore();
                
                var points = explore.Status;

                if (points > 0)
                {
                    _score += points;
                    explore.Response = explore.Response+"\n\nVocê ganhou " + points + "!";
                }

                await context.PostAsync(explore.Response);
            }
            else if (Commands.A(command)) // ATACAR
            {
                var battle = _rpg.Battle();
                
                var rounds = battle.Status;
                if (rounds > 0)
                {
                    var points = 10 - rounds;

                    if (points < 0)
                        points = 0;

                    _score += points;

                    battle.Response = battle.Response + "\n\nVocê ganhou " + points + "!";
                }

                await context.PostAsync(battle.Response);
            }
            else if (Commands.H(command)) // AJUDA
            {
                await context.PostAsync(new Commands().ToString());
            }
            else
            {
                PromptDialog.Confirm(context, CallBackQuit, "Você quer realmente sair?");
            }

            if (_score >= _nextLevel)
            {
                _rpg.SetLevel(_rpg.GetLevel() + 1);
                _nextLevel = _rpg.GetLevel() * 10;

                await context.PostAsync("Sua maravilhosa experiência ganhou um level! Level " + _rpg.GetLevel());
            }

            if (!Commands.S(command))
                PromptDialog.Text(context, CallBack, $"{Emoji.BlueField} Pontuação [**{_score}**] Nível [**{_rpg.GetLevel()}**] Action [O,A,S]: ");

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

                PromptDialog.Text(context, CallBack, "O que você quer fazer agora? **Action [O,A,H,S]:**");
            }
        }

        private Attachment GetChubasCard()
        {
            var heroCard = new HeroCard
            {
                Title = "LOSER",
                Subtitle = Emoji.B,
                Text = Emoji.RedField + " Seu status no jogo foi: Pontuação [**" + _score + "**] Nível [**" + _rpg.GetLevel() + "**]",
                Images = new List<CardImage> { new CardImage("http://meriatblob.blob.core.windows.net/demos/robot.png") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Vitor Meriat", value: "http://vitormeriat.com.br") }
            };

            return heroCard.ToAttachment();
        }
    }
}