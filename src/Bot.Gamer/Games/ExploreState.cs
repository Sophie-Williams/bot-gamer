using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot.Gamer.Games
{
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

            response.Response.Add("Você procura algo para matar.");

            var ran = RandomGenerator.GetRandomNumber(5);
            if (ran == 0)
            {
                response.Response.Add("Um monstro se aproxima! Prepare-se para a batalha!");
                _context.SetState(_context.GetBattleState());
            }
            else if (ran == 1)
            {
                response.Response.Add("Você encontra uma jóia dourada atrás de uma árvore!");
                response.Status = 2;
            }

            return response;
        }

        public RPGResponse Battle(int level)
        {
            var response = new RPGResponse();
            response.Response.Add("Você não encontra nada para atacar.");
            response.Status = 0;
            return response;
        }
        #endregion
    }
}