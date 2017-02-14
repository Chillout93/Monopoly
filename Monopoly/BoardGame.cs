using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class BoardGame
    {
        private Board board;

        public BoardGame(Board board)
        {
            this.board = board;
        }

        public void PlayGame()
        {
            while (true)
            {
                for (int i = 0; i < board.Players.Count; i++)
                {
                    int spacesToMove = board.Dice.RollBoth();
                    board.Players[i].Move(spacesToMove);
                    Console.WriteLine("{0} moves {1} spaces.", board.Players[i].Name, spacesToMove);
                    IBoardCard boardCard = board.GetBoardCard(board.Players[i].BoardPosition);
                    Console.WriteLine("{0} lands on {1}.", board.Players[i].Name, boardCard.ToString());
                    boardCard.OnLanding(board.Players[i], board);
                }
            }
        }
    }
}
