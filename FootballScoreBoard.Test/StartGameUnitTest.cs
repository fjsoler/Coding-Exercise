namespace FootballScoreBoard.Test
{
    [TestClass]
    public class StartGameUnitTest
    {
        string homeTeam = "Spain";
        string awayTeam = "Portugal";
        string romania = "Romania";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullParameterInConstructorShouldThrowException()
        {
            new StartGame(null!);
        }

        [TestMethod]
        public void StarGameShouldReturnCorrectScore()
        {
            Assert.AreEqual("0 - 0", new StartGame(new ScoreBoardStorage()).Do(homeTeam, awayTeam));
        }

        [TestMethod]
        public void StartGameAddOneItemToScoreBoardListAndLastUpdateIsNotNull()
        {
            ScoreBoardStorage storage = new ScoreBoardStorage();
            StartGame startGame = new StartGame(storage);
            startGame.Do(homeTeam, awayTeam);

            Assert.AreEqual(1, storage.Count);
            Assert.IsNotNull(storage.GetEnumerator().First().LastUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void StarSameGameTwiceShouldThrowException()
        {
            StartGame startGame = new StartGame(new ScoreBoardStorage());
            startGame.Do(homeTeam, awayTeam);
            startGame.Do(homeTeam, awayTeam);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IfHomeTeamAlreadyExistInListShouldThrowException()
        {
            StartGame startGame = new StartGame(new ScoreBoardStorage());
            startGame.Do(homeTeam, awayTeam);
            startGame.Do(homeTeam, romania);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IfAwayTeamAlreadyExistInListShouldThrowException()
        {
            StartGame startGame = new StartGame(new ScoreBoardStorage());
            startGame.Do(homeTeam, awayTeam);
            startGame.Do(romania, awayTeam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParameterOneNullShouldThrowException()
        {
            new StartGame(new ScoreBoardStorage()).Do(null!, awayTeam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParameterTwoNullShouldThrowException()
        {
            new StartGame(new ScoreBoardStorage()).Do(homeTeam, null!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyValuesShouldThrowException()
        {
            new StartGame(new ScoreBoardStorage()).Do("", "");
        }
    }
}