// See https://aka.ms/new-console-template for more information

using ttt;

var input = new Input();

void Play()
{
    var board = new Board();
    var analyser = new Analyser(board);
    var game = new Game(analyser, board, input);

    game.Play();
    
    Console.Write("Play again? ");
}

do
{
    Play();
} while (input.ReadBool());