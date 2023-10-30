namespace ttt;

public class Game
{
    private readonly Analyser _analyser;
    private readonly Board _board;
    private readonly Input _input;

    private bool _humanPlaysFirst;
    private Player _humanPlayer;
    private Player _computerPlayer;

    public Game(Analyser analyser, Board board, Input input)
    {
        _analyser = analyser;
        _board = board;
        _input = input;
    }

    private void WhoPlaysFirst()
    {
        Console.Write("Would you like to play first? ");
        _humanPlaysFirst = _input.ReadBool();
    }

    private void WhoPlaysWho()
    {
        Console.Write("Would you like to play noughts or crosses? ");
        _humanPlayer = _input.ReadPlayer();
        _computerPlayer = _humanPlayer.Opponent();
    }

    public void Play()
    {
        Console.WriteLine("Welcome to TTT");

        WhoPlaysFirst();
        WhoPlaysWho();
        
        if (!_humanPlaysFirst)
        {
            ComputerPlayerMove();
        }
        
        _board.Print();

        while (_analyser.GetWinner() == Player.N && _analyser.GetValidMoves().Count != 0)
        {
            HumanPlayerMove();
            _board.Print();
            if (_analyser.GetWinner() != Player.N || _analyser.GetValidMoves().Count == 0) break;
            ComputerPlayerMove();
            _board.Print();
        }

        Console.WriteLine($"Winner is {_analyser.GetWinner()}");
    }
    
    private void HumanPlayerMove()
    {
        var move = _input.ReadPosition();
        if (_analyser.IsValidMove(move))
        {
            _board.Write(move, _humanPlayer);
        }
        else
        {
            Console.WriteLine("Invalid move, try again.");
            HumanPlayerMove();
        }
    }

    private void ComputerPlayerMove()
    {
        var evaluations = new Dictionary<Position, float>();
        foreach (var vm in _analyser.GetValidMoves())
        {
            evaluations[vm] = _analyser.EvaluateMove(_computerPlayer, vm);
        }
        // https://stackoverflow.com/questions/10290838/how-to-get-max-value-from-dictionary
        // evaluations.Select(i => $"{i.Key.Pretty()}: {i.Value}").ToList().ForEach(Console.WriteLine);
        var bestMove = evaluations.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        Console.WriteLine($"Computer plays {bestMove.Pretty()}");
        _board.Write(bestMove, _computerPlayer);
    }
}