using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _quantity;
    [SerializeField] private Image _image;

    private Cell _cell;

    public void SetupCell(Cell cell)
    {
        _image.sprite = cell.Resource.GetIcon();
        _quantity.text = cell.Quantity.ToString();
    }
}
