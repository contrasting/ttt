// See https://aka.ms/new-console-template for more information

using ttt;

var board = new Board();

board.Write(new Position("C1"), Value.O);
board.Write(new Position("A3"), Value.X);

board.Print();