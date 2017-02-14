using System;
using System.Linq;

namespace Monopoly
{
    public class Utility : IBoardCard, IOwnable
    {
        public Player Player { get; private set; }
        public string Name { get; private set; }
        public int BuyingCost { get; private set; }
        public int MortgageValue { get; private set; }

        public Utility(string name)
        {
            this.Name = name;
            this.BuyingCost = 150;
            this.MortgageValue = 75;
        }

        public void OnLanding(Player player, Board board)
        {
            if (this.Player == null)
                player.MakeOffer(this);
            else
                player.PayPlayer(this.Player, CalculateRentToPay(player, board));
        }

        public void SetPlayer(Player player)
        {
            if (this.Player != null)
                throw new Exception("This deed already has a player.");

            this.Player = player;
        }

        private int CalculateRentToPay(Player player, Board board)
        {
            // check if one or both utilities are owned.
            int rentModifier = (board.GetUtilityCards().Where(x => x.Player == player).Count() == 2) ? 10 : 4;

            return board.Dice.GetLastRoll() * rentModifier;
        }
    }
}
