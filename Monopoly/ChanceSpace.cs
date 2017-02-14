using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class ChanceSpace : IBoardCard
    {
        public void OnLanding(Player player, Board board)
        {
            ChanceOrCommunityChestCard chanceCard = board.GetNextChanceCard();
            chanceCard.Execute(player, board);
        }
    }
}
