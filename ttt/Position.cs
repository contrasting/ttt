namespace ttt;

public class Position
{
    private readonly int _x, _y;

    // https://stackoverflow.com/questions/4009013/call-one-constructor-from-another
    public Position(string stringRepresentation) : this(stringRepresentation[0] - 'A', stringRepresentation[1] - '1')
    {
    }

    public Position(int x, int y)
    {
        if (x < 0 || x > 2 || y < 0 || y > 2)
        {
            throw new ArgumentException("Position out of range");
        }

        _x = x;
        _y = y;
    }

    public int X => _x;
    public int Y => _y;
}