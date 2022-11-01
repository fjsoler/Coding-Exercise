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
        public void NullMatchShouldThrowArgumentNullException()
        {
            new FinishGame(new WorldCupScoreBoardStorage()).Do(null!);
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IfGameNotExistsShoulThowException()
        {
            Match match = new(new Team("Spain"), new Team("Portugal")); //I can do better
            new FinishGame(new WorldCupScoreBoardStorage()).Do(match);
        }

        [TestMethod]
        public void FinishedGameShouldNotExistsInStorage()
        {
            Team homeTeam = new("Spain");
            Team awayTeam = new("Portugal");
            Match match = new (homeTeam, awayTeam); //I can do better

            WorldCupScoreBoardStorage storage = new();

            StartGame startGame = new(storage);
            startGame.Do(match);

            FinishGame finishGame = new(storage);
            finishGame.Do(match);

            Assert.IsFalse(storage.ExistsMatch(match));
        }
    }
}
