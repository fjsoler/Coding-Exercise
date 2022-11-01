using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard
{
    public class Score
    {
        private readonly int value;
        
        private Score(int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "Score must be in range [0; 100]");
            }

            this.value = value;
        }

        public override string ToString()
        {
            return value.ToString();
        }


        public static Score FromScalar(int value)
        {
            return new Score(value);
        }

        public static implicit operator int(Score score)
        {
            return score.value;
        }

        public static explicit operator Score(int value)
        {
            return new Score(value);
        }


    }
}
