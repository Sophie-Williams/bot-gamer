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
            "**O que é um pontinho vermelho pulando na selva?** Um caqui pererê",
            "**O que é um pontinho branco fazendo abdominal?** É o Abdominável Homem das Neves",
            "**O que é um pontinho verde em Pernambuco?** É um frevo de 4 folhas",
            "**O que são 4 pontinhos azuis na praia?** Os Smurfs tomando sol",
            "**O que é um pontinho amarelo cantando?** Emilho Santiago",
            "**O que é um pontinho marrom cantando?** Carlinhos Brown",
            "**O que é um pontinho rosa no palco? Pink Floyd",
            "**O que são 5 pontinhos azuis no palco?** Uma banda de blues",
            "**O que é um pontinho marrom lutando Kung Fu?** Chuck Nozis",
            "**O que é um pontinho vermelho na televisão? Red Globo",
            "**O que é uma mancha verde, verde, verde-vermelha, vermelha e vermelha?** Um sapo no liquidificador",
            "**O que é um pontinho preto no trânsito?** Um calhamblack",
            "**O que é um pontinho marrom navegando em direção ao Brasil?** Pedro Álvares Cabrown",
            "**O que é um pontinho amarelo em cima do Titanic?** É o Yellownardo DiCaprio",
            "**Um médico inventou um remédio que cura dores de cabeça antes delas acontecerem. Qual é o nome do filme?** O extermina-a-dor do futuro",
            "**Um homem bebeu um Tang laranja e se jogou de cima da torre Eiffel. Qual é o nome do filme?** O último Tang em Paris",
            "**Um homem entrou na sala de cinema quando tudo estava completamente escuro mas mesmo assim encontrou um lugar. Qual é o nome do filme?** O iluminado",
            "**Um homem comeu feijoada, repolho, ovo e batata e depois foi correndo ao banheiro com dor de barriga. Qual é o nome do filme?** O Quinto Elemento",
            "**Um homem tinha como profissão cuidar de ursos. Certo dia, ele abandonou a profissão. Qual é o nome do filme?** O ex-ursista",
            "**Numa festa de aniversário um menino insistiu com o pai para que pegasse uma bexiga para ele estourar. Qual é o nome do filme?** Tó, estore ! (Toy Story)",
            "**Um casal que não tinha braços teve um filho. Qual é o nome do filme?** Ninguém segura este bebê",
            "**Um casal foi ao cinema com uma caixa de camisinhas. Qual é o nome do filme?** Evita",
            "**Um homem acidentalmente sentou em cima de um cachorro. Qual é o nome do filme?** Sento em um dálmata",
            "**Num lugar onde só existiam pizzas, as de aliche foram expulsas pelas pizzas de ervilha. Qual é o nome do filme?** Aliche no país das más ervilhas",
            "**Um chiclete conheceu uma chicletinha, casaram-se e tiveram vários chicletinhos. Qual é o nome do filme?** A Família Adams ",
            "**Um mamão foi violentamente atirado contra a boca de um sujeito. Qual é o nome do filme?** O mamão que balança o beiço",
            "**O Lula encontra o Zé Dirceu com a mulher dele na cama. Qual é o nome do filme?** O que é isso, companheiro?**",
            "**Um tênis afunda no meio do mar. Qual é o nome do filme?** Titanike",
            "**Um cara comeu um quilo de alho e depois escovou os dentes. Qual é o nome do filme?** Mudança de hálito",
            "**Como o elétron atende o telefone?** Próton?",
            "**O que o próton disse para o elétron?** Hoje você está muito negativo",
            "**O que é uma molécula?** É uma menina muito sapécula",
            "**Qual é o doce preferido do átomo?** Pé-de-moléculas",
            "**O que um cromossomo disse para o outro?** Cromossomos felizes !",
            "**O que o espermatozóide falou para o óvulo?** Deixa eu morar com você porque a minha casa é um saco",
            "**O que a célula disse quando foi ao barbeiro?** Mitose",
            "**Como as enzimas se reproduzem?** Fica uma enzima da outra",
            "**Por que a célula foi no psiquiatra?** Porque ela tinha complexo de Golgi",
            "**O que são dois pontos pretos no microscópio?** Uma blacktéria e um pretozoário",
            "**O que o polvo disse para a lula?** Ah, eu sou molusco !",
            "**Qual é a parte do corpo da mulher que cheira bacalhau?** O nariz",
            "**O que a mulher tem no meio das pernas?** O joelho",
            "**O que é um ponto marrom no pulmão?** Um brownquite",
            "**O que é um pontinho vermelho no meio da porta?** Um olho mágico com conjuntivite",
            "**O que canibal vegetariano come?** A planta do pé e a batata da perna",
            "**Por que as estrelas não fazem miau?** Porque Astronomia",
            "**Por que a vaca foi para o espaço?** Para se encontrar com o vácuo",
            "**Tinha dois caras, Geo e Trigo. Geo tinha vários filhos e o Trigo não tinha nenhum. Por quê?** Porque Geometria e Trigonometria",
            "**Na frase 'Proibido estacionar', qual é o sujeito da oração?** Sujeito a guincho",
            "**Dicionário:** Abismado - sujeito que caiu de um abismo",
            "**Dicionário:** Armarinho - vento proveniente do mar",
            "**Dicionário:** Aspirado - carta de baralho completamente maluca",
            "**Dicionário:** Assaltante - um 'A' que salta",
            "**Dicionário:** Barganhar - receber um botequim de herança",
            "**Dicionário:** Barracão - proíbe a entrada de caninos",
            "**Dicionário:** Bimestre - mestre em duas artes marciais",
            "**Dicionário:** Caçador - indivíduo que procura sentir dor",
            "**Dicionário:** Cerveja - é o sonho de toda revista",
            "**Dicionário:** Cleptomaníaco - maníaco por Eric Clapton",
            "**Dicionário:** Coitado - agente passivo do coito",
            "**Dicionário:** Contribuir - ir para algum lugar com vários índios",
            "**Dicionário:** Conversão - papo prolongado",
            "**Dicionário:** Coordenada - que não tem cor",
            "**Dicionário:** Democracia - sistema de governo do inferno",
            "**Dicionário:** Desviado - uma dezena de homossexuais",
            "**Dicionário:** Detergente - ato de prender seres humanos",
            "**Dicionário:** Determine - prender a namorada do Mickey Mouse",
            "**Dicionário:** Diabetes - as dançarinas do diabo",
            "**Dicionário:** Edifício - antônimo de 'é fácil'",
            "**Dicionário:** Eficiência - estudo das propriedades da letra F",
            "**Dicionário:** Entreguei - estar cercado de homossexuais",
            "**Dicionário:** Estouro - boi que sofreu operação de mudança de sexo",
            "**Dicionário:** Expedidor - mendigo que mudou de classe social",
            "**Dicionário:** Fluxograma - direção em que cresce o capim",
            "**Dicionário:** Halogênio - forma de cumprimentar pessoas muito inteligentes",
            "**Dicionário:** Homossexual - sabão em pó para lavar as partes íntimas",
            "**Dicionário:** Luz solar - sapato que emite luz por baixo",
            "**Dicionário:** Ministério - aparelho de som de dimensões muito reduzidas",
            "**Dicionário:** Missão - culto religioso com mais de três horas de duração",
            "**Dicionário:** Padrão - padre muito alto",
            "**Dicionário:** Pornográfico - o mesmo que colocar no desenho",
            "**Dicionário:** Presidiário - aquele que é preso diariamente",
            "**Dicionário:** Pressupor - colocar preço em alguma coisa",
            "**Dicionário:** Ratificar - tornar-se um rato",
            "**Dicionário:** Regime Militar - rotina de dieta e exercícios feitos pelo exército",
            "**Dicionário:** Suburbano - habitante dos túneis do metrô",
            "**Dicionário:** Testículo - 'testo' pequeno",
            "**Dicionário:** Tripulante - especialista em salto triplo",
            "**Dicionário:** Unção - erro de concordância verbal. O certo seria 'um é'",
            "**Dicionário:** Viaduto - local por onde circulam homossexuais",
            "**Dicionário:** Violentamente - viu com lentidão",
            "**Dicionário:** Volátil - o contrário de 'Vem cá, sobrinho'",
            "**Dictionary:** Can't - o oposto de frio",
            "**Dictionary:** Careful - supermercado : 'vou no careful fazer compras'",
            "**Dictionary:** Cheese - letra do alfabeto que vez antes do Z",
            "**Dictionary:** Cream - crime",
            "**Dictionary:** Date - ordem para deitar",
            "**Dictionary:** Dick - início de uma música do Roberto Carlos : 'dick que vale o céu...'",
            "**Dictionary:** Eleven - mandar levantar : 'eleven o nível da conversa aí !'",
            "**Dictionary:** Everybody - todos os bodes",
            "**Dictionary:** Eye - gemido de dor",
            "**Dictionary:** Fail - o contrário de bonito",
            "**Dictionary:** Fourteen - alguém que tem força, mas que é baixinho",
            "**Dictionary:** French - parte dianteira : 'Sai da french !'",
            "**Dictionary:** Go ahead - gol de cabeça",
            "**Dictionary:** Good - bolinha usada para jogar : 'gosto de jogar bolinha de good'",
            "**Dictionary:** Hand - render : 'você se hand ?'",
            "**Dictionary:** Happy days - indica uma grande velocidade: 'ele chegou até aqui com uma happy days incrível'",
            "**Dictionary:** Hello - esbarrou : 'ele hello o braço na parede'",
            "**Dictionary:** I am hungry - eu sou húngaro",
            "**Dictionary:** I am the best - eu sou a besta",
            "**Dictionary:** I want to see my son - eu ontem tossi maçã",
            "**Dictionary:** Ice - expressão de desejo : 'ice ela me desse bola...'",
            "**Dictionary:** It's too late - é muito leite !",
            "**Dictionary:** Layout - fora da lei",
            "**Dictionary:** May go - homem dócil, gentil : 'ele é um rapaz super may go'",
            "**Dictionary:** Merry Cristmas - Maria Cristina",
            "**Dictionary:** Mickey - quando ocorre um queimadura : 'pus a mão no fogo e Mickey mei'",
            "**Dictionary:** Monday - dar uma ordem : 'você fez o que eu monday ?'",
            "**Dictionary:** Must go - triturar com os dentes : 'ela colocou chiclete na boca e must go'",
            "**Dictionary:** Noise - coletivo de 'eu' : 'Noise fumo e vortemo !'",
            "**Dictionary:** Paint - objeto usado para pentear o cabelo",
            "**Dictionary:** Sad - vontade de beber água",
            "**Dictionary:** Say you - as mamas das mulheres",
            "**Dictionary:** She doesn't care - ela não quer",
            "**Dictionary:** Shut up - remédio usado principalmente contra a tosse",
            "**Dictionary:** So free - sofrimento : 'como eu so free para ganhar este dinheiro'",
            "**Dictionary:** Sort - pedir para largar : 'sort da minha mão !'",
            "**Dictionary:** The boy is behind the door - o boi está berrando de dor",
            "**Dictionary:** To see - efeito da tosse : 'ele ficou sem fôlego se tanto to see'",
            "**Dictionary:** Try again - traia alguém",
            "**Dictionary:** Vase - momento, oportunidade : 'agora é a minha vase'",
            "**Dictionary:** Window - usado em despedidas : 'bom, já vou window'",
            "**Dictionary:** Year - partir : 'eu tenho que year embora'",
            "**Dictionary:** You - expressão de curiosidade : 'you seu irmão, como vai ?'"
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