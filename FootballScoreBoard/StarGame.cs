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
            ScoreBoardStorage = scoreBoardStorage;
        }

        public string Do(string localTeam, string awayTeam)
        {
            if (ScoreBoardStorage.ExistsTeam(localTeam))
                throw new Exception("Local Team already exist in scoreboard");

            if (ScoreBoardStorage.ExistsTeam(awayTeam))
                throw new Exception("Away Team already exist in scoreboard");

            Game game = new(localTeam, awayTeam);

            if (ScoreBoardStorage.ExistsGame(game))
                throw new Exception("Game already exist in scoreboard");

            ScoreBoardStorage.Add(game);
            
            return game.Score;
        }
    }
}
