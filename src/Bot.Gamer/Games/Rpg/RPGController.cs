using System;

namespace Bot.Gamer.Games.Rpg
{
    /// <summary>
    /// Aqui temos uma referência a uma variável de "contexto", que aponta para o controlador 
    /// de estado. O controlador gerencia o estado atual e mapeia o estado. O diálogo do RPG
    /// vai chamar o controlador, não os estados individuais.
    /// </summary>
    [Serializable]
    public class RpgController
    {
        private readonly IState _exploreState;
        private readonly IState _battleState;
        private IState _state;
        private int _level = 1;
        public RpgController()
        {
            _exploreState = new ExploreState(this);
            _battleState = new BattleState(this);
            _state = _exploreState;
        }
        public RPGResponse Explore()
        {
            return _state.Explore();
        }
        public RPGResponse Battle()
        {
            return _state.Battle(_level);
        }
        public void SetState(IState state)
        {
            this._state = state;
        }
        public void SetLevel(int level)
        {
            this._level = level;
        }
        public int GetLevel()
        {
            return _level;
        }
        public IState GetExploreState()
        {
            return _exploreState;
        }
        public IState GetBattleState()
        {
            return _battleState;
        }
    }
}