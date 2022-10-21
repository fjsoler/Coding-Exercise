namespace FootballScoreBoard
{
    public class StartGame
    {
        readonly ScoreBoardStorage ScoreBoardStorage;

        public StartGame(ScoreBoardStorage scoreBoardStorage)
        {
            ArgumentNullException.ThrowIfNull(scoreBoardStorage);

            ScoreBoardStorage = scoreBoardStorage;
        }

        public string Do(string homeTeam, string awayTeam)
        {
            Game game = new(homeTeam, awayTeam);

            if (ScoreBoardStorage.ExistsTeam(homeTeam))
                throw new Exception("Local Team already exist in scoreboard");

            if (ScoreBoardStorage.ExistsTeam(awayTeam))
                throw new Exception("Away Team already exist in scoreboard");

            ScoreBoardStorage.Add(game);
            
            return game.Score;
        }
    }
}
