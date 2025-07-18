public class Model
{
    private readonly Player[,] board = new Player[3, 3];

    public bool SetSymbol(int x, int y, Player player)
    {
        if (board[x, y] != Player.None) return false;
        
        board[x, y] = player;
        return true;
    }
}
