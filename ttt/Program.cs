// See https://aka.ms/new-console-template for more information

using ttt;

Console.WriteLine("Welcome to TTT");

// TODO
var humanPlayer = Player.X;

var board = new Board();
var analyser = new Analyser(board);
var game = new Game(analyser, humanPlayer);
var input = new Input();

var move = input.Read();

if (analyser.IsValidMove(move))
{
    board.Write(move, humanPlayer);
}

board.Print();