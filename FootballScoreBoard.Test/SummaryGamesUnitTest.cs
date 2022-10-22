namespace FootballScoreBoard.Test
{
    [TestClass]
    public class SummaryGamesUnitTest
    {
        readonly string Spain = "Spain";
        readonly string Portugal = "Portugal";
        readonly string Mexico = "Mexico";
        readonly string Canada = "Canada";
        readonly string Brazil = "Brazil";
        readonly string Germany = "Germany";
        readonly string France = "France";
        readonly string Uruguay = "Uruguay";
        readonly string Italy = "Italy";
        readonly string Argentina = "Argentina";
        readonly string Australia = "Australia";
        readonly ScoreBoardStorage ScoreBoardStorage; 

        public SummaryGamesUnitTest() 
        {
            ScoreBoardStorage = new();
            StartGame start = new(ScoreBoardStorage);
            UpdateScoreGame update = new(ScoreBoardStorage);
            start.Do(Mexico, Canada);
            start.Do(Spain, Brazil);
            start.Do(Germany, France);
            start.Do(Uruguay, Italy);
            start.Do(Argentina, Australia);
            update.Do(Spain, Brazil, 10, 2);
            update.Do(Uruguay, Italy, 6, 6);
            update.Do(Mexico, Canada,0,5);
            update.Do(Germany, France,2,2);
            update.Do(Argentina, Australia,3,1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewSumaryGamesNullParameterShouldThrowArgumenNullException()
        {
            _ = new SummaryGames(null!);
        }

        [TestMethod]
        public void NewSumaryGamesWithStorageShouldNotNull()
        {
            SummaryGames summary = new(new ScoreBoardStorage());
            Assert.IsNotNull(summary);
        }

        [TestMethod]
        public void GetSummaryShouldReturList()
        {
            SummaryGames summary = new(ScoreBoardStorage);
            List<String> list = summary.Do();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void GetSumaryShouldReturnGoodList()
        {
            ScoreBoardStorage storage = new();
            StartGame startGame = new(storage);
            SummaryGames summary = new(storage);

            startGame.Do(Spain, Portugal);
            
            List<String> resultList = summary.Do();

            Assert.IsNotNull(resultList);
            Assert.AreEqual(1, resultList.Count);
            Assert.AreEqual("Spain 0 - Portugal 0",resultList.First());
        }

        [TestMethod]
        public void GetSummaryShouldReturnGoodOrderedList()
        {
            SummaryGames summary = new(ScoreBoardStorage);

            List<String> resultList = summary.Do();

            Assert.IsNotNull(resultList);
            Assert.AreEqual(5, resultList.Count);
            Assert.AreEqual("Uruguay 6 - Italy 6", resultList[0]);
            Assert.AreEqual("Spain 10 - Brazil 2", resultList[1]);
            Assert.AreEqual("Mexico 0 - Canada 5", resultList[2]);
            Assert.AreEqual("Argentina 3 - Australia 1", resultList[3]);
            Assert.AreEqual("Germany 2 - France 2", resultList[4]);
        }
    }
}
