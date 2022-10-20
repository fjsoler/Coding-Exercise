using System;
using System.Collections.Generic;

namespace FootballScoreBoard
{
    public class ScoreBoardStorage
    {
        List<Game> List { get; set; }

        public ScoreBoardStorage()
        {
            List = new List<Game>();
        }
    }
}
