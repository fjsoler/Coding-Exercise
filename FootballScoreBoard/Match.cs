namespace FootballScoreBoard
{
    public class Match
    {
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        
        public Match(Team homeTeam, Team awayTeam)
        {
            ArgumentNullException.ThrowIfNull(homeTeam, nameof(homeTeam));
            ArgumentNullException.ThrowIfNull(awayTeam, nameof(awayTeam));  

            if (homeTeam.Equals(awayTeam))
                throw new ArgumentException("The parameters homeTeam and awayTeam must be differents");

            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Match objMatch)
                return false;

            if (objMatch.HomeTeam.Equals(HomeTeam) && objMatch.AwayTeam.Equals(AwayTeam))
                return true;
            
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(HomeTeam, AwayTeam);
        }
    }
}