using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotBuildingView : BuildingView
{
    [SerializeField] private TextMeshProUGUI _botQuantity;
    [SerializeField] private Image _resourceImage;
    [SerializeField] private string _separator;
    [SerializeField] private BotBuilding _botBuilding;

    private void OnEnable()
    {
        _botBuilding.BotQuantityChanged += UpdateBotQuantity;

        SetupResource(_botBuilding.CollectingResource);
    }

    private void OnDisable()
    {
        _botBuilding.BotQuantityChanged -= UpdateBotQuantity;
    }

    private void UpdateBotQuantity()
    {
        _botQuantity.text = _botBuilding.CurrentBots.ToString() + _separator + _botBuilding.MaxBots.ToString();
    }

    private void SetupResource(Resource resource)
    {
        _resourceImage.sprite = resource.GetIcon();
    }
}
