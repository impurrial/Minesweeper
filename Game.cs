namespace TestProject;

public class Game
{
    public Board board;

    public void Run(int x, int y)
    {
        Console.WriteLine("Game has started");
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                Console.Write("X  ");
            }

            Console.WriteLine("");
        }
        Console.WriteLine("Choose the x coordinate to alter (starting with 1)");
        int b = (Convert.ToInt32(Console.ReadLine()) -1 );
        Console.WriteLine("Choose the y coordinate to alter (starting with 1)");
        int a = (Convert.ToInt32(Console.ReadLine()) -1 );
        board = new Board(x, y, a, b);
        Console.WriteLine("It's your first move, so it'd be silly to make a flag!. Type 1 to reveal.");
        int action = Convert.ToInt32(Console.ReadLine());
        if(action == 1)
        {
            board.RevealCell(a,b);
        }
        else 
        {
            while (action != 1)
            {
                Console.WriteLine(":( It won't work until you type 1)");
                action = Convert.ToInt32(Console.ReadLine());
                if(action == 1)
                {
                    board.RevealCell(a,b); 
                }
            }
        }

        

    }

    public bool gameOver()
    {
        return board.clickedMine;
    }
    public void Move()
    {
        board.PrintBoard();
        Console.WriteLine("Choose the x coordinate to alter (starting with 1)");
        int y = (Convert.ToInt32(Console.ReadLine()) -1 );
        Console.WriteLine("Choose the y coordinate to alter (starting with 1)");
        int x = (Convert.ToInt32(Console.ReadLine()) -1 );
        Console.WriteLine("Choose the action to perform: 1. Reveal 2. Flag");
        int action = Convert.ToInt32(Console.ReadLine());
        if(action == 1)
        {
            board.RevealCell(x,y);
        }
        else if(action == 2)
        {
            board.ToggleFlag(x,y);
        }

        Console.WriteLine("");

    }
    
    
    
    
    


}
