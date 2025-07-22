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

        _model.OnBoardUpdate += UpdateView;
    }

    private void OnCellClicked(int row, int col)
    {
        if (!_gameManager) return;

        Player player = _gameManager.CurrentPlayer;
        _model.SetSymbol(row, col, player);
    }

    private void UpdateView()
    {
        View.RenderBoard(_model);
        View.UpdateCurrentPlayerImage(_gameManager.SwitchTurn());
    }
}
