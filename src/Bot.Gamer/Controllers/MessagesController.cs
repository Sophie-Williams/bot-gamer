using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Bot.Gamer.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Bot.Gamer.Games;
using Microsoft.Bot.Builder.Luis;

namespace Bot.Gamer
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));

            var attributes = new LuisModelAttribute(
                ConfigurationManager.AppSettings["LuisId"],
                ConfigurationManager.AppSettings["LuisSubscriptionKey"]);

            var service = new LuisService(attributes);

            switch (activity.Type)
            {
                case ActivityTypes.Message:
                    await Conversation.SendAsync(activity, () => new RootDialog(service));
                    //await Conversation.SendAsync(activity, () => new GameDialog());
                    break;
                case ActivityTypes.ConversationUpdate:
                    if (activity.MembersAdded.Any(o => o.Id == activity.Recipient.Id))
                    {
                        var reply = activity.CreateReply();
                        reply.Text = "Olá, eu sou o **BotInho**.\n\n\nPor hora a única coisa que eu faço é jogar um **RPG** com você.\n\n\nMas lembre-se, eu sou o master. É só você seguir os meus comandos que vamos ter um bom jogo.\n\n\n**PS:** Eu estou na v0.1.1, então pega leve tá?!?";

                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    break;
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}