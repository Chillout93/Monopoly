using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CommunityChestSpace : IBoardCard
    {
        public void OnLanding(Player player, Board board)
        {
            ChanceOrCommunityChestCard communityChest = board.GetNextCommunityChestCard();
            communityChest.Execute(player, board);
        }
    }
}
