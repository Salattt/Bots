using System.Collections.Generic;
using UnityEngine;

public abstract class Building<T> : MonoBehaviour where T : BuildingView
{
    [SerializeField] private List<Resource> _resourcesToLevelup;

    private List<Cell> _cellsToLevelup;

    [SerializeField] protected T View;
    [SerializeField] private float resourcesToLevelupMultiplier;
    [SerializeField] private Wareouse _warehouse;
    [SerializeField] private int _resourcesToLevelupQuantity;

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
        View.LevelupRequired += TryLevelup;

        UpdateLevelupView();
    }

    private void OnDisable()
    {
        View.LevelupRequired -= TryLevelup;
    }

    protected abstract void OnLevelup();

    protected virtual bool IsLevelupPossible()
    {
        return true; 
    }

    private void TryLevelup()
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

                UpdateLevelupView();
            }
        }
    }

    private void UpdateLevelupView()
    {
        List<Cell> resourcesToLevelup = new List<Cell>();

        foreach (Cell cell in _cellsToLevelup)  
        {
            resourcesToLevelup.Add(cell.Clone());
        }

        View.UpdateResorcesToLevelup(resourcesToLevelup);
    }
}
