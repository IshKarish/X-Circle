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
}
