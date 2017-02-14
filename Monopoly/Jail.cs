using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Jail : IBoardCard
    {
        public void OnLanding(Player player, Board board)
        {
            // Just Visiting
        }

        public void PutInJail(Player player)
        {
            // JailLogic Separate Class
        }
    }
}
