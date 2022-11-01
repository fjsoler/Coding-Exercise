namespace FootballScoreBoard.Test
{
    [TestClass]
    public class StartGameUnitTest
    {
        readonly string homeTeam = "Spain";
        readonly string awayTeam = "Portugal";
        readonly string romania = "Romania";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullParameterInConstructorShouldThrowException()
        {
            new StartGame(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullMatchShouldThrowArgumentNullException()
        {
            WorldCupScoreBoardStorage storage = new();
            StartGame startGame = new(storage);
            startGame.Do(null!);
        }

        [TestMethod]
        public void StarGameShouldReturnCorrectScore()
        {
            StartGame startGame = new StartGame(new WorldCupScoreBoardStorage());
            Match match = new (new Team(homeTeam), new Team(awayTeam));
            Assert.AreEqual("0 - 0", startGame.Do(match));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void StarSameGameTwiceShouldThrowException()
        {
            StartGame startGame = new(new WorldCupScoreBoardStorage());
            startGame.Do(new Match(new Team(homeTeam), new Team(awayTeam)));//I can do better
            startGame.Do(new Match(new Team(homeTeam), new Team(awayTeam)));//I can do better
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IfHomeTeamAlreadyExistInListShouldThrowException()
        {
            StartGame startGame = new(new WorldCupScoreBoardStorage());
            startGame.Do(new Match(new Team(homeTeam), new Team(awayTeam)));//I can do better
            startGame.Do(new Match(new Team(homeTeam), new Team(romania)));//I can do better
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IfAwayTeamAlreadyExistInListShouldThrowException()
        {
            StartGame startGame = new(new WorldCupScoreBoardStorage());
            startGame.Do(new Match(new Team(homeTeam), new Team(awayTeam)));//I can do better
            startGame.Do(new Match(new Team(romania), new Team(awayTeam)));//I can do better
        }
    }
}