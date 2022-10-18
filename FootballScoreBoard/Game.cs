namespace FootballScoreBoard
{
    public class Game
    {
        public string HomeTeam { get; private set; }
        public string AwayName { get; private set; }
        private int HomeTeamScore { get; set; }
        private int AwayTeamScore { get; set; }
        public string Score { get { return $"{HomeTeamScore} - {AwayTeamScore}"; } }
        
        public Game(string homeTeam, string awayTeam)
        {
            if (homeTeam == null) throw new ArgumentNullException(nameof(homeTeam));
            if (awayTeam == null) throw new ArgumentNullException(nameof(awayTeam));
            if (homeTeam.Length == 0) throw new ArgumentException("Home team is empty");
            if (awayTeam.Length == 0) throw new ArgumentException("Away team is empty");
            if (homeTeam == awayTeam) throw new ArgumentException("The teams are the same and should be different");

            HomeTeam = homeTeam;
            AwayName = awayTeam;
            HomeTeamScore = 0;
            AwayTeamScore = 0;
        }
    }
}