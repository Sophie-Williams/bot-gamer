using System;

namespace Bot.Gamer.Games.Rpg
{
    [Serializable]
    public class RPGController
    {
        private IState exploreState;
        private IState battleState;
        private IState state;
        private int level = 1;
        public RPGController()
        {
            exploreState = new ExploreState(this);
            battleState = new BattleState(this);
            state = exploreState;
        }
        public RPGResponse Explore()
        {
            return state.Explore();
        }
        public RPGResponse Battle()
        {
            return state.Battle(level);
        }
        public void SetState(IState state)
        {
            this.state = state;
        }
        public void SetLevel(int level)
        {
            this.level = level;
        }
        public int GetLevel()
        {
            return level;
        }
        public IState GetExploreState()
        {
            return exploreState;
        }
        public IState GetBattleState()
        {
            return battleState;
        }
    }
}