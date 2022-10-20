using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard
{
    public class FinishGame
    {
        ScoreBoardStorage ScoreBoardStorage { get; set; }

        public FinishGame(ScoreBoardStorage scoreBoardStorage)
        {
            if (scoreBoardStorage == null) throw new ArgumentNullException("Parameter scoreBoardStorage is null");
            
            ScoreBoardStorage = scoreBoardStorage;
        }

        public void Do(string homeTeam, string awayTeam)
        {
            if (homeTeam == null) throw new ArgumentNullException("Parameter homeTeam is null");
            if (awayTeam == null) throw new ArgumentNullException("Parameter awayTeam is null");

            Game game = new(homeTeam, awayTeam);

            if (!ScoreBoardStorage.ExistsGame(game)) throw new Exception("Game not exists");

            if (!ScoreBoardStorage.Remove(game))
                throw new Exception("Remove game fail");
        }
    }
}
