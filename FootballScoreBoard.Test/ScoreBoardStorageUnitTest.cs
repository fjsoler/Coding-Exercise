namespace FootballScoreBoard.Test
{
    [TestClass]
    public class ScoreBoardStorageUnitTest
    {
        readonly Game GameSpainPortugal = new("Spain", "Portugal");
        readonly Team Romania = new("Romania");

        [TestMethod]
        public void TeamShouldExist()
        {
            ScoreBoardStorage storage = new();
            storage.Add(GameSpainPortugal);

            Assert.IsTrue(storage.ExistsTeam(GameSpainPortugal.HomeTeam));
            Assert.IsTrue(storage.ExistsTeam(GameSpainPortugal.AwayTeam));
        }

        [TestMethod]
        public void TeamShouldNotExists()
        {
            ScoreBoardStorage storage = new();
            storage.Add(GameSpainPortugal);

            Assert.IsFalse(storage.ExistsTeam(Romania));
        }

        [TestMethod]
        public void GameShouldExist()
        {
            ScoreBoardStorage storage = new();
            storage.Add(GameSpainPortugal);

            Assert.IsTrue(storage.ExistsGame(GameSpainPortugal));
        }

        [TestMethod]
        public void GameShouldNotExist()
        {
            ScoreBoardStorage storage = new();
            Assert.IsFalse(storage.ExistsGame(new Game("Romania", "France")));
        }

        [TestMethod]
        public void AddGameShouldStorageCountEq1()
        {
            ScoreBoardStorage storage = new();
            storage.Add(GameSpainPortugal);

            Assert.AreEqual(1, storage.Count);
        }

        [TestMethod]
        public void RemoveGameShouldReturnTrueAndStorageCountEqZero()
        {
            ScoreBoardStorage storage = new();
            storage.Add(GameSpainPortugal);
            
            Assert.IsTrue(storage.Remove(GameSpainPortugal));
            Assert.AreEqual(0, storage.Count);
        }

        [TestMethod]
        public void FindExistsGameShouldReturnGame()
        {
            ScoreBoardStorage storage = new();
            storage.Add(GameSpainPortugal);

            Game? findGame = storage.Find(GameSpainPortugal);

            Assert.IsTrue(findGame != null);
            Assert.AreEqual(GameSpainPortugal, findGame);
        }

        [TestMethod]
        public void FindNotExistsGameShouldReturnNull()
        {
            ScoreBoardStorage storage = new();

            Game? findGame = storage.Find(GameSpainPortugal);

            Assert.IsTrue(findGame == null);
        }

        [TestMethod]
        public void GetListShouldReturnIEnumerableNotNull()
        {
            ScoreBoardStorage storage = new();
            IEnumerable<Game> list = storage.GetEnumerator();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void GetEnumeratorCountShouldReturnOne()
        {
            ScoreBoardStorage storage = new();
            storage.Add(GameSpainPortugal);
            Assert.AreEqual(1, storage.GetEnumerator().Count());
        }
    }
}
