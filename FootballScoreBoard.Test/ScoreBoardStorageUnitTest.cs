namespace FootballScoreBoard.Test
{
    [TestClass]
    public class ScoreBoardStorageUnitTest
    {
        readonly Game gameSpainPortugal = new("Spain", "Portugal");
        
        [TestMethod]
        public void TeamShouldExist()
        {
            ScoreBoardStorage storage = new();
            storage.Add(gameSpainPortugal);

            Assert.IsTrue(storage.ExistsTeam("Spain"));
            Assert.IsTrue(storage.ExistsTeam("Portugal"));
        }

        [TestMethod]
        public void TeamShouldNotExists()
        {
            ScoreBoardStorage storage = new();
            storage.Add(gameSpainPortugal);

            Assert.IsFalse(storage.ExistsTeam("Romania"));
        }

        [TestMethod]
        public void GameShouldExist()
        {
            ScoreBoardStorage storage = new();
            storage.Add(gameSpainPortugal);

            Assert.IsTrue(storage.ExistsGame(gameSpainPortugal));
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
            storage.Add(gameSpainPortugal);

            Assert.AreEqual(1, storage.Count);
        }

        [TestMethod]
        public void RemoveGameShouldReturnTrueAndStorageCountEqZero()
        {
            ScoreBoardStorage storage = new();
            storage.Add(gameSpainPortugal);
            
            Assert.IsTrue(storage.Remove(gameSpainPortugal));
            Assert.AreEqual(0, storage.Count);
        }

        [TestMethod]
        public void FindExistsGameShouldReturnGame()
        {
            ScoreBoardStorage storage = new();
            storage.Add(gameSpainPortugal);

            Game? findGame = storage.Find(gameSpainPortugal);

            Assert.IsTrue(findGame != null);
            Assert.AreEqual(gameSpainPortugal, findGame);
        }

        [TestMethod]
        public void FindNotExistsGameShouldReturnNull()
        {
            ScoreBoardStorage storage = new();

            Game? findGame = storage.Find(gameSpainPortugal);

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
            storage.Add(gameSpainPortugal);
            Assert.AreEqual(1, storage.GetEnumerator().Count());
        }
    }
}
