using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard.Test
{
    [TestClass]
    public class FinishGameUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullParameterInConstructorShouldThrowException()
        { 
            FinishGame finishGame = new FinishGame(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParametersNullShouldThrowArgumentNullException()
        {
            ScoreBoardStorage storage = new();
            FinishGame finishGame = new FinishGame(storage);
            finishGame.Do(null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParameterOneEqNullShouldThrowArgumentNullException()
        {
            ScoreBoardStorage storage = new();
            FinishGame finishGame = new FinishGame(storage);
            finishGame.Do(null, "Spain");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParameterTwoEqNullShouldThrowArgumentNullException()
        {
            ScoreBoardStorage storage = new();
            FinishGame finishGame = new FinishGame(storage);
            finishGame.Do("Spain", null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IfGameNotExistsShoulThowException()
        {
            ScoreBoardStorage storage = new();
            FinishGame finishGame = new FinishGame(storage);
            finishGame.Do("Spain", "Portuga");
        }

        [TestMethod]
        public void FinishedGameShouldNotExistsInStorage()
        {
            string homeTeam = "Spain", awayTeam = "Portugal";
            ScoreBoardStorage storage = new();

            StartGame startGame = new(storage);
            startGame.Do(homeTeam, awayTeam);

            FinishGame finishGame = new(storage);
            finishGame.Do(homeTeam, awayTeam);

            if (storage.ExistsGame(new Game(homeTeam, awayTeam)))
                Assert.Fail("Game exist in storage");
        }
    }
}
