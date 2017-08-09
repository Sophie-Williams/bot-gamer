using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bot.Gamer.Games;

namespace Bot.Gamer.Dialogs
{
    public class Dialogs
    {
        public enum DialogsTypes
        {
            Consciencia,
            Piada,
            Ajuda
        }

        private static readonly List<string> ConscienciaDialogs = new List<string>()
        {
            "Não se esqueça, eu sou um **BOT**, mas você pode me chamar de **GamerBot**.\n\nNão entendo tudo mas posso te ajudar a jogar.\n\nEm que posso te ajudar?",
            "Eu sou o poderoso **GamerBot**, o destruidor de humanos. Muitos tentaram, mas poucos conseguiram a honra de vencer!\n\nQuer ternar humano?",
            "É sério? Que pergunta hein... eu sou um **bot**, o **GamerBot**. Você quer jogar ou quer ficar tagarelando?",
            "Mano... eu já falei que sou um **bot** né? ಠ╭╮ಠ"
        };

        private static readonly List<string> AjudaDialogs = new List<string>()
        {
            "Eu sou um **bot**. Até agora o que eu aprendi a fazer é:\n\n" +
            "* Jogar RPG. (Mas eu sou o **mestre** ok?);\n\n" +
            "* Jogar TicTacToe, ou o jogo da velha;\n\n" +
            "* Contar piadas.\n\n" +
            "Lembre-se, sou um **BOT** e meu diálgo é limitado.",
            "Eu, o grande **GamerBot** estou generoso hoje. Já que você é apenas um humano, vou te ajudar a conversar comigo. Até agora o que eu aprendi a fazer é:\n\n" +
            "* Jogar RPG. (Mas eu sou o **mestre** ok?);\n\n" +
            "* Jogar TicTacToe, ou o jogo da velha;\n\n" +
            "* Contar piadas.\n\n" +
            "Não se esqueça que sou um **BOT** e meu diálgo é limitado."
        };

        private static readonly List<string> PiadaDialogs = new List<string>()
        {
            "Doutor, como eu faço para emagrecer? Basta a senhora mover a cabeça da esquerda para a direita e da direita para a esquerda. Quantas vezes, doutor? Todas as vezes que lhe oferecerem comida.",
            "O garoto apanhou da vizinha, e a mãe furiosa foi tomar satisfação: Por que a senhora bateu no meu filho? Ele foi mal-educado, e me chamou de gorda. E a senhora acha que vai emagrecer batendo nele?",
            "Conversa de casados: Querido, o que você prefere? Uma mulher bonita ou uma mulher inteligente? Nem uma, nem outra. Você sabe que eu só gosto de você.",
            "A mulher comenta com o marido: Querido, hoje o relógio caiu da parede da sala e por pouco não bateu na cabeça da mamãe... Maldito relógio. Sempre atrasado...",
            "O condenado à morte esperava a hora da execução, quando chegou o padre: Meu filho, vim trazer a palavra de Deus para você. Perda de tempo, seu padre. Daqui a pouco vou falar com Ele, pessoalmente. Algum recado?",
            "**O que é um pontinho amarelo lutando Kick Boxer?** É o Jean-Claude Fan Dangos",
            "**O que é um pontinho amarelo em cima do prédio?** É um Fandangos suicida",
            "**Por que ele quer se suicidar?** Por que a casa dele é um saco",
            "**O que ele irá virar quando se jogar do prédio?** Fandangos presunto",
            "**O que é um pontinho amarelo em cima de uma moto?** Ruffles, a batata da Honda",
            "**O que é um pontinho amarelo tomando sol?** É um Fandangos querendo virar Baconzitos",
            "**O que é um pontinho amarelo tocando violão?** Cheetos Buarque",
            "**O que é um pontinho amarelo em cima de um absorvente usado?** Um fandangos vampiro",
            "**O que é um pontinho branco voando?** É um uruBlue que quase foi atingido por um avião",
            "**O que é um pontinho vermelho no rio?** Um jacaRed",
            "**O que é um pontinho verde do Pólo Sul?** É um pinGreen",
            "**O que é um pontinho vermelho em cima da árvore?** É um morangotango",
            "**O que é um pontinho marrom voando?** Uma brownBoleta",
            "**O que é um pontinho amarelo na selva?** Um yellowFante",
            "**O que é um pontinho brilhando no jardim?** Uma formiga de aparelho",
            "**O que é um pontinho azul e verde pulando no jardim?** É um grilo de calça jeans",
            "**O que são 4 pontinhos no jardim?** FourMigas",
            "**O que é um pontinho rosa no céu?** Uma gayvota",
            "**O que é um pontinho verde no canto da sala?** É uma ervilha de castigo",
            "**O que são três pontinhos verdes no canto da sala?** É uma ervilha de castigo e mais duas dizendo Bem feito!",
            "**O que é um pontinho verde em cima de um pontinho amarelo no canto da sala?** É uma ervilha de castigo ajoelhada no milho",
            "**O que é um pontinho verde pulando em cima do sofá?** É uma ervilha que saiu do castigo",
            "**O que é um pontinho vermelho subindo a geladeira?** Um morango alpinista",
            "**O que é um pontinho amarelo que ganhou na loteria?** Um milhonário",
            "**O que é um pontinho verde no trânsito?** Uma limãosine",
            "**O que é um pontinho oval no trânisto?** Um Escort X-egg3",
            "**O que é um pontinho branco no trânsito?** Um Arroz-Royce",
            "**O que é um pontinho verde no trânsito?** Um Volks Vagem",
            "**O que é um pontinho vermelho na salada?** Uma ervilha prendendo a respiração",
            "**O que é um pontinho vermelho em cima do castelo?** Pimenta do reino",
            "**O que é um pontinho vermelho pulando na selva?** Um caqui pererê"
        };

        public static string RandomChoose(DialogsTypes types)
        {
            switch (types)
            {
                case DialogsTypes.Consciencia:
                    var ran = RandomGenerator.GetRandomNumber(ConscienciaDialogs.Count);
                    return ConscienciaDialogs[ran];
                case DialogsTypes.Ajuda:
                    ran = RandomGenerator.GetRandomNumber(AjudaDialogs.Count);
                    return AjudaDialogs[ran];
                case DialogsTypes.Piada:
                    ran = RandomGenerator.GetRandomNumber(PiadaDialogs.Count);
                    return PiadaDialogs[ran];
                default:
                    throw new ArgumentOutOfRangeException(nameof(types), types, null);
            }
        }
    }
}