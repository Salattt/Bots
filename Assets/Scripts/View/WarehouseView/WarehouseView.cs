using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseView : MonoBehaviour
{
    private Dictionary<Resource, CellView> _cellViews = new Dictionary<Resource, CellView>();

    [SerializeField] private Transform _content;
    [SerializeField] private CellView _cellView;

    public void UpdateResorces(List<Cell> resourcesToLevelup)
    {
        foreach (Cell cell in resourcesToLevelup)
        {
            if (_cellViews.ContainsKey(cell.Resource) == false)
            {
                _cellViews.Add(cell.Resource, Instantiate(_cellView, _content));
            }

            _cellViews[cell.Resource].SetupCell(cell);
        }
    }
}
