namespace FootballScoreBoard
{
    public class Game
    {
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public string Score { get { return $"{HomeTeam.Score} - {AwayTeam.Score}"; } }
        
        public Game(string homeTeam, string awayTeam)
        {
            HomeTeam = new Team(homeTeam);
            AwayTeam = new Team(awayTeam);

            if (HomeTeam.Equals(AwayTeam)) 
                throw new ArgumentException("The teams are the same and should be different");
            
            LastUpdate = DateTime.Now;
        }

        public void UpdateScore(int homeTeamScore, int awayTeamScore)
        {
            HomeTeam.Score = homeTeamScore;
            AwayTeam.Score = awayTeamScore;
            LastUpdate = DateTime.Now;
        }

        public override bool Equals(object? obj)
        {
            var objGame = obj as Game;

            if (objGame == null) 
                return false;
            
            if (objGame.HomeTeam.Equals(this.HomeTeam) && objGame.AwayTeam.Equals(this.AwayTeam))
                return true;
            
            return false;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + HomeTeam.GetHashCode();
                hash = hash * 23 + AwayTeam.GetHashCode();
                return hash;
            }
        }
    }
}