namespace ttt;

public enum Player
{
    N, X, O
}

public static class PlayerExt
{
    public static Player Opponent(this Player player)
    {
        if (player == Player.N) return Player.N;
        return player == Player.O ? Player.X : Player.O;
    }

    public static string Pretty(this Player player)
    {
        switch (player)
        {
            case Player.X:
                return "X";
            case Player.O:
                return "O";
            case Player.N:
            default:
                return " ";
        }
    }
}