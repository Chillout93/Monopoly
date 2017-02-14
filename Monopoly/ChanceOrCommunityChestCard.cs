using System;

namespace Monopoly
{
    public enum CardType
    {
        CommunityChest,
        Chance
    }

    public class ChanceOrCommunityChestCard
    {
        public string Name { get; private set; }
        private Action<Player, Board> behaviour;
        public CardType CardType { get; private set; }

        public ChanceOrCommunityChestCard(CardType cardType, string name, Action<Player, Board> behaviour)
        {
            this.CardType = cardType;
            this.Name = name;
            this.behaviour = behaviour;
        }

        public void Execute(Player player, Board board)
        {
            behaviour(player, board);
        }
    }
}
