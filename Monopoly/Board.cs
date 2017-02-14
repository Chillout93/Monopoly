using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Board
    {
        private IQueryable<IBoardCard> boardCards;

        private int currentChance;
        private IEnumerable<ChanceOrCommunityChestCard> chances;
        private int currentCommunityChest;
        private IEnumerable<ChanceOrCommunityChestCard> communityChests;
        private int houses;
        private int hotels;
        public Dice Dice { get; private set; }
        public IList<Player> Players { get; private set; }

        public Board(BoardBuilder boardBuilder, Dice dice, IList<Player> players)
        {
            this.Players = players;
            this.Dice = dice;
            currentChance = 0;
            currentCommunityChest = 0;
            hotels = 12;
            houses = 32;
            boardCards = boardBuilder.BuildStandardBoard();
            chances = boardBuilder.BuildStandardChanceCards();
            communityChests = boardBuilder.BuildStandardCommunityChestCards();
        }

        public IBoardCard GetBoardCard(int index)
        {
            return boardCards.ElementAt(index % 40);
        }

        public IQueryable<Station> GetStationCards()
        {
            return boardCards.OfType<Station>();
        }

        public IQueryable<IOwnable> GetUtilityCards()
        {
            return boardCards.OfType<Utility>();
        }

        public ChanceOrCommunityChestCard GetNextChanceCard()
        {
            ChanceOrCommunityChestCard chance = chances.ElementAt(currentChance);
            currentChance = (currentChance + 1) % 16; // There are only 16 cards so loop through.

            return chance;
        }

        public ChanceOrCommunityChestCard GetNextCommunityChestCard()
        {
            ChanceOrCommunityChestCard communityChest = communityChests.ElementAt(currentChance);
            currentCommunityChest = (currentCommunityChest + 1) % 16; // There are only 16 cards so loop through.

            return communityChest;
        }

        public int NumberOfPlayerHouses(Player player)
        {
            int numberOfHouses = 0;
            foreach (Deed ownableBoard in boardCards.OfType<Deed>())
                numberOfHouses += ownableBoard.RentModifier;

            return numberOfHouses;
        }
    }
}
