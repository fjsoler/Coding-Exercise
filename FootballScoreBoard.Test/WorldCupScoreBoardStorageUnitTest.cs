namespace FootballScoreBoard.Test
{
    [TestClass]
    public class WorldCupScoreBoardStorageUnitTest
    {
        readonly Match MatchSpainPortugal = new(new Team("Spain"), new Team("Portugal"));
        readonly Team Romania = new("Romania");

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CallMethodExistsTeamWithNullShouldThrowArgumentNullException()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.ExistsTeam(null!);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CallMethodExistsMatchWithNullShouldThrowArgumentNullException()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.ExistsMatch(null!);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void AddNullMatchShouldThrowArgumentNullException()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Add(null!, ScoreBoard.From(0, 0));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void AddNullScoreboardShouldThrowArgumentNullException()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Add(new Match(new Team("HomeTeam"), new Team("AwayTeam")), null!);//I can do better
        }


        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FindNullShouldThrowArgumentNullException()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Find(null!);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CallMethodRemoveWithNullShouldThrowArgumentNullException()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Remove(null!);
        }

        [TestMethod]
        public void TeamsShouldExist()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Add(MatchSpainPortugal, ScoreBoard.From(0, 0));

            Assert.IsTrue(storage.ExistsTeam(MatchSpainPortugal.HomeTeam));
            Assert.IsTrue(storage.ExistsTeam(MatchSpainPortugal.AwayTeam));
        }

        [TestMethod]
        public void TeamShouldNotExists()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Add(MatchSpainPortugal, ScoreBoard.From(0, 0));

            Assert.IsFalse(storage.ExistsTeam(Romania));
        }

        [TestMethod]
        public void MatchShouldExist()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Add(MatchSpainPortugal, ScoreBoard.From(0, 0));

            Assert.IsTrue(storage.ExistsMatch(MatchSpainPortugal));
        }

        [TestMethod]
        public void MatchShouldNotExist()
        {
            WorldCupScoreBoardStorage storage = new();
            Assert.IsFalse(storage.ExistsMatch(MatchSpainPortugal));
        }

        [TestMethod]
        public void AddMatchShouldStorageCountEq1()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Add(MatchSpainPortugal, ScoreBoard.From(0, 0));

            Assert.AreEqual(1, storage.Count);
        }

        [TestMethod]
        public void RemoveMatchShouldReturnTrueAndStorageCountEqZero()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Add(MatchSpainPortugal, ScoreBoard.From(0, 0));
            storage.Remove(MatchSpainPortugal);

            Assert.AreEqual(0, storage.Count);
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void RemoveNotExistsMatchShouldTrowException()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Remove(MatchSpainPortugal);
        }

        [TestMethod]
        public void FindExistsMatchShouldReturnScoreBoardItem()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Add(MatchSpainPortugal, ScoreBoard.From(0, 0));

            WorldCupScoreBoardItem? findScoreBoardItem = storage.Find(MatchSpainPortugal);

            Assert.IsTrue(findScoreBoardItem != null);
            Assert.AreEqual(MatchSpainPortugal, findScoreBoardItem.Match);
        }

        [TestMethod]
        public void FindNotExistsMatchShouldReturnNull()
        {
            WorldCupScoreBoardStorage storage = new();

            WorldCupScoreBoardItem? findScoreBoardItem = storage.Find(MatchSpainPortugal);

            Assert.IsNull(findScoreBoardItem);
        }

        [TestMethod]
        public void GetListShouldReturnIEnumerableNotNull()
        {
            WorldCupScoreBoardStorage storage = new();
            IEnumerable<WorldCupScoreBoardItem> list = storage.GetEnumerator();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void GetEnumeratorCountShouldReturnOne()
        {
            WorldCupScoreBoardStorage storage = new();
            storage.Add(MatchSpainPortugal, ScoreBoard.From(0, 0)); 
            Assert.AreEqual(1, storage.GetEnumerator().Count());
        }
    }
}
