using System;
using UnityEngine;

public class BotBuilding : Building<BotBuildingView>
{
    [SerializeField] private int _botsPerUpgrade;
    [SerializeField] private int _startingBots;
    [SerializeField] private BotSpawner _spawner;
    [SerializeField] private Resource _collectingResource;

    private int _maxBots;
    private int _currentBots;

    protected override void Awake()
    {
        base.Awake();

        if (_startingBots > _botsPerUpgrade)
            throw new ArgumentOutOfRangeException(nameof(_startingBots));

        _maxBots = _botsPerUpgrade;
        _currentBots = _startingBots;
    }

    private void Start()
    {
        _spawner.SetupResource(_collectingResource);

        for (int i = 0; i < _startingBots; i++)
        {
            _spawner.Spawn();
        }

        UpdateBotQuantity();
        View.SetupResource(_collectingResource);
    }

    public void Upgrade()
    {
        _maxBots += _botsPerUpgrade;

        UpdateBotQuantity();
    }

    protected override bool IsLevelupPossible()
    {
        if (_currentBots < _maxBots)
            return true;

        return false;
    }

    protected override void OnLevelup()
    {
        _spawner.Spawn();

        _currentBots++;

        UpdateBotQuantity();
    }

    private void UpdateBotQuantity()
    {
        View.UpdateBotQuantity(_maxBots, _currentBots);
    }
}
