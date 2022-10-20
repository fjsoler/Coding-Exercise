namespace FootballScoreBoard.Test
{
    [TestClass]
    public class StartGameTest
    {
        string LocalTeam = "Spain";
        string AwayTeam = "Portugal";

        [TestMethod]
        public void StarGameShouldReturnCorrectScore()
        {
            ScoreBoardStorage storage = new ScoreBoardStorage();
            StartGame startGame = new StartGame(storage);
            Assert.AreEqual("0 - 0", startGame.Do(LocalTeam, AwayTeam));
        }

        [TestMethod]
        public void StartGameAddOneItemToScoreBoardList()
        {
            ScoreBoardStorage storage = new ScoreBoardStorage();
            StartGame startGame = new StartGame(storage);
            startGame.Do(LocalTeam, AwayTeam);

            Assert.AreEqual(1, storage.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void StarSameGameTwiceShouldThrowException()
        {
            ScoreBoardStorage storage = new ScoreBoardStorage();
            StartGame startGame = new StartGame(storage);
            startGame.Do(LocalTeam, AwayTeam);
            startGame.Do(LocalTeam, AwayTeam);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IfTeamAlreadyExistInListShouldThrowException()
        {
            ScoreBoardStorage storage = new ScoreBoardStorage();
            StartGame startGame = new StartGame(storage);
            startGame.Do(LocalTeam, AwayTeam);
            startGame.Do(AwayTeam, LocalTeam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullValuesShouldThrowException()
        {
            ScoreBoardStorage storage = new ScoreBoardStorage();
            StartGame startGame = new StartGame(storage);
            startGame.Do(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyValuesShouldThrowException()
        {
            ScoreBoardStorage storage = new ScoreBoardStorage();
            StartGame startGame = new StartGame(storage);
            startGame.Do("", "");
        }
    }
}