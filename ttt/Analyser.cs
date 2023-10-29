namespace ttt;

public class Analyser
{
    private readonly Board _board;

    public Analyser(Board board)
    {
        _board = board;
    }

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
    
    public bool IsValidMove(Position position)
    {
        return _board.Read(position) == Player.N;
    }
    
    public List<Position> GetValidMoves()
    {
        var positions = new List<Position>();
        
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                var pos = new Position(x: x, y: y);
                if (IsValidMove(pos))
                {
                    positions.Add(pos);
                }
            }
        }

        return positions;
    }
    
    public bool IsWinningMove(Player player, Position position)
    {
        if (!IsValidMove(position))
        {
            return false;
        }

        var boardCopy = _board.Copy();
        
        boardCopy.Write(position, player);

        return new Analyser(boardCopy).GetWinner() == player;
    }

    public bool HasWinningMove(Player player)
    {
        foreach (var vm in GetValidMoves())
        {
            if (IsWinningMove(player, vm))
            {
                return true;
            }
        }

        return false;
    }
    
    public float EvaluateMove(Player player, Position move)
    {
        if (!IsValidMove(move))
        {
            throw new ArgumentException("Attempting to evaluate invalid move");
        }

        if (IsWinningMove(player, move))
        {
            return 1;
        }
        
        var boardCopy = _board.Copy();
        
        boardCopy.Write(move, player);
        
        var analyser = new Analyser(boardCopy);

        if (analyser.HasWinningMove(player.Opponent()))
        {
            return -1;
        }

        // neither winning nor losing move. Continue evaluating
        var evaluations = new List<float>();

        foreach (var vm in analyser.GetValidMoves())
        {
            evaluations.Add(-1 * analyser.EvaluateMove(player.Opponent(), vm));
        }

        if (evaluations.Count == 0)
        {
            return 0;
        }

        return evaluations.Average();
    }
}