using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FootballScoreBoard
{
    public class ScoreBoardStorage
    {
        List<Game> List { get; set; }

        public int Count { get { return List.Count; } }

        public ScoreBoardStorage()
        {
            List = new List<Game>();
        }

        public bool ExistsTeam(string team)
        {
            if (team == null) throw new ArgumentNullException("Parameter team is null");
            if (team.Length == 0) throw new ArgumentException("Parameter team is empty");

            return List.Exists(x => x.HomeTeam.Name.Equals(team) || x.AwayTeam.Name.Equals(team));
        }

        public bool ExistsGame(Game game)
        {
            if (game == null) throw new ArgumentNullException("Parameter team is null");

            return List.Exists(x => x.Equals(game));
        }

        public void Add(Game game)
        {
            List.Add(game);
        }

        public bool Remove(Game game)
        {
            return List.Remove(game);
        }
    }
}
