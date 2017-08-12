namespace Bot.Gamer.Games.Rpg
{
    /// <summary>
    /// O problema principal que o padrão do estado resolve é reduzir a complexidade das 
    /// instruções if-then, que, em última instância, precisamos ao gerenciar informações de estado.
    /// 
    /// Uma vez que vamos criar um role-playing, precisamos saber se o personagem está em um estado 
    /// exploratório, de batalha ou qualquer outro estado que surgir.
    /// 
    /// Para este simples jogo de RPG, vou considerar 2 estados em que nosso personagem possa
    /// estar, bem como 2 comandos que ele pode executar. Ele pode estar explorando uma localidade
    /// ou pode estar em uma Batalha. Neste quesito ele pode escolher Olhar ao redor ou Atacar. Uma 
    /// vez que temos 2 estados e 2 possibilidades de comando, teremos naturalmente 4 situações para 
    /// verificar. Eles são:
    /// 
    /// Estado: Explorar
    ///     Olhar
    ///     Atacar
    /// Estado: Batalhar
    ///     Olhar
    ///     Atacar
    /// </summary>
    public interface IState
    {
        RPGResponse Explore();
        RPGResponse Battle(int level);
    }
}