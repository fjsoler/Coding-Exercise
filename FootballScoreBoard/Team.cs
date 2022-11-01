namespace FootballScoreBoard
{
    public class Team
    {
        public string Name { get; private set; }
        
        public Team(string name)
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            
            if (name.Length == 0) 
                throw new ArgumentException("Parameter name is empty");

            Name = name;
        }

        public override bool Equals(object? obj)
        {
            var objTeam = obj as Team;

            if (objTeam == null)
                return false;

            if (objTeam.Name == this.Name) 
                return true;
            
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
