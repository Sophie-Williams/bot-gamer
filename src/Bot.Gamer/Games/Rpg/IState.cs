namespace Bot.Gamer.Games.Rpg
{
    public interface IState
    {
        RPGResponse Explore();
        RPGResponse Battle(int level);
    }
}