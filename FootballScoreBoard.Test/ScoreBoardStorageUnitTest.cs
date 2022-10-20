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
        [TestMethod]
        public void TeamShouldExist()
        {
            ScoreBoardStorage storage = new();
            StartGame startGame = new StartGame(storage);
            startGame.Do("Spain", "Portugal");

            Assert.IsTrue(storage.ExistsTeam("Spain"));
            Assert.IsTrue(storage.ExistsTeam("Portugal"));
        }

        [TestMethod]
        public void TeamShouldNotExists()
        {
            ScoreBoardStorage storage = new();
            StartGame startGame = new StartGame(storage);
            startGame.Do("Spain", "Portugal");

            Assert.IsFalse(storage.ExistsTeam("Romania"));
        }

        [TestMethod]
        public void GameShouldExist()
        {
            ScoreBoardStorage storage = new();
            StartGame startGame = new StartGame(storage);
            startGame.Do("Spain", "Portugal");

            Assert.IsTrue(storage.ExistsGame(new Game("Spain","Portugal")));
        }
        [TestMethod]
        public void GameShouldNotExist()
        {
            ScoreBoardStorage storage = new();
            StartGame startGame = new StartGame(storage);
            startGame.Do("Spain", "Portugal");

            Assert.IsFalse(storage.ExistsGame(new Game("Romania", "France")));
        }
    }
}
