using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
internal struct Cell
{
    public Button Button;
    public Image Image;
}

public class View : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private Cell[] _cells = new Cell[9];
    [SerializeField] private Image CurrentPlayerImage;

    [Header("Players")] 
    [SerializeField] private Sprite Erez;
    [SerializeField] private Sprite Yakir;

    [Header("Game over stuff")]
    [SerializeField] private GameObject EndGamePanel;
    [SerializeField] private TextMeshProUGUI WinnerText;
    [SerializeField] private Image WinnerImage;

    public void Init(System.Action<int, int> onCellClicked)
    {
        EndGamePanel.SetActive(false);
        
        for (int i = 0; i < _cells.Length; i++)
        {
            int row = i / 3;
            int col = i % 3;
            
            _cells[i].Button.onClick.AddListener(() => onCellClicked(row, col));
            _cells[i].Image.sprite = null;
            _cells[i].Image.enabled = false;
        }
    }
    
    public void RenderBoard(Model model)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                int index = row * 3 + col;
                Player player = model.Board[row, col];

                _cells[index].Button.interactable = (player == Player.None);
                _cells[index].Image.enabled = (player != Player.None);
                _cells[index].Image.sprite = player == Player.Erez ? Erez : Yakir;
            }
        }
    }

    public void UpdateCurrentPlayerImage(Player player)
    {
        CurrentPlayerImage.sprite = player == Player.Erez ? Erez : Yakir;
    }

    public void ShowEndGamePanel(string endMsg, Player player)
    {
        EndGamePanel.SetActive(true);
        WinnerText.text = endMsg;

        WinnerImage.enabled = player != Player.None;
        WinnerImage.sprite = (player == Player.Erez) ? Erez : Yakir;
    }

    public void ResetBoard()
    {
        if (EndGamePanel.activeSelf) EndGamePanel.SetActive(false);
    }
}
