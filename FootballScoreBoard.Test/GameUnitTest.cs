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
            new Game(Spain, Portugal);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TwoNullsTeamsShouldThrowArgumentNullException()
        {
            new Game(null,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TwoBlankTeamsShouldThrowArgumentException()
        {
            new Game("", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TwoSameTeamsShouldThrowArgumentException()
        {
            new Game(Spain, Spain2);
        }

        [TestMethod]
        public void NewGameShouldReturnCorrectScore()
        {
            Assert.AreEqual("0 - 0", new Game(Spain, Portugal).Score);
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