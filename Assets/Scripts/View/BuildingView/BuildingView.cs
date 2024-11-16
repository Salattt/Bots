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
    [SerializeField] private Building _building;

    private void OnEnable()
    {
        _building.LevelupInfoChanged += UpdateResorcesToLevelup;
        _levelupButton.onClick.AddListener(OnLevelupButtonClicked);
    }

    private void OnDisable()
    {
        _building.LevelupInfoChanged -= UpdateResorcesToLevelup;
        _levelupButton.onClick.RemoveListener(OnLevelupButtonClicked);
    }

    private void UpdateResorcesToLevelup()
    {
        foreach (Cell cell in _building.GetLevelupInfo()) 
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
        _building.TryLevelup();
    }
}
