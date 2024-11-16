using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [SerializeField] private List<Resource> _resourcesToLevelup;

    [SerializeField] private float resourcesToLevelupMultiplier;
    [SerializeField] private WareHouse _warehouse;
    [SerializeField] private int _resourcesToLevelupQuantity;

    private List<Cell> _cellsToLevelup;

    public event Action LevelupInfoChanged;

    protected virtual void Awake()
    {
        _cellsToLevelup = new List<Cell>();

        foreach(Resource resource in _resourcesToLevelup)
        {
            _cellsToLevelup.Add(new Cell(resource, _resourcesToLevelupQuantity));
        }
    }

    private void OnEnable()
    {
        LevelupInfoChanged?.Invoke();
    }

    public void TryLevelup()
    {
        if (IsLevelupPossible())
        {
            if (_warehouse.TryGetResources(_cellsToLevelup))
            {
                foreach (Cell cell in _cellsToLevelup)
                {
                    cell.Multiplie(resourcesToLevelupMultiplier);
                }

                OnLevelup();

                LevelupInfoChanged?.Invoke();
            }
        }
    }

    public List<Cell> GetLevelupInfo()
    {
        List<Cell> resourcesToLevelup = new List<Cell>();

        foreach (Cell cell in _cellsToLevelup)  
        {
            resourcesToLevelup.Add(cell.Clone());
        }

        return resourcesToLevelup;
    }

    protected abstract void OnLevelup();

    protected virtual bool IsLevelupPossible()
    {
        return true; 
    }
}
