namespace FootballScoreBoard
{
    public class Game
    {
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public string Score { get { return $"{HomeTeam.Score} - {AwayTeam.Score}"; } }
        
        public Game(string homeTeam, string awayTeam)
        {
            HomeTeam = new Team(homeTeam);
            AwayTeam = new Team(awayTeam);

            if (HomeTeam.Name == AwayTeam.Name) throw new ArgumentException("The teams are the same and should be different");
        }
    }
}