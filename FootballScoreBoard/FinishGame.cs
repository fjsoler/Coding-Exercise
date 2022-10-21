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
            if (scoreBoardStorage == null) throw new ArgumentNullException("scoreBoardStorage");
            
            ScoreBoardStorage = scoreBoardStorage;
        }

        public void Do(string homeTeam, string awayTeam)
        {
            Game game = new(homeTeam, awayTeam);

            if (!ScoreBoardStorage.ExistsGame(game)) throw new Exception("Game not exists");

            ScoreBoardStorage.Remove(game);
        }
    }
}
