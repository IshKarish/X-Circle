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
    [SerializeField] private Cell[] _cells = new Cell[9];
    [SerializeField] private Image CurrentPlayerImage;

    [Header("Players")] 
    [SerializeField] private Sprite Erez;
    [SerializeField] private Sprite Yakir;

    public void Init(System.Action<int, int> onCellClicked)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            int row = i / 3;
            int col = i % 3;
            
            _cells[i].Button.onClick.AddListener(() => onCellClicked(row, col));
            _cells[i].Image.sprite = null;
            _cells[i].Image.enabled = false;
        }
    }

    public void SetCell(int row, int col, Player player)
    {
        int index = row * 3 + col;
        
        _cells[index].Button.interactable = false;
        _cells[index].Image.enabled = true;
        _cells[index].Image.sprite = player == Player.Erez ? Erez : Yakir;
    }

    public void UpdateCurrentPlayerImage(Player player)
    {
        CurrentPlayerImage.sprite = player == Player.Erez ? Erez : Yakir;
    }

    public void Reset()
    {
        foreach (Cell cell in _cells)
        {
            cell.Image.sprite = null;
            cell.Image.enabled = false;
            cell.Button.interactable = true;
        }
    }
}
