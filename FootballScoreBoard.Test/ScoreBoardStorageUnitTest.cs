using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard.Test
{
    [TestClass]
    public class ScoreBoardStorageUnitTest
    {
        Game gameSpainPortugal = new("Spain", "Portugal");

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

    }
}
