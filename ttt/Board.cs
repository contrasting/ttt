namespace ttt;

public class Board
{
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
    private readonly Player[,] _board;

    public Board()
    {
        _board = new Player[3, 3];
    }

    private Board(Player[,] board)
    {
        _board = board;
    }

    public void Write(Position pos, Player player)
    {
        _board[pos.X, pos.Y] = player;
    }

    public Player Read(Position position)
    {
        return _board[position.X, position.Y];
    }

    public void Print()
    {
        // remember print from top row to bottom row
        for (int y = 2; y >= 0; y--)
        {
            Console.Write($"{y + 1} | ");
            for (int x = 0; x < 3; x++)
            {
                Console.Write(_board[x, y].Pretty());
            }

            Console.Write("\n");
        }
        Console.WriteLine("    ---\n    ABC");
    }

    public Board Copy()
    {
        // !!! copy array
        return new Board((Player[,])_board.Clone());
    }
}