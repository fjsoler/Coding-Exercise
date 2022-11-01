using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard.Test
{
    [TestClass]
    public class ScoreUnitTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ScoreOutOfRangeMinShouldThrowArgumentOutOfRangeException()
        {
             Score.FromScalar(-1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HomeTeamScoreOutOfRangeMaxShouldThrowArgumentOutOfRangeException()
        {
            Score.FromScalar(101);
        }
    }
}
