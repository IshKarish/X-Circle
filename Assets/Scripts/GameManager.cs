using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player CurrentPlayer;

    private void Awake() => Instance = this;

    public Player SwitchTurn()
    {
        CurrentPlayer = CurrentPlayer == Player.Erez ? Player.Yakir : Player.Erez;
        return CurrentPlayer;
    }
}
