namespace FootballScoreBoard.Test
{
    [TestClass]
    public class GameUnitTest
    {
        [TestMethod]
        public void GameShouldCreateWithoutAnyException()
        {
            Game game = new Game("Home Team", "Away Team");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GamecCreateShouldThrowArgumentNullExceptionIfAnyParametersAreNull()
        {
            Game game = new Game(null,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GameCreateShouldThrowArgumentExceptionIfAnyParametersIsEmpty()
        {
            Game game = new Game("", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GameCreateShouldThrowArgumentExceptionIfTeamsAreEqual()
        {
            Game game = new Game("SPAIN", "SPAIN");
        }

        [TestMethod]
        public void GameCreateShouldHaveScoreZeroZero()
        {
            Game game = new Game("SPAIN", "PORTUGAL");
            Assert.AreEqual("0 - 0", game.Score);
        }
    }
}