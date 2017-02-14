using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dice die = new Dice();
            BoardBuilder boardBuilder = new BoardBuilder();
            Board board = new Board(boardBuilder, die, new Player[] { new Player("Bob"), new Player("Nick"), new Player("Barry"), new Player("Fred") });
            BoardGame boardGame = new BoardGame(board);

            boardGame.PlayGame();

            Console.WriteLine("finished");
            Console.Read();
        }
    }
}
