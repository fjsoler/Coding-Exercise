namespace FootballScoreBoard
{
    public class FinishGame
    {
        readonly ScoreBoardStorage ScoreBoardStorage;

        public FinishGame(ScoreBoardStorage scoreBoardStorage)
        {
            ArgumentNullException.ThrowIfNull(scoreBoardStorage); 
            
            ScoreBoardStorage = scoreBoardStorage;
        }

        public void Do(string homeTeam, string awayTeam)
        {
            Game game = new(homeTeam, awayTeam);

            if (!ScoreBoardStorage.ExistsGame(game)) throw new Exception("Game not exists");

            ScoreBoardStorage.Remove(game);
        }
    }
}
