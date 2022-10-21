namespace FootballScoreBoard.Test
{
    [TestClass]
    public class FinishGameUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullParameterInConstructorShouldThrowException()
        {
            new FinishGame(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParametersNullShouldThrowArgumentNullException()
        {
            new FinishGame(new ScoreBoardStorage()).Do(null!, null!);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParameterOneEqNullShouldThrowArgumentNullException()
        {
            new FinishGame(new ScoreBoardStorage()).Do(null!, "Spain");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParameterTwoEqNullShouldThrowArgumentNullException()
        {
            new FinishGame(new ScoreBoardStorage()).Do("Spain", null!);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IfGameNotExistsShoulThowException()
        {
            new FinishGame(new ScoreBoardStorage()).Do("Spain", "Portuga");
        }

        [TestMethod]
        public void FinishedGameShouldNotExistsInStorage()
        {
            string homeTeam = "Spain", awayTeam = "Portugal";
            
            ScoreBoardStorage storage = new();

            StartGame startGame = new(storage);
            startGame.Do(homeTeam, awayTeam);

            FinishGame finishGame = new(storage);
            finishGame.Do(homeTeam, awayTeam);

            if (storage.ExistsGame(new Game(homeTeam, awayTeam)))
                Assert.Fail("Game exist in storage");
        }
    }
}
