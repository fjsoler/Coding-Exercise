using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard
{
    public class ScoreBoard
    {
        public List<Game> ScoreBoardList { get; set; }

        public ScoreBoard()
        { 
            ScoreBoardList = new List<Game>();
        }

        public string StartGame(string localTeam, string awayTeam)
        {
            Game game = new Game(localTeam, awayTeam);

            if (ScoreBoardList.Exists( x => x.HomeTeam.Name.Equals(localTeam) || x.AwayTeam.Name.Equals(localTeam)))
                throw new Exception("Local Team already exist in scoreboard");

            if (ScoreBoardList.Exists(x => x.HomeTeam.Name.Equals(awayTeam) || x.AwayTeam.Name.Equals(awayTeam)))
                throw new Exception("Away Team already exist in scoreboard");

            if (ScoreBoardList.Exists(x => x.Equals(game)))
                throw new Exception("Game already exist in scoreboard");

            ScoreBoardList.Add(game);
            
            return game.Score;
        }

    }
}
