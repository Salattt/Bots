using System.Collections.Generic;
using UnityEngine;

public class MapResourcePool : MonoBehaviour
{
    [SerializeField] private List<MapResource> _possibleMapResources;

    private List<MapResource> _mapResources = new List<MapResource>();

    public MapResource GetResource()
    {
        if (_mapResources.Count == 0)
            return InstantiateMapResource();

        MapResource mapResource = _mapResources[0];

        mapResource.enabled = true;

        mapResource.Destroyed += Release;

        return mapResource;
    }

    private MapResource InstantiateMapResource()
    {
        return Instantiate(_possibleMapResources[Random.Range(0, _possibleMapResources.Count)]);
    }

    private void Release(MapResource mapResource)
    {
        mapResource.Destroyed -= Release;

        mapResource.enabled=false;
    }
}
