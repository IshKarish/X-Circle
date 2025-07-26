using System.Linq;

public class Model
{
    public Player[,] Board = new Player[3, 3];
    public System.Action OnBoardUpdate;

    public bool SetSymbol(int x, int y, Player player)
    {
        if (Board[x, y] != Player.None) return false;
        
        Board[x, y] = player;
        OnBoardUpdate?.Invoke();
        
        return true;
    }
    
    private Player CheckWinner()
    {
        for (int row = 0; row < 3; row++)
            if (Board[row, 0] != Player.None && Board[row, 0] == Board[row, 1] && Board[row, 1] == Board[row, 2])
                return Board[row, 0];
        
        for (int col = 0; col < 3; col++)
            if (Board[0, col] != Player.None && Board[0, col] == Board[1, col] && Board[1, col] == Board[2, col])
                return Board[0, col];
        
        if (Board[0, 0] != Player.None && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            return Board[0, 0];

        
        if (Board[0, 2] != Player.None && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
            return Board[0, 2];
        
        return Player.None;
    }

    public bool GameOver(out Player winner)
    {
        winner = CheckWinner();

        return winner != Player.None || Board.Cast<Player>().All(player => player != Player.None);
    }

    public BoardMemento Save(Player currentPlayer)
    {
        return new BoardMemento(Board, currentPlayer);
    }

    public void Restore(BoardMemento memento)
    {
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                Board[row, col] = memento.State[row, col];
        
        OnBoardUpdate?.Invoke();
    }

    public void Reset()
    {
        Board = new Player[3, 3];
        OnBoardUpdate?.Invoke();
    }
}
