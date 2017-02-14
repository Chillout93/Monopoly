using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public interface IOwnable
    {
        int BuyingCost { get; }
        Player Player { get; }
        void SetPlayer(Player player);
    }
}
