﻿using BotBuilder.Instrumentation.Dialogs;
using Microsoft.Azure.Documents.Client;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Threading;
using System.Threading.Tasks;
using Bot.Gamer.FormFlow;
using Microsoft.Bot.Builder.FormFlow;

namespace Bot.Gamer.Dialogs
{
    [Serializable]
    public class RootDialog : InstrumentedLuisDialog<object>//LuisDialog<object>
    {
        public InscricaoForm FormInscricao { get; set; }

        //public RootDialog(LuisService service) : base(service) { }
        public RootDialog(string luisModelId, string luisSubscriptionKey) : base(luisModelId, luisSubscriptionKey) { }


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
            var response = Dialogs.RandomChoose(Dialogs.DialogsTypes.Ajuda);
            await context.PostAsync(response);
            context.Done<string>(null);
        }

        [LuisIntent("ofenca")]
        public async Task Ofenca(IDialogContext context, LuisResult result)
        {
            var response = Dialogs.RandomChoose(Dialogs.DialogsTypes.Ofenca);
            await context.PostAsync(response);
            context.Done<string>(null);
        }

        /// <summary>
        /// Quando as perguntas forem em relação ao próprio Botinho
        /// </summary>
        [LuisIntent("consciencia")]
        public async Task Consciencia(IDialogContext context, LuisResult result)
        {
            var response = Dialogs.RandomChoose(Dialogs.DialogsTypes.Consciencia);
            await context.PostAsync(response);
            context.Done<string>(null);
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

        /// <summary>
        /// Quando o usuário quiser jogar o jogo da velha
        /// </summary>
        [LuisIntent("jogar-tic-tac-toe")]
        public async Task JogarTicTacToe(IDialogContext context, LuisResult result)
        {
            //await context.PostAsync("( ͡° ͜ʖ ͡°) Ops ... ainda não aprendi a jogar o **jogo da velha**.\n\nFaz o seguinte, volta depois ou joga um **RPG** comigo.");
            await context.Forward(new TicTacToeDialog(), this.ResumeAfterPlayGame, null, CancellationToken.None);
        }

        /// <summary>
        /// Quando o usuário quiser jogar RPG
        /// </summary>
        [LuisIntent("jogar-rpg")]
        public async Task JogarRpg(IDialogContext context, LuisResult result)
        {
            await context.Forward(new RpgDialog(), this.ResumeAfterPlayGame, null, CancellationToken.None);
        }

        /// <summary>
        /// Quando o usuário quiser ouvir uma piada
        /// </summary>
        [LuisIntent("contar-piada")]
        public async Task ContarPiada(IDialogContext context, LuisResult result)
        {
            var response = Dialogs.RandomChoose(Dialogs.DialogsTypes.Piada);
            await context.PostAsync(response);
            context.Done<string>(null);
        }

        [LuisIntent("falar-sobre-tecnologias")]
        public async Task FalarSobreTecnologias(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("É sério que você não sabe disso?\n\n" +
                                    "Isso é básico... Você fez faculdade? Fez ensino Médio pelo menos?");
            context.Done<string>(null);
        }

        [LuisIntent("realizar-inscricao")]
        public async Task RealizarInscricao(IDialogContext context, LuisResult result)
        {
            FormInscricao = new InscricaoForm();
            var dialog = new FormDialog<InscricaoForm>(FormInscricao, InscricaoForm.BuildForm, FormOptions.PromptInStart);
            context.Call(dialog, EfetuarInscricao);
        }
        #endregion

        private async Task ResumeAfterPlayGame(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Ok humano... o que você quer fazer agora?");

            context.Done<string>(null);
        }
        
        private async Task EfetuarInscricao(IDialogContext context, IAwaitable<object> value)
        {
            var message = await value;

            var repository = new DocumentDbRepository();

            var um = repository.GetItemByEmailAsync(message.ToString());
            if (um == null)
            {
                var inscricao = new Inscricao() { Email = message.ToString(), Id = Guid.NewGuid().ToString() };

                var oi = await repository.CreateItemAsync(inscricao);

                if (oi != null)
                {
                    await context.PostAsync(oi.Id);
                }
            }
            else
            {
                await context.PostAsync("Deu ruim mano...já exite uma inscrição.");
            }
        }
    }
}