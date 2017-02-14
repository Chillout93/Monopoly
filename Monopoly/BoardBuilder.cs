using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class BoardBuilder
    {
        // The order in which cards are added matters, index is used to determine place on board.
        public IQueryable<IBoardCard> BuildStandardBoard()
        {
            IList<IBoardCard> boardCards = new List<IBoardCard>();

            boardCards.Add(new Go());
            boardCards.Add(new Deed("Old Kent Road", PropertyColour.Brown, 60, new int[] { 2, 10, 30, 90, 160, 250 }, 30, 30, 50));
            boardCards.Add(new CommunityChestSpace());
            boardCards.Add(new Deed("Whitechapel Road", PropertyColour.Brown, 60, new int[] { 4, 20, 60, 180, 360, 450 }, 30, 30, 50));
            boardCards.Add(new IncomeTax());
            boardCards.Add(new Station("Kings Cross Station"));
            boardCards.Add(new Deed("The Angel Islington", PropertyColour.LightBlue, 100, new int[] { 6, 30, 90, 270, 400, 550 }, 50, 50, 50));
            boardCards.Add(new ChanceSpace());
            boardCards.Add(new Deed("Euston Road", PropertyColour.LightBlue, 100, new int[] { 6, 30, 90, 270, 400, 550 }, 50, 50, 50));
            boardCards.Add(new Deed("Pentonville Road", PropertyColour.LightBlue, 100, new int[] { 8, 40, 100, 300, 450, 600 }, 50, 50, 60));
            boardCards.Add(new Jail());
            boardCards.Add(new Deed("Pall Mall", PropertyColour.Pink, 140, new int[] { 10, 50, 150, 450, 625, 750 }, 100, 100, 70));
            boardCards.Add(new Utility("Electric Company"));
            boardCards.Add(new Deed("Whitehall", PropertyColour.Pink, 140, new int[] { 10, 50, 150, 450, 625, 750 }, 100, 100, 70));
            boardCards.Add(new Deed("Northumberland Avenue", PropertyColour.Pink, 160, new int[] { 12, 60, 180, 500, 700, 900 }, 100, 100, 80));
            boardCards.Add(new Station("Marylebone Station"));
            boardCards.Add(new Deed("Bow Street", PropertyColour.Orange, 180, new int[] { 14, 70, 200, 550, 750, 950 }, 100, 100, 90));
            boardCards.Add(new CommunityChestSpace());
            boardCards.Add(new Deed("Marlborough Street", PropertyColour.Orange, 180, new int[] { 14, 70, 200, 550, 750, 950 }, 100, 100, 90));
            boardCards.Add(new Deed("Vine Street", PropertyColour.Orange, 200, new int[] { 16, 80, 220, 600, 800, 1000 }, 100, 100, 100));
            boardCards.Add(new FreeParking());
            boardCards.Add(new Deed("The Strand", PropertyColour.Red, 220, new int[] { 18, 90, 250, 700, 875, 1050 }, 150, 150, 110));
            boardCards.Add(new ChanceSpace());
            boardCards.Add(new Deed("Fleet Street", PropertyColour.Red, 220, new int[] { 18, 90, 250, 700, 875, 1050 }, 150, 150, 110));
            boardCards.Add(new Deed("Trafalgar Square", PropertyColour.Red, 240, new int[] { 20, 100, 300, 750, 925, 1100 }, 150, 150, 120));
            boardCards.Add(new Station("Fenchurch Street Station"));
            boardCards.Add(new Deed("Leicester Square", PropertyColour.Yellow, 260, new int[] { 22, 110, 330, 800, 975, 1150 }, 150, 150, 150));
            boardCards.Add(new Deed("Coventry Street", PropertyColour.Yellow, 260, new int[] { 22, 110, 330, 800, 975, 1150 }, 150, 150, 150));
            boardCards.Add(new Utility("Water Works"));
            boardCards.Add(new Deed("Piccadilly", PropertyColour.Yellow, 280, new int[] { 22, 120, 360, 850, 1025, 1200 }, 140, 140, 150));
            boardCards.Add(new GoToJail());
            boardCards.Add(new Deed("Regent Street", PropertyColour.Green, 300, new int[] { 26, 130, 390, 900, 1100, 1275 }, 150, 150, 200));
            boardCards.Add(new Deed("Oxford Street", PropertyColour.Green, 300, new int[] { 26, 130, 390, 900, 1100, 1275 }, 150, 150, 200));
            boardCards.Add(new CommunityChestSpace());
            boardCards.Add(new Deed("Bond Street", PropertyColour.Green, 320, new int[] { 28, 150, 450, 1000, 1200, 1400 }, 160, 160, 200));
            boardCards.Add(new Station("Liverpool Street Station"));
            boardCards.Add(new ChanceSpace());
            boardCards.Add(new Deed("Park Lane", PropertyColour.DarkBlue, 350, new int[] { 35, 175, 500, 1100, 1300, 1500 }, 200, 200, 175));
            boardCards.Add(new SuperTax());
            boardCards.Add(new Deed("Mayfair", PropertyColour.DarkBlue, 400, new int[] { 50, 200, 600, 1400, 1700, 2000 }, 200, 200, 200));

            return boardCards.AsQueryable();
        }

        public IList<ChanceOrCommunityChestCard> BuildStandardChanceCards()
        {
            IList<ChanceOrCommunityChestCard> chanceCards = new List<ChanceOrCommunityChestCard>();

            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Advance To Go", (Player player, Board board) => player.MoveDirectly(0)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Advance To Trafalgar Square", (Player player, Board board) => player.MoveDirectly(24)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Advance To Pall Mall", (Player player, Board board) => player.MoveDirectly(11)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Advance To Marylebone Station", (Player player, Board board) => player.MoveDirectly(15)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Go To Jail", (Player player, Board board) => player.GoToJail()));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Advance To Mayfair", (Player player, Board board) => player.MoveDirectly(39)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Go Back Three Spaces", (Player player, Board board) => player.MoveDirectly(-3)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Make general repairs on all of your houses. For each house pay £25. For each hotel pay £100", (Player player, Board board) => board.NumberOfPlayerHouses(player)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "You are assessed for street repairs: £40 per house, £115 per hotel", (Player player, Board board) => player.PayFee(40 * board.NumberOfPlayerHouses(player))));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Pay school fees of £150", (Player player, Board board) => player.PayFee(150)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Drunk in charge fine £20", (Player player, Board board) => player.PayFee(20)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Speeding fine £15", (Player player, Board board) => player.PayFee(15)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Your building loan matures. Receive £150", (Player player, Board board) => player.ReceiveMoney(150)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "You have won a crossword competition. Collect £100", (Player player, Board board) => player.ReceiveMoney(100)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance, "Bank pays you dividend of £50", (Player player, Board board) => player.ReceiveMoney(50)));
            chanceCards.Add(new ChanceOrCommunityChestCard(CardType.Chance,  "Get out of jail free. This card may be kept until needed or sold", (Player player, Board board) => player.ReceiveGetOutOfJailCard()));

            return chanceCards;
        }

        public IList<ChanceOrCommunityChestCard> BuildStandardCommunityChestCards()
        {
            IList<ChanceOrCommunityChestCard> communityChestCards = new List<ChanceOrCommunityChestCard>();

            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Advance To Go", (Player player, Board board) => { player.MoveDirectly(0); Console.WriteLine("{0} advances to go!", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Go Back To Old Kent Road", (Player player, Board board) => { player.MoveDirectly(24); Console.WriteLine("{0} moves back to Old Kent Road!"); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Go to jail. Move directly to jail. Do not pass Go. Do not collect £200", (Player player, Board board) => { player.MoveDirectly(11); Console.WriteLine("{0} Goes directly to Jail.", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Pay hospital £100", (Player player, Board board) => { player.PayFee(100); Console.WriteLine("{0} pays hospital fee of £100", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Doctor's fee. Pay £50", (Player player, Board board) => { player.PayFee(50); Console.WriteLine("{0} pays Doctor's fee of £50", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Pay your insurance premium £50", (Player player, Board board) => { player.PayFee(50); Console.WriteLine("{0} pays insurance premium of £50", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Bank error in your favour. Collect £200", (Player player, Board board) => { player.ReceiveMoney(200); Console.WriteLine("Bank error in {0}'s favour, {0} collects £200", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Annuity matures. Collect £100", (Player player, Board board) => { player.ReceiveMoney(100); Console.WriteLine("Annuity matures. {0} collects £100", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "You inherit £100", (Player player, Board board) => { player.ReceiveMoney(100); Console.WriteLine("{0} inherits £100!", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "From sale of stock you get £50", (Player player, Board board) => { player.ReceiveMoney(50); Console.WriteLine("{0} receives sale of stock for £50!", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Receive interest on 7% preference shares: £25", (Player player, Board board) => { player.ReceiveMoney(25); Console.WriteLine("{0} receives interest of £25!", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Income tax refund. Collect £20", (Player player, Board board) => { player.ReceiveMoney(20); Console.WriteLine("Income Tax Refund. {0} collects £20", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "You have won second prize in a beauty contest. Collect £10", (Player player, Board board) => { player.ReceiveMoney(10); Console.WriteLine("{0} wins £10 from a beauty contest!", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "It is your birthday. Collect £10 from each player", (Player player, Board board) => 
            {
                foreach (var opponents in board.Players)
                {
                    opponents.PayFee(10);
                    player.ReceiveMoney(10);
                }
                    
                Console.WriteLine("{0} receives £10 from each player.", player.Name);
            }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Get out of jail free. This card may be kept until needed or sold", (Player player, Board board) => { player.ReceiveGetOutOfJailCard(); Console.WriteLine("{0} Recieves a Get Out Of Jail Free Card!", player.Name); }));
            communityChestCards.Add(new ChanceOrCommunityChestCard(CardType.CommunityChest, "Pay a £10 fine or take a Chance", (Player player, Board board) => Console.WriteLine("todo")));

            return communityChestCards;
        }
    }
}
