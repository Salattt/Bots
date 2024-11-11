using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotBuildingView : BuildingView
{
    [SerializeField] private TextMeshProUGUI _botQuantity;
    [SerializeField] private Image _resourceImage;
    [SerializeField] private string _separator;

    public void UpdateBotQuantity(int max, int current)
    {
        _botQuantity.text = current.ToString() + _separator + max.ToString();
    }

    public void SetupResource(Resource resource)
    {
        _resourceImage.sprite = resource.GetIcon();
    }
}
