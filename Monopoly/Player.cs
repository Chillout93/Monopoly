using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }
        public int Money { get; private set; }
        public int BoardPosition { get; set; }
        private int getOutOfJailCardCount;

        public Player(string name = "Guest")
        {
            ID = Guid.NewGuid();
            this.Name = name;
            Money = 1500;
            BoardPosition = 0;
            getOutOfJailCardCount = 0;
        }

        public void MakeOffer(IOwnable property)
        {
            property.SetPlayer(this);
            Money -= property.BuyingCost;
        }

        public void PayPlayer(Player player, int amount)
        {

        }

        public void PayFee(int sum)
        {
            Money -= sum;
        }

        public void ReceiveMoney(int sum)
        {
            Money += sum;
        }

        public void ReceiveGetOutOfJailCard()
        {
            getOutOfJailCardCount++;
        }

        public void Move(int numberOfSpaces)
        {
            if (numberOfSpaces < 0)
                throw new Exception("Number cannot be negative.");
            if (BoardPosition >= BoardPosition + numberOfSpaces % 40)
                PlayerPassedGo();
            BoardPosition += numberOfSpaces % 40;
        }

        public void MoveDirectly(int position)
        {
            // Check if passed go works for positive and negative numbers.
            if ((position >= 0) ? BoardPosition > position : BoardPosition == 0 || BoardPosition < position)
                PlayerPassedGo();

            BoardPosition = position;
        }

        public void MoveDirectlyDoNotPassGo(int position)
        {
            BoardPosition = position;
        }

        private void PlayerPassedGo()
        {
            this.Money += 200;
        }

        public void GoToJail()
        {

        }
    }
}
