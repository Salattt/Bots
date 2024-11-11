using System.Collections.Generic;
using System;
using UnityEngine;

public class Wareouse : MonoBehaviour
{
    private Dictionary<Resource, Cell> _resources = new Dictionary<Resource, Cell>();

    [SerializeField] private WarehouseView _warehouseView;

    public void AddResource(Cell cell)
    {
        if (_resources.ContainsKey(cell.Resource) == false)
            _resources.Add(cell.Resource, new Cell(cell.Resource, 0));

        _resources[cell.Resource].Add(cell.Quantity);

        UpdateView();
    }

    public bool TryGetResources(List<Cell> requestedResources)
    {
        bool isResourcesAvaible = true;

        foreach (Cell resource in requestedResources)
        {
            if(CheckResourceQuantity(resource) == false)
                isResourcesAvaible = false;
        }

        if (isResourcesAvaible)
        {
            GetResources(requestedResources);
        }

        return isResourcesAvaible;
    }

    private void GetResources(List<Cell> requredResources)
    {
        foreach(Cell requiredResource in requredResources)
        {
            if (_resources.ContainsKey(requiredResource.Resource))
            {
                _resources[requiredResource.Resource].Remove(requiredResource.Quantity);
            }
        }

        UpdateView();
    }

    private bool CheckResourceQuantity(Cell cell)
    {
        if(_resources.ContainsKey(cell.Resource) == false)
        {
            _resources.Add(cell.Resource, new Cell (cell.Resource,0));
        }

        if (_resources[cell.Resource].Quantity >= cell.Quantity)
            return true;

        return false;
    }

    private void UpdateView()
    {
        List<Cell> resources = new List<Cell>();

        foreach (Cell cell in _resources.Values)
        {
            resources.Add(cell.Clone());
        }


        _warehouseView.UpdateResorces(resources);
    }
}
