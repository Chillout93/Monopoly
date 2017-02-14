using System;
using System.Collections.Generic;

namespace Monopoly
{
    public class Station : IOwnable, IBoardCard
    {
        public Player Player { get; private set; }
        public string Name { get; private set; }
        public int BuyingCost { get; private set; }
        public IList<int> Rent { get; private set; }
        public int MortgageValue { get; private set; }

        public Station(string name)
        {
            this.Name = name;
            this.BuyingCost = 200;
            this.Rent = new int[] { 25, 50, 100, 200 };
            this.MortgageValue = 100;
        }

        public void OnLanding(Player player, Board board)
        {
            board.GetStationCards();
            if (player == null)
                player.MakeOffer(this);
        }

        public void SetPlayer(Player player)
        {
            this.Player = player;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", this.BuyingCost, this.Name);
        }
    }
}
