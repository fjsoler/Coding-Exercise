namespace FootballScoreBoard
{
    public class UpdateScoreGame
    {
        ScoreBoardStorage ScoreBoardStorage { get; set; }

        public UpdateScoreGame(ScoreBoardStorage scoreBoardStorage)
        {
            ArgumentNullException.ThrowIfNull(scoreBoardStorage);

            ScoreBoardStorage = scoreBoardStorage;
        }

        public void Do(string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
        {
            Game game = new(homeTeam, awayTeam);
            
            Game? findGame = ScoreBoardStorage.Find(game);

            if (findGame == null) throw new Exception("Game not exists");

            findGame.UpdateScore(homeTeamScore, awayTeamScore);
        }
    }
}
