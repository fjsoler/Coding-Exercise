namespace FootballScoreBoard
{
    public class UpdateScoreGame
    {
        WorldCupScoreBoardStorage ScoreBoardStorage { get; set; }

        public UpdateScoreGame(WorldCupScoreBoardStorage scoreBoardStorage)
        {
            ArgumentNullException.ThrowIfNull(scoreBoardStorage, nameof(scoreBoardStorage));

            ScoreBoardStorage = scoreBoardStorage;
        }

        public void Do(Match match, int homeTeamScore, int awayTeamScore)
        {
            ArgumentNullException.ThrowIfNull(match, nameof(match));

            WorldCupScoreBoardItem? worldCupScoreBoardItem = ScoreBoardStorage.Find(match);

            if (worldCupScoreBoardItem == null) throw new Exception("Match not exists!");

            worldCupScoreBoardItem.ScoreBoard.UpdateScore(homeTeamScore, awayTeamScore);
        }
    }
}
