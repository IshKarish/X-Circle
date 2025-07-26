using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private View View;
    private Model _model;
    private MementoManager _mementoManager;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;

        _mementoManager = new MementoManager();
        _model = new Model();
        
        _mementoManager.Record(_model.Save(_gameManager.CurrentPlayer));
        
        View.Init(OnCellClicked);
        View.UpdateCurrentPlayerImage(_gameManager.CurrentPlayer);

        _model.OnBoardUpdate += UpdateView;
    }

    private void OnCellClicked(int row, int col)
    {
        if (!_gameManager) return;
        
        Player player = _gameManager.CurrentPlayer;
        _mementoManager.Record(_model.Save(player));
        _model.SetSymbol(row, col, player);

        if (_model.GameOver(out player))
        {
            View.ShowEndGamePanel(_gameManager.EndGame(player), player);
        }
    }

    private void UpdateView()
    {
        View.RenderBoard(_model);
        View.UpdateCurrentPlayerImage(_gameManager.SwitchTurn());
    }

    public void Undo()
    {
        BoardMemento memento = _mementoManager.Undo(_model.Save(_gameManager.CurrentPlayer));
        _model.Restore(memento);

        _gameManager.CurrentPlayer = memento.CurrentPlayer;
        View.UpdateCurrentPlayerImage(_gameManager.CurrentPlayer);
    }

    public void Redo()
    {
        BoardMemento memento = _mementoManager.Redo(_model.Save(_gameManager.CurrentPlayer));
        _model.Restore(memento);

        _gameManager.CurrentPlayer = memento.CurrentPlayer;
        View.UpdateCurrentPlayerImage(_gameManager.CurrentPlayer);
    }

    public void ResetGame()
    {
        _model.Reset();
        View.ResetBoard();
        _mementoManager.Clear();
        _mementoManager.Record(_model.Save(_gameManager.CurrentPlayer));
    }
}
