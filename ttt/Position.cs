namespace ttt;

public class Position
{
    private readonly int[] _array = new int[2];

    public Position(string stringRepresentation)
    {
        int xAxis = stringRepresentation[0] - 'A';
        int yAxis = stringRepresentation[1] - '1';
        if (xAxis < 0 || xAxis > 2 || yAxis < 0 || yAxis > 2)
        {
            throw new ArgumentException("Position out of range");
        }

        _array[0] = xAxis;
        _array[1] = yAxis;
    }
    
    public int XAxisIndex => _array[0];
    public int YAxisIndex => _array[1];
}