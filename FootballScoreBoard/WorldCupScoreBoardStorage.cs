namespace FootballScoreBoard
{
    public class WorldCupScoreBoardStorage
    {
        readonly List<WorldCupScoreBoardItem> List;

        public int Count { get { return List.Count; } }

        public WorldCupScoreBoardStorage()
        {
            List = new List<WorldCupScoreBoardItem>();
        }

        public bool ExistsTeam(Team team)
        {
            ArgumentNullException.ThrowIfNull(team, nameof(team));

            return List.Exists(x => x.Match.HomeTeam.Name.Equals(team.Name) || x.Match.AwayTeam.Name.Equals(team.Name));
        }

        public bool ExistsMatch(Match match)
        {
            ArgumentNullException.ThrowIfNull(match, nameof(match));

            return List.Exists(x => x.Match.Equals(match));
        }

        public void Add(Match match, ScoreBoard scoreBoard)
        {
            ArgumentNullException.ThrowIfNull(match, nameof(match));

            WorldCupScoreBoardItem item = new(match, scoreBoard);

            List.Add(item);
        }

        public void Remove(Match match)
        {
            ArgumentNullException.ThrowIfNull(match, nameof(match));

            WorldCupScoreBoardItem? item = List.Find(x => x.Match.Equals(match));

            if (item == null)
                throw new Exception("Match not Exists");

            List.Remove(item!);
        }

        public WorldCupScoreBoardItem? Find(Match match)
        {
            ArgumentNullException.ThrowIfNull(match, nameof(match));

            return List.Find(x => x.Match.Equals(match));
        }

        public IEnumerable<WorldCupScoreBoardItem> GetEnumerator()
        {
            return List;
        }
    }
}
