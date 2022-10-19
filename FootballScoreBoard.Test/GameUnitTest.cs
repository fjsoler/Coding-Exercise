namespace FootballScoreBoard.Test
{
    [TestClass]
    public class GameUnitTest
    {
        string Spain = "Spain";
        string Spain2 = "Spain";
        string Portugal = "Portugal";

        Game GameSpainPortugal = new Game("Spain", "Portugal");
        Game GameSpainPortugal2 = new Game("Spain", "Portugal");
        Game GameRomaniaFrance = new Game("Romania", "France");

        [TestMethod]
        public void NewGameShouldNotThrowExceptions()
        {
            try 
            { 
                Game game = new Game(Spain, Portugal);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TwoNullsTeamsShouldThrowArgumentNullException()
        {
            Game game = new Game(null,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TwoBlankTeamsShouldThrowArgumentException()
        {
            Game game = new Game("", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TwoSameTeamsShouldThrowArgumentException()
        {
            Game game = new Game(Spain, Spain2);
        }

        [TestMethod]
        public void NewGameShouldReturnCorrectScore()
        {
            Game game = new Game(Spain, Portugal);
            Assert.AreEqual("0 - 0", game.Score);
        }

        [TestMethod]
        public void TwoSameGamesShouldEquals()
        {
            Assert.AreEqual(GameSpainPortugal, GameSpainPortugal2);
        }

        [TestMethod]
        public void TwoDifferentGamesShouldBeDifferent()
        {
            Assert.AreNotEqual(GameSpainPortugal, GameRomaniaFrance);
        }

        [TestMethod]
        public void NullGameCannotBeEqualToAnother()
        {
            Assert.IsFalse(GameSpainPortugal.Equals(null));
        }
    }
}