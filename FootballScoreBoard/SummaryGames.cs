namespace FootballScoreBoard
{
    public class SummaryGames
    {
        ScoreBoardStorage ScoreBoardStorage;

        public SummaryGames(ScoreBoardStorage scoreBoardStorage)
        {
            ArgumentNullException.ThrowIfNull(scoreBoardStorage);

            ScoreBoardStorage = scoreBoardStorage;  
        }

        public List<String> Do()
        {
            return ScoreBoardStorage.GetEnumerator().
                OrderByDescending(x => x.HomeTeam.Score + x.AwayTeam.Score).
                ThenByDescending(x => x.LastUpdate).
                ToList().
                Select(x => $"{x.HomeTeam.Name} {x.HomeTeam.Score} - {x.AwayTeam.Name} {x.AwayTeam.Score}").
                ToList();
        }
    }
}
