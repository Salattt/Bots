using System;
using UnityEngine;

public class BotBuilding : Building
{
    [SerializeField] private int _botsPerUpgrade;
    [SerializeField] private int _startingBots;
    [SerializeField] private BotSpawner _spawner;

    public event Action BotQuantityChanged;

    public int MaxBots { get;private set; }
    public int CurrentBots {  get; private set; }

    [field:SerializeField] public Resource CollectingResource { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        if (_startingBots > _botsPerUpgrade)
            throw new ArgumentOutOfRangeException(nameof(_startingBots));

        MaxBots = _botsPerUpgrade;
        CurrentBots = _startingBots;
    }

    private void Start()
    {
        _spawner.SetupResource(CollectingResource);

        for (int i = 0; i < _startingBots; i++)
        {
            _spawner.Spawn();
        }

        BotQuantityChanged?.Invoke();
    }

    public void Upgrade()
    {
        MaxBots += _botsPerUpgrade;

        BotQuantityChanged?.Invoke();
    }

    protected override bool IsLevelupPossible() => CurrentBots < MaxBots;

    protected override void OnLevelup()
    {
        _spawner.Spawn();

        CurrentBots++;

        BotQuantityChanged?.Invoke();
    }
}
