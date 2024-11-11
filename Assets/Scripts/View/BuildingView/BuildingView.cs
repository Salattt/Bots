using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingView : MonoBehaviour
{
    private Dictionary<Resource, CellView> _cellViews = new Dictionary<Resource, CellView>();

    [SerializeField] private Button _levelupButton;
    [SerializeField] private CellView _cellView;
    [SerializeField] private Transform _content;

    public event Action LevelupRequired;

    private void OnEnable()
    {
        _levelupButton.onClick.AddListener(OnLevelupButtonClicked);
    }

    private void OnDisable()
    {
        _levelupButton.onClick.RemoveListener(OnLevelupButtonClicked);
    }

    public void UpdateResorcesToLevelup(List<Cell> resourcesToLevelup)
    {
        foreach (Cell cell in resourcesToLevelup) 
        { 
            if(_cellViews.ContainsKey(cell.Resource) == false)
            {
                _cellViews.Add(cell.Resource, Instantiate(_cellView, _content));
            }

            _cellViews[cell.Resource].SetupCell(cell);
        }
    }

    private void OnLevelupButtonClicked()
    {
        LevelupRequired?.Invoke();
    }
}
