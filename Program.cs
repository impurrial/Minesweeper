using System;
using TestProject;

public class Program
{
    static void Main()
    {   
       Game game = new Game();
       Console.WriteLine("Choose the size of your board)");
       int x = Convert.ToInt32(Console.ReadLine());
       Console.WriteLine("Choose the number of mines)");
       int y = Convert.ToInt32(Console.ReadLine());
       game.Run(x,y);
       while(!game.gameOver() && !game.board.gameWon)
       {
           game.Move();
           game.board.allNonMinesRevealed();
       }

       if (game.gameOver())
       {
           game.board.RevealAllCells();
           game.board.PrintBoard();
           Console.WriteLine("You detonated a mine! Game over!");
       }
       else if(game.board.gameWon)
           game.board.PrintBoard();
           Console.WriteLine("You won!");
    }
    
    
}