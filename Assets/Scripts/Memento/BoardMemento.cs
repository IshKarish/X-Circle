public class BoardMemento
{
    public Player[,] State { get; }
    public Player CurrentPlayer { get; }

    public BoardMemento(Player[,] state, Player currentPlayer)
    {
        State = (Player[,])state.Clone();
        CurrentPlayer = currentPlayer;
    }
}