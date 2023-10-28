namespace ttt;

public class Game
{
    private readonly Board _board;
    private readonly Player _playerTurn;

    public Game(Board board, Player playerTurn)
    {
        _board = board;
        if (playerTurn == Player.N)
        {
            throw new ArgumentException("Turn cannot be N");
        }
        _playerTurn = playerTurn;
    }

    public Player Turn => _playerTurn;
    
    public Player GetWinner()
    {
        // columns
        for (int x = 0; x < 3; x++)
        {
            var a = _board.Read(new Position(x, 0));
            var b = _board.Read(new Position(x, 1));
            var c = _board.Read(new Position(x, 2));
            if (a == b && b == c && a != Player.N) return a;
        }
        
        // rows
        for (int y = 0; y < 3; y++)
        {
            var a = _board.Read(new Position(0, y));
            var b = _board.Read(new Position(1, y));
            var c = _board.Read(new Position(2, y));
            if (a == b && b == c && a != Player.N) return a;
        }
        
        // diagonals
        var a1 = _board.Read(new Position("A1"));
        var b2 = _board.Read(new Position("B2"));
        var c3 = _board.Read(new Position("C3"));
        var a3 = _board.Read(new Position("A3"));
        var c1 = _board.Read(new Position("C1"));

        if (a1 == b2 && b2 == c3 && a1 != Player.N)
        {
            return a1;
        }

        if (a3 == b2 && b2 == c1 && a3 != Player.N)
        {
            return a3;
        }

        return Player.N;
    }
}