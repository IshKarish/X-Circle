public class Model
{
    public readonly Player[,] Board = new Player[3, 3];
    public System.Action OnBoardUpdate;

    public bool SetSymbol(int x, int y, Player player)
    {
        if (Board[x, y] != Player.None) return false;
        
        Board[x, y] = player;
        OnBoardUpdate?.Invoke();
        return true;
    }
}
