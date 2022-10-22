namespace FootballScoreBoard.Test
{
    [TestClass]
    public class TeamUnitTest
    {
        readonly Team Spain = new Team("Spain");
        readonly Team Spain2 = new Team("Spain");
        readonly Team UK = new Team("UK");

        [TestMethod]
        public void TwoSameTeamsShouldEquals()
        {     
            Assert.AreEqual(Spain,Spain2);
        }

        [TestMethod]
        public void TwoDifferentTeamsShouldBeDifferent()
        {
            Assert.AreNotEqual(Spain, UK);
        }

        [TestMethod]
        public void NullTeamCannotBeEqualToAnother()
        {
            Assert.IsFalse(Spain.Equals(null));
        }

        [TestMethod]
        public void TwoSameTeamsShouldHaveHashCodesEquals()
        { 
            Assert.AreEqual(Spain.GetHashCode(), Spain2.GetHashCode());
        }

        [TestMethod]
        public void TwoDifferentTeamsShouldHaveHashCodesDifferents()
        {
            Assert.AreNotEqual(Spain.GetHashCode(), UK.GetHashCode());
        }
    }
}