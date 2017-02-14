using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public enum PropertyColour
    {
        Brown,
        LightBlue,
        Pink,
        Orange,
        Red,
        Yellow,
        Green,
        DarkBlue
    }

    public class Deed : IBoardCard, IOwnable
    {
        public Player Player { get; private set; }
        public string Name { get; private set; }
        public PropertyColour PropertyColour { get; private set; }
        public int BuyingCost { get; private set; }
        public IList<int> Rent { get; private set; }
        public int RentModifier { get; private set; } // The number of houses or hotel, 0 = no houses, 4 = 4 houses, 5 = hotel
        public int HouseCost { get; private set; }
        public int HotelCost { get; set; }
        public int MortgageValue { get; private set; }
        

        public Deed(string name, PropertyColour propertyColour, int buyingCost, IList<int> rent, int houseCost, int hotelCost, int mortgageValue)
        {
            this.Name = name;
            this.PropertyColour = propertyColour; 
            this.BuyingCost = buyingCost;
            this.Rent = rent;
            this.HouseCost = houseCost;
            this.HotelCost = hotelCost;
            this.MortgageValue = mortgageValue;
        }

        public void OnLanding(Player player, Board board)
        {
            if (this.Player == null)
            {
                Console.WriteLine("1) Buy Property.");
                Console.WriteLine("2) Skip Property.");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        player.MakeOffer(this);
                        Console.WriteLine("{0} bought property {1}!", player.Name, this.ToString());
                        break;
                    case "2":
                        Console.WriteLine("{0} ignored property {1}.", player.Name, this.ToString());
                        break;
                    default:
                        Console.WriteLine("That option doesn't exist, please write the number you wish to execute.");
                        break;
                }
            }
                
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
            return Rent[RentModifier];
        }

        public override string ToString()
        {
            return string.Format("[{0}][{1}] {2}", this.BuyingCost, this.PropertyColour, this.Name);
        }
    }
}
