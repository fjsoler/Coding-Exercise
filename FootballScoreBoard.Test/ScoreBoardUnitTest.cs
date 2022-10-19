namespace FootballScoreBoard.Test
{
    [TestClass]
    public class ScoreBoarTest
    {
        string LocalTeam = "Spain";
        string AwayTeam = "Portugal";

        [TestMethod]
        public void StarGameShouldReturnCorrectScore()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            Assert.AreEqual("0 - 0", scoreBoard.StartGame(LocalTeam, AwayTeam));
        }

        [TestMethod]
        public void StartGameAddOneItemToScoreBoardList()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.StartGame(LocalTeam, AwayTeam);

            Assert.AreEqual(1, scoreBoard.ScoreBoardList.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void StarSameGameTwiceShouldThrowException()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.StartGame(LocalTeam, AwayTeam);
            scoreBoard.StartGame(LocalTeam, AwayTeam);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IfTeamAlreadyExistInListShouldThrowException()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.StartGame(LocalTeam, AwayTeam);
            scoreBoard.StartGame(AwayTeam, LocalTeam);
        }
    }
}