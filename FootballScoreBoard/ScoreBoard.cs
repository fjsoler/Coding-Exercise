using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard
{
    public class ScoreBoard
    {
        public Score HomeTeamScore { get; private set; }
        public Score AwayTeamScore { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        public ScoreBoard (Score homeTeamScore, Score awayTeamScore)
        {
            ArgumentNullException.ThrowIfNull(homeTeamScore,nameof(homeTeamScore));
            ArgumentNullException.ThrowIfNull(awayTeamScore, nameof(awayTeamScore));

            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
            LastUpdate = DateTime.Now;
        }

        public static ScoreBoard From(int homeValue, int awayValue)
        {
            return new((Score)homeValue, (Score)awayValue);
        }

        public void UpdateScore(int homeTeamScore, int awayTeamScore)
        {
            HomeTeamScore = (Score)homeTeamScore;
            AwayTeamScore = (Score)awayTeamScore;
            LastUpdate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{HomeTeamScore} - {AwayTeamScore}";
        }
    }
}
