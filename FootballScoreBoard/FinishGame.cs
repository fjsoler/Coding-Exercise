namespace FootballScoreBoard
{
    public class FinishGame
    {
        readonly WorldCupScoreBoardStorage scoreBoardStorage;

        public FinishGame(WorldCupScoreBoardStorage scoreBoardStorage)
        {
            ArgumentNullException.ThrowIfNull(scoreBoardStorage, nameof(scoreBoardStorage)); 
            
            this.scoreBoardStorage = scoreBoardStorage;
        }

        public void Do(Match match)
        {
            ArgumentNullException.ThrowIfNull(match, nameof(match));

            if (!scoreBoardStorage.ExistsMatch(match)) 
                throw new Exception("The match does not exist");

            scoreBoardStorage.Remove(match);
        }
    }
}
