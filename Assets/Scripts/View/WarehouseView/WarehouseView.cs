using System.Collections.Generic;
using UnityEngine;

public class WarehouseView : MonoBehaviour
{
    private Dictionary<Resource, CellView> _cellViews = new Dictionary<Resource, CellView>();

    [SerializeField] private Transform _content;
    [SerializeField] private CellView _cellView;
    [SerializeField] private WareHouse _warehouse;

    private void OnEnable()
    {
        _warehouse.ResourceUpdated += UpdateResorces;
    }

    private void OnDisable()
    {
        _warehouse.ResourceUpdated -= UpdateResorces;
    }

    private void UpdateResorces()
    {
        foreach (Cell cell in _warehouse.GetStoringResource())
        {
            if (_cellViews.ContainsKey(cell.Resource) == false)
            {
                _cellViews.Add(cell.Resource, Instantiate(_cellView, _content));
            }

            _cellViews[cell.Resource].SetupCell(cell);
        }
    }
}
