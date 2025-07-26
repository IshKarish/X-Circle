using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player CurrentPlayer;

    private void Awake()
    {
        Instance = this;
        CurrentPlayer = Player.Erez;
    }

    public Player SwitchTurn()
    {
        CurrentPlayer = CurrentPlayer == Player.Erez ? Player.Yakir : Player.Erez;
        return CurrentPlayer;
    }

    public string EndGame(Player winner)
    {
        string endMsg = winner == Player.None ? "It's a tie lol" : $"The winner is {winner} holy shit";
        Debug.Log(endMsg);
        return endMsg;
    }
}