// See https://aka.ms/new-console-template for more information

using ttt;

var board = new Board();
var analyser = new Analyser(board);
var input = new Input();
var game = new Game(analyser, board, input);

game.Play();