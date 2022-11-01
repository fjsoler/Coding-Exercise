namespace FootballScoreBoard
{
    public class StartGame
    {
        readonly WorldCupScoreBoardStorage scoreBoardStorage;

        public StartGame(WorldCupScoreBoardStorage scoreBoardStorage)
        {
            ArgumentNullException.ThrowIfNull(scoreBoardStorage, nameof(scoreBoardStorage));

            this.scoreBoardStorage = scoreBoardStorage;
        }

        public string Do(Match match)
        {
            ArgumentNullException.ThrowIfNull(match, nameof(match));

            if (scoreBoardStorage.ExistsTeam(match.HomeTeam))
                throw new Exception("Local Team already exist in scoreboard");

            if (scoreBoardStorage.ExistsTeam(match.AwayTeam))
                throw new Exception("Away Team already exist in scoreboard");

            ScoreBoard scoreboard = ScoreBoard.From(0, 0);

            scoreBoardStorage.Add(match, scoreboard);
            
            return scoreboard.ToString()!;
        }
    }
}
