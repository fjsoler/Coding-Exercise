namespace FootballScoreBoard
{
    public class ScoreBoardStorage
    {
        readonly List<Game> List;

        public int Count { get { return List.Count; } }

        public ScoreBoardStorage()
        {
            List = new List<Game>();
        }

        public bool ExistsTeam(string team)
        {
            ArgumentNullException.ThrowIfNull(team);

            if (team.Length == 0) throw new ArgumentException("Parameter team is empty");

            return List.Exists(x => x.HomeTeam.Name.Equals(team) || x.AwayTeam.Name.Equals(team));
        }

        public bool ExistsGame(Game game)
        {
            ArgumentNullException.ThrowIfNull(game);

            return List.Exists(x => x.Equals(game));
        }

        public void Add(Game game)
        {
            List.Add(game);
        }

        public bool Remove(Game game)
        {
            return List.Remove(game);
        }

        public Game? Find(Game game)
        {
            return List.Find(x => x.Equals(game));
        }

        public IEnumerable<Game> GetEnumerator()
        {
            return List;
        }
    }
}
