using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private View View;
    private Model _model;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _model = new Model();
        
        View.Init(OnCellClicked);
        View.UpdateCurrentPlayerImage(_gameManager.CurrentPlayer);
    }

    private void OnCellClicked(int row, int col)
    {
        if (!_gameManager) return;

        Player player = _gameManager.CurrentPlayer;

        if (!_model.SetSymbol(row, col, player)) return;
        View.SetCell(row, col, player);
        
        player = _gameManager.SwitchTurn();
        View.UpdateCurrentPlayerImage(player);
    }
}
