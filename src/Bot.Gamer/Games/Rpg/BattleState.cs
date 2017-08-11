using System;

namespace Bot.Gamer.Games.Rpg
{
    [Serializable]
    public class BattleState : IState
    {
        private readonly RPGController _context;
        private int _rounds = 0;
        public BattleState(RPGController context)
        {
            this._context = context;
        }

        #region ... IState Members ...
        public RPGResponse Explore()
        {
            var response = new RPGResponse();
            response.Response = response.Response + "\n\nVocê adoraria, mas veja, há esse grande e feio monstro na sua frente!";
            response.Status = 0;
            return response;
        }

        public RPGResponse Battle(int level)
        {
            var response = new RPGResponse();

            response.Response = response.Response + "\n\nVocê tenta matar o monstro ...";
            _rounds++;

            var maxRan = 10 - level;
            if (maxRan < 1)
            {
                maxRan = 1;
            }
            var ran = RandomGenerator.GetRandomNumber(maxRan);
            if (ran == 0)
            {
                response.Response = response.Response + "\n\ne ele está morto!";
                _context.SetState(_context.GetExploreState());
                var tempRounds = _rounds;
                _rounds = 0;

                response.Status = tempRounds;
            }
            else
            {
                response.Response = response.Response + "\n\n(ಥ﹏ಥ) ... mas ERRÔÔÔU!!!";
            }

            if (_rounds < 9) return response;

            response.Response = response.Response + "\n\nVocê entra em pânico e foge com medo.";
            _context.SetState(_context.GetExploreState());
            _rounds = 0;

            return response;
        }
        #endregion
    }
}