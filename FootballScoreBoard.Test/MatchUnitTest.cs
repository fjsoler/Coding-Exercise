namespace FootballScoreBoard.Test
{
    [TestClass]
    public class MatchUnitTest
    {
        readonly Team Spain = new("Spain");
        readonly Team Spain2 = new("Spain");
        readonly Team Portugal = new("Portugal");

        readonly Match MatchSpainPortugal = new(new Team("Spain"), new Team("Portugal"));
        readonly Match MatchSpainPortugal2 = new(new Team("Spain"), new Team("Portugal"));
        readonly Match MatchRomaniaFrance = new(new Team("Romania"), new Team("France"));

        [TestMethod]
        public void NewMatchShouldNotThrowExceptions()
        {
            _ = new Match(Spain, Portugal);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullHomeTeamShouldThrowArgumentNullException()
        {
            new Match(null!, Portugal);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullAwayTeamShouldThrowArgumentNullException()
        {
            new Match(Spain, null!);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TwoSameTeamsShouldThrowArgumentException()
        {
            new Match(Spain, Spain2);
        }

        [TestMethod]
        public void TwoSameGamesShouldEquals()
        {
            Assert.AreEqual(MatchSpainPortugal, MatchSpainPortugal2);
        }

        [TestMethod]
        public void TwoDifferentGamesShouldBeDifferent()
        {
            Assert.AreNotEqual(MatchSpainPortugal, MatchRomaniaFrance);
        }

        [TestMethod]
        public void NullGameCannotBeEqualToAnother()
        {
            Assert.IsFalse(MatchSpainPortugal.Equals(null));
        }

        [TestMethod]
        public void TwoSameGamesShouldHaveHashCodesEquals()
        {
            Assert.AreEqual(MatchSpainPortugal.GetHashCode(), MatchSpainPortugal2.GetHashCode());
        }

        [TestMethod]
        public void TwoDifferentGamesShouldHaveHashCodesDifferents()
        {
            Assert.AreNotEqual(MatchSpainPortugal.GetHashCode(), MatchRomaniaFrance.GetHashCode());
        }
    }
}