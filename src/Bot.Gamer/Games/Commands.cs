using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot.Gamer.Games
{
    [Serializable]
    public class Emoji
    {
        public static readonly string Fire = "🔥";
        public static readonly string EmptyField = "⚪️";
        public static readonly string RedField = "🔴";
        public static readonly string BlueField = "🔵";
        public static readonly string Snake = "🐍";
        public static readonly string A = "😈";
        public static readonly string B = "ಠ╭╮ಠ";
        public static readonly string C = "";
        public static readonly string D = "";
    }

    [Serializable]
    public class Commands
    {
        private static readonly List<string> CommandListO = new List<string>() { "o", "observar", "olhar", "ver", "andar", "procurar" };

        private static readonly List<string> CommandListA = new List<string>() { "a", "atacar", "lutar", "brigar", "matar", "destruir" };

        private static readonly List<string> CommandListH = new List<string>() { "h", "help", "ajuda", "arrego" };

        private static readonly List<string> CommandListS = new List<string>() { "s", "sair", "abandonar", "desistir" };

        private static readonly List<string> CoolFaces = new List<string>(){
            "( .-. )",
            "( .o.)",
            "( `·´ )",
            "( ° ͜ ʖ °)",
            "( ͡° ͜ʖ ͡°)",
            "( ⚆ _ ⚆ )",
            "( ︶︿︶)",
            "( ﾟヮﾟ)",
            @"(\\/)(°,,,°)(\\/)",
            "(¬_¬)",
            "(¬º-°)¬",
            "(¬‿¬)",
            "(°ロ°)☝",
            "(´・ω・)っ",
            "(ó ì_í)",
            "(ʘᗩʘ')",
            "(ʘ‿ʘ)",
            "(̿▀̿ ̿Ĺ̯̿̿▀̿ ̿)̄",
            "(͡° ͜ʖ ͡°)",
            "(ಠ_ಠ)",
            "(ಠ‿ಠ)",
            "(ಠ⌣ಠ)",
            "(ಥ_ಥ)",
            "(ಥ﹏ಥ)",
            "(ง ͠° ͟ل͜ ͡°)ง",
            "(ง ͡ʘ ͜ʖ ͡ʘ)ง",
            "(ง •̀_•́)ง",
            "(ง'̀-'́)ง",
            "(ง°ل͜°)ง",
            "(ง⌐□ل͜□)ง",
            "(ღ˘⌣˘ღ)",
            "(ᵔᴥᵔ)",
            "(•ω•)",
            "(•◡•)/",
            "(⊙ω⊙)",
            "(⌐■_■)",
            "(─‿‿─)",
            "(╯°□°）╯",
            "(◕‿◕)",
            "(☞ﾟ∀ﾟ)☞",
            "(❍ᴥ❍ʋ)",
            "(っ◕‿◕)っ",
            "(づ｡◕‿‿◕｡)づ",
            "(ノಠ益ಠ)ノ",
            "(ノ・∀・)ノ",
            "(；一_一)",
            "(｀◔ ω ◔´)",
            "(｡◕‿‿◕｡)",
            "(ﾉ◕ヮ◕)ﾉ",
            "*<{:¬{D}}}",
            "=^.^=",
            "t(-.-t)",
            "| (• ◡•)|",
            "~(˘▾˘~)",
            "¬_¬",
            "¯(°_o)/¯",
            @"¯\_(ツ)_/¯",
            "°Д°",
            "ɳ༼ຈل͜ຈ༽ɲ",
            "ʅʕ•ᴥ•ʔʃ",
            "ʕ´•ᴥ•`ʔ",
            "ʕ•ᴥ•ʔ",
            "ʕ◉.◉ʔ",
            "ʕㅇ호ㅇʔ",
            "ʕ；•`ᴥ•´ʔ",
            "ʘ‿ʘ",
            "͡° ͜ʖ ͡°",
            "ζ༼Ɵ͆ل͜Ɵ͆༽ᶘ",
            "Ѱζ༼ᴼل͜ᴼ༽ᶘѰ",
            "ب_ب",
            "٩◔̯◔۶",
            "ಠ_ಠ",
            "ಠoಠ",
            "ಠ~ಠ",
            "ಠ‿ಠ",
            "ಠ⌣ಠ",
            "ಠ╭╮ಠ",
            "ರ_ರ",
            "ง ͠° ل͜ °)ง",
            "๏̯͡๏﴿",
            "༼ ºººººل͟ººººº ༽",
            "༼ ºل͟º ༽",
            "༼ ºل͟º༼",
            "༼ ºل͟º༽",
            "༼ ͡■ل͜ ͡■༽",
            "༼ つ ◕_◕ ༽つ",
            "༼ʘ̚ل͜ʘ̚༽",
            "ლ(´ڡ`ლ)",
            "ლ(́◉◞౪◟◉‵ლ)",
            "ლ(ಠ益ಠლ)",
            "ᄽὁȍ ̪őὀᄿ",
            "ᔑ•ﺪ͟͠•ᔐ",
            "ᕕ( ᐛ )ᕗ",
            "ᕙ(⇀‸↼‶)ᕗ",
            "ᕙ༼ຈل͜ຈ༽ᕗ",
            "ᶘ ᵒᴥᵒᶅ",
            "‎‎(ﾉಥ益ಥ）ﾉ",
            "≧☉_☉≦",
            "⊙▃⊙",
            "⊙﹏⊙",
            "┌( ಠ_ಠ)┘",
            "╚(ಠ_ಠ)=┐",
            "◉_◉",
            "◔ ⌣ ◔",
            "◔̯◔",
            "◕‿↼",
            "◕‿◕",
            "☉_☉",
            "☜(⌒▽⌒)☞",
            "☼.☼",
            "♥‿♥",
            "⚆ _ ⚆",
            "✌(-‿-)✌",
            "〆(・∀・＠)",
            "ノ( º _ ºノ)",
            "ノ( ゜-゜ノ)",
            "ヽ( ͝° ͜ʖ͡°)ﾉ",
            "ヽ(`Д´)ﾉ",
            "ヽ༼° ͟ل͜ ͡°༽ﾉ",
            "ヽ༼ʘ̚ل͜ʘ̚༽ﾉ",
            "ヽ༼ຈل͜ຈ༽ง",
            "ヽ༼ຈل͜ຈ༽ﾉ",
            "ヽ༼Ὸل͜ຈ༽ﾉ",
            "ヾ(⌐■_■)ノ",
            "꒰･◡･๑꒱",
            "﴾͡๏̯͡๏﴿",
            "｡◕‿◕｡",
            "ʕノ◔ϖ◔ʔノ",
            "꒰•̥̥̥̥̥̥̥ ﹏ •̥̥̥̥̥̥̥̥๑꒱",
            "ಠ_ರೃ",
            "(ू˃̣̣̣̣̣̣︿˂̣̣̣̣̣̣ ू)",
            "(ꈨຶꎁꈨຶ)۶”",
            "(ꐦ°᷄д°᷅)",
            "(۶ૈ ۜ ᵒ̌▱๋ᵒ̌ )۶ૈ=͟͟͞͞ ⌨",
            "₍˄·͈༝·͈˄₎◞ ̑̑ෆ⃛",
            "(*ﾟ⚙͠ ∀ ⚙͠)ﾉ❣",
            "٩꒰･ัε･ั ꒱۶",
            "ヘ（。□°）ヘ",
            "˓˓(ृ　 ु ॑꒳’)ु(ृ’꒳ ॑ ृ　)ु˒˒˒",
            "꒰✘Д✘◍꒱",
            "૮( ᵒ̌ૢཪᵒ̌ૢ )ა",
            "“ψ(｀∇´)ψ",
            "ಠﭛಠ",
            "(๑>ᴗ<๑)",
            "(۶ꈨຶꎁꈨຶ )۶ʸᵉᵃʰᵎ",
            "٩(•̤̀ᵕ•̤́๑)ᵒᵏᵎᵎᵎᵎ",
            "(oT-T)尸",
            "(✌ﾟ∀ﾟ)☞",
            "ಥ‿ಥ",
            "ॱ॰⋆(˶ॢ‾᷄﹃‾᷅˵ॢ)",
            "┬┴┬┴┤  (ಠ├┬┴┬┴",
            "( ˘ ³˘)♥",
            "Σ (੭ु ຶਊ ຶ)੭ु⁾⁾",
            "(⑅ ॣ•͈ᴗ•͈ ॣ)",
            "ヾ(´￢｀)ﾉ",
            "(•̀o•́)ง",
            "(๑•॒̀ ູ॒•́๑)",
            "⚈้̤͡ ˌ̫̮ ⚈้̤͡",
            "=͟͟͞͞ =͟͟͞͞ ﾍ( ´Д`)ﾉ",
            "(((╹д╹;)))",
            "•̀.̫•́✧",
            "(ᵒ̤̑ ₀̑ ᵒ̤̑)",
            @"\_(ʘ_ʘ)_/"};

        public static bool ValidateCommand(string command)
        {
            return O(command) || A(command) || S(command) || H(command);
        }

        public static bool O(string command)
        {
            return CommandListO.Exists(c => c == command);
        }

        public static bool A(string command)
        {
            return CommandListA.Exists(c => c == command);
        }

        public static bool H(string command)
        {
            return CommandListH.Exists(c => c == command);
        }

        public static bool S(string command)
        {
            return CommandListS.Exists(c => c == command);
        }

        private string ListWords(IEnumerable<string> word)
        {
            return word.Aggregate<string, string>(null, (current, item) => current + $" [{item}] ");
        }

        public override string ToString()
        {
            return "Segue a lista dos comandos\n\n" +
                    $"**O** {ListWords(CommandListO)}\n\n" +
                    $"**A** {ListWords(CommandListA)}\n\n" +
                    $"**S** {ListWords(CommandListS)}\n\n" +
                    $"**H** {ListWords(CommandListH)}\n\n" +
                    "( ͡° ͜ʖ ͡°) Boa sorte...";
        }
    }
}