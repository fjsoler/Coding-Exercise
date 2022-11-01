namespace FootballScoreBoard.Test
{
    [TestClass]
    public class SummaryGamesUnitTest
    {
        readonly WorldCupScoreBoardStorage ScoreBoardStorage; 

        public SummaryGamesUnitTest() 
        {
            ScoreBoardStorage = new();
            StartGame start = new(ScoreBoardStorage);
            UpdateScoreGame update = new(ScoreBoardStorage);

            Team Spain = new("Spain");
            Team Brazil = new("Brazil");
            Team Mexico = new("Mexico");
            Team Canada = new("Canada");
            Team Germany = new("Germany");
            Team France = new("France");
            Team Uruguay = new("Uruguay");
            Team Italy = new("Italy");
            Team Argentina = new("Argentina");
            Team Australia = new("Australia");

            Match matchMexicoCanada = new(Mexico, Canada);
            Match matchSpainBrazil = new(Spain, Brazil);
            Match matchGermanyFrance = new(Germany, France);
            Match matchUruguayItaly = new(Uruguay, Italy);
            Match matchArgetinaAustralia = new(Argentina, Australia);

            start.Do(matchMexicoCanada);
            start.Do(matchSpainBrazil);
            start.Do(matchGermanyFrance);
            start.Do(matchUruguayItaly);
            start.Do(matchArgetinaAustralia);
            update.Do(matchSpainBrazil, 10, 2);
            update.Do(matchUruguayItaly, 6, 6);
            update.Do(matchMexicoCanada, 0, 5);
            update.Do(matchGermanyFrance, 2, 2);
            update.Do(matchArgetinaAustralia, 3, 1);
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
            SummaryGames summary = new(new WorldCupScoreBoardStorage());
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
            WorldCupScoreBoardStorage storage = new();
            StartGame startGame = new(storage);
            SummaryGames summary = new(storage);

            startGame.Do(new Match(new Team("Spain"), new Team("Portugal")));//I can do better

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
