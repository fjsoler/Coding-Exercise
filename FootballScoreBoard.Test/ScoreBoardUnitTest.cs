using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard.Test
{
    [TestClass]
    public class ScoreBoardUnitTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NullHomeTeamScoreShouldThrowArgumentNullException()
        {
            _ = new ScoreBoard(null!, Score.FromScalar(0));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NullAwayTeamScoreShouldThrowArgumentNullException()
        {
            _ = new ScoreBoard(Score.FromScalar(0), null!);
        }

        [TestMethod]
        public void UpdateScoreShouldSaveCorretly()
        {
            ScoreBoard scoreBoard = ScoreBoard.From(0,0);
            scoreBoard.UpdateScore(1, 0);
            Assert.AreEqual("1 - 0", scoreBoard.ToString());
        }

        [TestMethod]
        public void NewScoreBoardShouldNotNullLastUpdate()
        {
            ScoreBoard scoreBoard = ScoreBoard.From(0, 0);
            Assert.IsNotNull(scoreBoard.LastUpdate);
        }

        [TestMethod]
        public void UpdateScoreShouldChangeLastUpdate()
        {
            ScoreBoard scoreBoard = ScoreBoard.From(0, 0);
            DateTime? oldLastUpdate = scoreBoard.LastUpdate;
            scoreBoard.UpdateScore(1, 0);
            Assert.IsNotNull(oldLastUpdate);
            Assert.IsNotNull(scoreBoard.LastUpdate);
            Assert.AreNotEqual(oldLastUpdate, scoreBoard.LastUpdate);
        }
    }
}
