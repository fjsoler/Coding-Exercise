using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard
{
    public class Team
    {
        public string Name { get; private set; }
        public int Score { get; set; }
        public Team(string name)
        {
            if (name == null) throw new ArgumentNullException("Parameter name is null");
            if (name.Length == 0) throw new ArgumentException("Parameter name is empty");

            Name = name;
            Score = 0;
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
    }
}
