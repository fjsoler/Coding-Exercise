namespace FootballScoreBoard
{
    public class SummaryGames
    {
        readonly WorldCupScoreBoardStorage scoreBoardStorage;

        public SummaryGames(WorldCupScoreBoardStorage scoreBoardStorage)
        {
            ArgumentNullException.ThrowIfNull(scoreBoardStorage, nameof(scoreBoardStorage));

            this.scoreBoardStorage = scoreBoardStorage;  
        }

        public List<String> Do()
        {
            return scoreBoardStorage.GetEnumerator().
                OrderByDescending(x => x.ScoreBoard.HomeTeamScore + x.ScoreBoard.AwayTeamScore).
                ThenByDescending(x => x.ScoreBoard.LastUpdate).
                ToList().
                Select(x => x.ToString()).
                ToList();
        }
    }
}
