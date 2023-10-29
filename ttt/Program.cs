// See https://aka.ms/new-console-template for more information

using ttt;

Console.WriteLine("Welcome to TTT");

// TODO
var humanPlayer = Player.X;
var computerPlayer = Player.O;

var board = new Board();
var analyser = new Analyser(board);
var game = new Game(analyser, humanPlayer);
var input = new Input();

void HumanPlayerMove()
{
    var move = input.Read();
    if (analyser.IsValidMove(move))
    {
        board.Write(move, humanPlayer);
    }
    else
    {
        Console.WriteLine("Invalid move, try again.");
        HumanPlayerMove();
    }
}

void ComputerPlayerMove()
{
    foreach (var vm in analyser.GetValidMoves()) {
        if (analyser.IsWinningMove(computerPlayer, vm))
        {
            Console.WriteLine($"Computer plays {vm.Pretty()}");
            board.Write(vm, computerPlayer);
            return;
        }
    }
    // TODO no winning moves, just play whatever
    foreach (var vm in analyser.GetValidMoves())
    {
        Console.WriteLine($"Computer plays {vm.Pretty()}");
        board.Write(vm, computerPlayer);
        return;
    }
}

board.Print();

while (analyser.GetWinner() == Player.N)
{
    HumanPlayerMove();
    board.Print();
    if (analyser.GetWinner() != Player.N) break;
    ComputerPlayerMove();
    board.Print();
}

Console.WriteLine($"Winner is {analyser.GetWinner()}");