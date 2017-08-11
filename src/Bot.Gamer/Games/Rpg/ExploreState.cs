using System;

namespace Bot.Gamer.Games.Rpg
{
    [Serializable]
    public class ExploreState : IState
    {
        private readonly RPGController _context;

        public ExploreState(RPGController context)
        {
            this._context = context;
        }

        #region ... IState Members ...
        public RPGResponse Explore()
        {
            var response = new RPGResponse();

            response.Response = response.Response + "\n\nVocê explora a região e procura algum monstro para matar.";

            var ran = RandomGenerator.GetRandomNumber(5);
            if (ran == 0)
            {
                response.Response = response.Response + "\n\n(ง'̀-'́)ง Um monstro se aproxima! Prepare-se para a batalha!";
                _context.SetState(_context.GetBattleState());
            }
            else if (ran == 1)
            {
                response.Response = response.Response + "\n\nMas acaba encontrando Você encontra uma jóia dourada atrás de uma árvore!";
                response.Status = 2;
            }

            return response;
        }

        public RPGResponse Battle(int level)
        {
            var response = new RPGResponse();
            response.Response = response.Response + "\n\nVocê não encontra nada para atacar.";
            response.Status = 0;
            return response;
        }
        #endregion
    }
}