using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Dice
    {
        private Random rng;
        public int DieSize { get; private set; }
        private int[] rolls = new int[2];

        public Dice()
        {
            DieSize = 7; // Needs to be 1 more than actual size.
            rng = new Random();
        }

        public int RollBoth()
        {
            rolls = new int[] { rng.Next(1, DieSize), rng.Next(1, DieSize) };
            return rolls[0] + rolls[1];
        }

        public int RollOne()
        {
            rolls = new int[] { rng.Next(1, DieSize) };
            return rolls[0];
        }

        public bool IsDoubleRoll()
        {
            if (rolls == null)
                throw new Exception("You need to call RollBoth before IsDoubleRoll can be evaluated.");

            return rolls[0] == rolls[1];
        }

        public int GetLastRoll()
        {
            return rolls[0] + rolls[1];
        }
    }
}
