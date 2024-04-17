using TestProject;

public class Board
{
    private int height;
    private int width;
    private int minesCount;
    private Cell[,] cells;

    public Board(int size, int minesCount, int sillyX, int sillyY)
    {
        this.minesCount = minesCount;
        height = size;
        width = size;
        cells = new Cell[size, size];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                cells[i, j] = new Cell();
            }
        }

        Console.Write("", size);
        Console.Write("", cells[1, 2].hasMine);

        GenerateMines(minesCount, sillyX, sillyY);
    }

    private void GenerateMines(int mines, int sillyX, int sillyY)
    {
        Random szansa = new Random();
        for (int i = 0; i < mines; i++)
        {
            int tempHeight = szansa.Next(0, height);
            int tempWidth = szansa.Next(0, width);
            while (      (tempHeight == sillyX && tempWidth == sillyY) || (tempHeight == (sillyX-1) && tempWidth == sillyY) || 
                   (tempHeight == (sillyX+1) && tempWidth == sillyY) || (tempHeight == (sillyX) && tempWidth == (sillyY-1)) || 
                    (tempHeight == (sillyX-1) && tempWidth == (sillyY + 1))    || (tempHeight == (sillyX+1) && tempWidth == (sillyY + 1)) || 
                    (tempHeight == (sillyX-1) && tempWidth == (sillyY - 1)) || (tempHeight == (sillyX+1) && tempWidth == (sillyY - 1)) || 
                    (tempHeight == (sillyX-1) && tempWidth == (sillyY + 1)) || 
                                                                         
                   hasMine(tempHeight, tempWidth))
            {
                tempHeight = szansa.Next(0, height);
                tempWidth = szansa.Next(0, width);
            }

            setMine(tempHeight, tempWidth);
        }
    }

    public bool gameWon = false;

    public void allNonMinesRevealed()
    {
        int nonMinesRevealed = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (!cells[i, j].hasMine && cells[i, j].isRevealed)
                {
                    nonMinesRevealed++;
                }
            }
        }

        if (nonMinesRevealed == (width * height) - minesCount)
        {
            gameWon = true;
        }
    }

    public void RevealAllCells()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                cells[i, j].isRevealed = true;
            }
        }
    }

    /* private void BigReveal()
     {

     }
     */


    public void RevealCell(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            if (!cells[x, y].hasMine && !cells[x, y].isRevealed)
            {
                cells[x, y].isRevealed = true;
                int mineCounter = GetMinesAround(x, y);
                if (mineCounter == 0)
                {
                    RevealCell(x - 1, y);
                    RevealCell(x + 1, y);
                    RevealCell(x, y - 1);
                    RevealCell(x, y + 1);
                }
            }
        }
    }

    public void ToggleFlag(int x, int y)
    {
        if (cells[x, y].hasFlag)
        {
            cells[x, y].hasFlag = false;
        }
        else
            cells[x, y].hasFlag = true;
    }

    public bool hasFlag(int x, int y)
    {
        return cells[x, y].hasFlag;
    }

    public bool hasMine(int x, int y)
    {
        return cells[x, y].hasMine;
    }

    public bool isRevealed(int x, int y)
    {
        return cells[x, y].isRevealed;
    }

    public bool clickedMine = false;

    private int GetMinesAround(int x, int y)
    {
        int minesNext = 0;
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int nx = x + dx;
                int ny = y + dy;
                if (nx >= 0 && nx < width && ny >= 0 && ny < height && hasMine(nx, ny))
                {
                    minesNext++;
                }
            }
        }

        return minesNext;
    }

    public void PrintBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if ((cells[i, j].isRevealed) && (cells[i, j].hasMine))
                {
                    Console.Write("M  ");
                }
                else if ((cells[i, j].isRevealed) && (!cells[i, j].hasMine))
                {
                    int minesNext = GetMinesAround(i, j);
                    Console.Write(minesNext + "  ");
                }
                else if ((!cells[i, j].isRevealed) && (cells[i, j].hasFlag))
                {
                    Console.Write("F  ");
                }
                else
                {
                    Console.Write("X  ");
                }
            }

            Console.WriteLine("");
        }
    }

    private void setMine(int x, int y)
    {
        cells[x, y].hasMine = true;
    }
}

public class Cell
{
    public Cell()
    {
        hasMine = false;
        hasFlag = false;
        isRevealed = false;
    }

    public bool hasMine = false;
    public bool hasFlag = false;
    public bool isRevealed = false;
}