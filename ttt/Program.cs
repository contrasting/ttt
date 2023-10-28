// See https://aka.ms/new-console-template for more information

using ttt;

var board = new Board();

board.Write(new Position("C1"), Player.O);
board.Write(new Position("A1"), Player.O);
board.Write(new Position("B1"), Player.O);

board.Print();

Console.WriteLine(new Game(board, playerTurn: Player.O).GetWinner());