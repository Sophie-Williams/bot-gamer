using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot.Gamer.Games
{
    public class BattleState : IState
    {
        private RPGController context;
        private int _rounds = 0;
        public BattleState(RPGController context)
        {
            this.context = context;
        }

        #region ... IState Members ...
        public RPGResponse Explore()
        {
            var response = new RPGResponse();
            response.Response.Add("Você adoraria, mas veja, há esse grande e feio monstro na sua frente!");
            response.Status = 0;
            return response;
        }

        public RPGResponse Battle(int level)
        {
            var response = new RPGResponse();

            response.Response.Add("Você tenta matar o monstro .. ");
            _rounds++;
            System.Threading.Thread.Sleep(1000);
            int maxRan = 10 - level;
            if (maxRan < 1)
            {
                maxRan = 1;
            }
            int ran = RandomGenerator.GetRandomNumber(maxRan);
            if (ran == 0)
            {
                response.Response.Add("ele está morto!");
                context.SetState(context.GetExploreState());
                int tempRounds = _rounds;
                _rounds = 0;

                response.Status = tempRounds;
            }
            else
            {
                response.Response.Add("mas ERROU!!!");
            }
            if (_rounds >= 9)
            {
                response.Response.Add("Você entra em pânico e fugiu com medo.");
                context.SetState(context.GetExploreState());
                _rounds = 0;
            }
            response.Status = 0;
            return response;
        }
        #endregion
    }
}