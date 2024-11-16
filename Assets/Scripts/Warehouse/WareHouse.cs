using System;
using System.Collections.Generic;
using UnityEngine;

public class WareHouse : MonoBehaviour
{
    private Dictionary<Resource, Cell> _resources = new Dictionary<Resource, Cell>();

    public event Action ResourceUpdated;

    public void AddResource(Cell cell)
    {
        if (_resources.ContainsKey(cell.Resource) == false)
            _resources.Add(cell.Resource, new Cell(cell.Resource, 0));

        _resources[cell.Resource].Add(cell.Quantity);

        ResourceUpdated?.Invoke();
    }

    public bool TryGetResources(List<Cell> requestedResources)
    {
        bool isResourcesAvaible = true;

        foreach (Cell resource in requestedResources)
        {
            if(CheckResourceAvailability(resource) == false)
                isResourcesAvaible = false;
        }

        if (isResourcesAvaible)
        {
            GetResources(requestedResources);
        }

        return isResourcesAvaible;
    }

    public List<Cell> GetStoringResource()
    {
        List<Cell> resources = new List<Cell>();

        foreach (Cell resource in _resources.Values)
        {
            resources.Add(resource.Clone());
        }

        return resources;
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

        ResourceUpdated?.Invoke();
    }

    private bool CheckResourceAvailability(Cell cell)
    {
        if(_resources.ContainsKey(cell.Resource) == false)
            return false;

        if (_resources[cell.Resource].Quantity >= cell.Quantity)
            return true;

        return false;
    }
}
