using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Gamer.FormFlow
{
    [Serializable]
    public class InscricaoForm
    {
        [Prompt("Email")]
        public string Email;

        public static IForm<InscricaoForm> BuildForm()
        {
            return new FormBuilder<InscricaoForm>()
                .Message("Ok, preciso que você me informe seu email da **ESX**.\n\nInforme apenas o seu e-mail. Não tente bugar se coleguinha beleza?")
                .Field(nameof(Email), validate: ValidateEmail)
                .AddRemainingFields()
                //.Confirm("**Email:** {Email}")
                //.OnCompletion(EndContext)
                .Build();
        }

        private static async Task<ValidateResult> ValidateEmail(InscricaoForm state, object response)
        {
            var result = new ValidateResult();
            var email = (string)response;
            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!email.Contains('@') || email.Split('@').Length > 2 || email.Split('@')[1] != "esx.com.br")
                {
                    result.Feedback = "❌ - Informe um e-mail **@esx.com.br** mano!";
                    return result;
                }
            }

            result.IsValid = true;
            result.Value = email;
            return result;
        }
    }
}