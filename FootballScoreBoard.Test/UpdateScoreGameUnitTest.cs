namespace FootballScoreBoard.Test
{
    [TestClass]
    public class UpdateScoreGameUnitTest
    {
        readonly Team Spain = new("Spain");
        readonly Team Portugal = new("Portugal");

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewWithNullThrowArgumentNullException()
        {
            new UpdateScoreGame(null!);
        }

        [TestMethod]
        public void NewUpdateScoreGameShouldNotThrowExceptions()
        {
            _ = new UpdateScoreGame(new WorldCupScoreBoardStorage());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateScoreWithMatchNullSouldTrowArgumentNullException()
        {
            UpdateScoreGame updateScoreGame = new(new WorldCupScoreBoardStorage());
            updateScoreGame.Do(null!, 1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UpdateScoreOfNoExistsGameShouldThrowException()
        {
            WorldCupScoreBoardStorage storage = new();
            UpdateScoreGame updateScoreGame = new(storage);

            Match match = new(Spain, Portugal);

            updateScoreGame.Do(match, 1, 0);
        }

        [TestMethod]
        public void UpdateScoreShouldSaveInStorageCorrectly()
        {
            WorldCupScoreBoardStorage storage = new();
            StartGame startGame = new(storage);
            UpdateScoreGame updateScoreGame = new(storage);

            Match match = new(Spain, Portugal);

            startGame.Do(match);
            updateScoreGame.Do(match, 1, 0);

            WorldCupScoreBoardItem? scoreBoardItem = storage.Find(match);

            Assert.IsNotNull(scoreBoardItem);
            Assert.AreEqual("1 - 0", scoreBoardItem.ScoreBoard.ToString());
        }
    }
}
