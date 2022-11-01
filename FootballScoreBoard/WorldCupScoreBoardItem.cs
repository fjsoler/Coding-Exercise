namespace FootballScoreBoard
{
    public class WorldCupScoreBoardItem
    {
        public Match Match { get; private set; }

        public ScoreBoard ScoreBoard { get; private set; }   

        public WorldCupScoreBoardItem(Match match, ScoreBoard scoreBoard)
        {
            ArgumentNullException.ThrowIfNull(match, nameof(match));
            ArgumentNullException.ThrowIfNull(scoreBoard, nameof(scoreBoard));

            Match = match;
            ScoreBoard = scoreBoard;
        }

        public override string ToString()
        {
            return $"{Match.HomeTeam.Name} {ScoreBoard.HomeTeamScore} - {Match.AwayTeam.Name} {ScoreBoard.AwayTeamScore}";
        }
        
    }
}