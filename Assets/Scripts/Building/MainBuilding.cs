using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : Building
{
    [SerializeField] private List<BotBuilding> _botBuildings;

    protected override void OnLevelup()
    {
        foreach (BotBuilding botBuilding in _botBuildings)
        {
            botBuilding.Upgrade();
        }
    }
}
