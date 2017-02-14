using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class IncomeTax : IBoardCard
    {
        private int incomeTaxFee = 200;

        public void OnLanding(Player player, Board board)
        {
            player.PayFee(incomeTaxFee);
        }
    }
}
