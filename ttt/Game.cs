namespace ttt;

public class Game
{
    private readonly Analyser _boardAnalyser;
    private readonly Player _playerTurn;

    public Game(Analyser boardAnalyser, Player playerTurn)
    {
        _boardAnalyser = boardAnalyser;
        if (playerTurn == Player.N)
        {
            throw new ArgumentException("Turn cannot be N");
        }
        _playerTurn = playerTurn;
    }

    public Player Turn => _playerTurn;
}