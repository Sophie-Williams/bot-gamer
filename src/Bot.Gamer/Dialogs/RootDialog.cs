using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bot.Gamer.Games;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis.Models;

namespace Bot.Gamer.Dialogs
{
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        public RootDialog(LuisService service) : base(service) { }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
        }

        private Task CallBack(IDialogContext context, IAwaitable<string> result)
        {
            throw new NotImplementedException();
        }

        #region ... Intents ...

        /// <summary>
        /// Quando não há intenção a ser reconhecida
        /// </summary>
        [LuisIntent("")]
        public async Task NoneHandler(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Desculpe, mas não entendi o que você quis dizer. ( ͡° ͜ʖ ͡°)");
            await Help(context, result);
        }

        /// <summary>
        /// Caso a intenção não seja reconhecida
        /// </summary>
        [LuisIntent("None")]
        public async Task NoneAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Desculpe, eu não entendi...");

            context.Wait(MessageReceived);
        }

        /// <summary>
        /// Quando a intenção for por ajuda
        /// </summary>
        [LuisIntent("ajudar")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Você pode perguntar coisas tipo *''xxx''* ou *''xxx''*.\n\n\nLembre-se, sou um **BOT** e meu diálgo é limitado.");
            context.Done("");
        }

        /// <summary>
        /// Quando as perguntas forem em relação ao próprio Botinho
        /// </summary>
        [LuisIntent("consciencia")]
        public async Task Consciencia(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Não se esqueça, eu sou um **BOT**, mas você pode me chamar de **Botinho**.\n\nNão entendo tudo mas posso te ajudar a jogar.\n\nEm que posso te ajudar?");
            context.Done("");
        }

        /// <summary>
        /// Caso a intenção seja uma saudação
        /// </summary>        
        [LuisIntent("saudar")]
        public async Task Saudar(IDialogContext context, LuisResult result)
        {
            var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time")).TimeOfDay;
            string saudacao;

            if (now < TimeSpan.FromHours(12))
            {
                saudacao = "Bom dia";
            }
            else if (now < TimeSpan.FromHours(18))
            {
                saudacao = "Boa tarde";
            }
            else
            {
                saudacao = "Boa noite";
            }

            await context.PostAsync($"{saudacao}! Em que posso ajudar?");
            context.Done("");
        }

        [LuisIntent("jogar-tic-tac-toe")]
        public async Task JogarTicTacToe(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("( ͡° ͜ʖ ͡°) Ops ... ainda não aprendi a jogar o **jogo da velha**.\n\nFaz o seguinte, volta depois ou joga um **RPG** comigo.");
        }

        [LuisIntent("jogar-rpg")]
        public async Task JogarRPG(IDialogContext context, LuisResult result)
        {
            await context.Forward(new RPGDialog(), this.ResumeAfterSupportDialog, null, CancellationToken.None);
        }
        #endregion

        private async Task ResumeAfterSupportDialog(IDialogContext context, IAwaitable<object> result)
        {
            var ticketNumber = await result;

            await context.PostAsync($"Thanks for contacting our support team. Your ticket number is {ticketNumber}.");
            context.Wait(this.MessageReceivedAsync);
        }
    }
}