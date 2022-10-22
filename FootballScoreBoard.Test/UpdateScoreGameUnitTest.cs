namespace FootballScoreBoard.Test
{
    [TestClass]
    public class UpdateScoreGameUnitTest
    {
        readonly string Spain = "Spain";
        readonly string Portugal = "Portugal";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewWithNullThrowArgumentNullException()
        {
            new UpdateScoreGame(null!);
        }

        [TestMethod]
        public void NewUpdateScoreGameShouldNotThrowExceptions()
        {
            _ = new UpdateScoreGame(new ScoreBoardStorage());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateScoreHomeTeamNullSouldTrowArgumentNullException()
        {
            UpdateScoreGame updateScoreGame = new(new ScoreBoardStorage());
            updateScoreGame.Do(null!, Portugal, 1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateScoreAwayTeamNullSouldTrowArgumentNullException()
        {
            UpdateScoreGame updateScoreGame = new(new ScoreBoardStorage());
            updateScoreGame.Do(Spain, null!, 1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UpdateScoreOfNoExistsGameShouldThrowException()
        {
            ScoreBoardStorage storage = new();
            UpdateScoreGame updateScoreGame = new(storage);

            updateScoreGame.Do(Spain, Portugal, 1, 0);
        }

        [TestMethod]
        public void UpdateScoreShouldSaveInStorageCorrectly()
        {
            ScoreBoardStorage storage = new();
            StartGame startGame = new(storage);
            UpdateScoreGame updateScoreGame = new(storage);

            startGame.Do(Spain, Portugal);
            updateScoreGame.Do(Spain, Portugal, 1, 0);

            Game? findGame = storage.Find(new Game(Spain, Portugal));

            Assert.IsTrue(findGame != null);
            Assert.AreEqual("1 - 0", findGame.Score);
        }
    }
}
