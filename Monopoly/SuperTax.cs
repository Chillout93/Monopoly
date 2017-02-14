using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class SuperTax : IBoardCard
    {
        private int superTaxFee = 100;

        public void OnLanding(Player player, Board board)
        {
            player.PayFee(superTaxFee);
        }
    }
}
