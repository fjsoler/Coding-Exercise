namespace FootballScoreBoard.Test
{
    [TestClass]
    public class WorldCupScoreBoardItemUnitTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NullMatchShouldThrowArgumentNullException()
        {
            _ = new WorldCupScoreBoardItem(null!, ScoreBoard.From(0, 0));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NullScoreBoardShouldThrowArgumentNullException()
        {
            Match match = new(new Team("homeTeam"), new Team("awayTeam"));

            _ = new WorldCupScoreBoardItem(match, null!);
        }
    }
}
