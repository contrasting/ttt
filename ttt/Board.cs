namespace ttt;

public class Board
{
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
    private readonly Value[,] _board = new Value[3, 3];

    public void Write(Position p, Value v)
    {
        // TODO check position is empty?
        _board[p.XAxisIndex, p.YAxisIndex] = v;
    }

    public Value Read(Position position)
    {
        return _board[position.XAxisIndex, position.YAxisIndex];
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