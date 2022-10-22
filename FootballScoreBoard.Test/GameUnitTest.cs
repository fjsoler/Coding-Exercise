namespace FootballScoreBoard.Test
{
    [TestClass]
    public class GameUnitTest
    {
        readonly string Spain = "Spain";
        readonly string Spain2 = "Spain";
        readonly string Portugal = "Portugal";

        readonly Game GameSpainPortugal = new("Spain", "Portugal");
        readonly Game GameSpainPortugal2 = new("Spain", "Portugal");
        readonly Game GameRomaniaFrance = new("Romania", "France");

        [TestMethod]
        public void NewGameShouldNotThrowExceptions()
        {
            _ = new Game(Spain, Portugal);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TwoNullsTeamsShouldThrowArgumentNullException()
        {
            new Game(null!, null!);
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

        [TestMethod]
        public void TwoSameGamesShouldHaveHashCodesEquals()
        {
            Assert.AreEqual(GameSpainPortugal.GetHashCode(), GameSpainPortugal2.GetHashCode());
        }

        [TestMethod]
        public void TwoDifferentGamesShouldHaveHashCodesDifferents()
        {
            Assert.AreNotEqual(GameSpainPortugal.GetHashCode(), GameRomaniaFrance.GetHashCode());
        }

        [TestMethod]
        public void UpdateScoreShouldSaveCorretly()
        {
            Game game = new ("Spain", "Portugal");
            game.UpdateScore(1, 0);
            Assert.AreEqual("1 - 0", game.Score);
        }

        [TestMethod]
        public void NewGameShouldLastUpdateNotNull()
        {
            Game game = new(Spain, Portugal);
            Assert.IsNotNull(game.LastUpdate);
        }

        [TestMethod]
        public void UpdateScoreShouldChangeLastUpdate()
        {
            Game game = new("Spain", "Portugal");
            DateTime? oldLastUpdate = game.LastUpdate;
            game.UpdateScore(1, 0);
            Assert.IsNotNull(oldLastUpdate);
            Assert.IsNotNull(game.LastUpdate);
            Assert.AreNotEqual(oldLastUpdate, game.LastUpdate);
        }
    }
}