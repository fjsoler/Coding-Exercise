using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard
{
    public class StartGame
    {
        ScoreBoardStorage ScoreBoardStorage;

        public StartGame(ScoreBoardStorage scoreBoardStorage)
        {
            if (scoreBoardStorage == null) throw new ArgumentNullException("Parameter scoreBoardStorage is null");

            ScoreBoardStorage = scoreBoardStorage;
        }

        public string Do(string homeTeam, string awayTeam)
        {
            Game game = new(homeTeam, awayTeam);

            if (ScoreBoardStorage.ExistsTeam(homeTeam))
                throw new Exception("Local Team already exist in scoreboard");

            if (ScoreBoardStorage.ExistsTeam(awayTeam))
                throw new Exception("Away Team already exist in scoreboard");

            ScoreBoardStorage.Add(game);
            
            return game.Score;
        }
    }
}
