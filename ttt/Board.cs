namespace ttt;

public class Board
{
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
    private readonly Player[,] _board = new Player[3, 3];

    public void Write(Position pos, Player player)
    {
        // TODO check position is empty?
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
            for (int x = 0; x < 3; x++)
            {
                Console.Write(_board[x, y]);
            }

            Console.Write("\n");
        }
    }
}