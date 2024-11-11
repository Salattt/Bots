using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
    private Dictionary<Resource, List<MapResource>> _resources = new Dictionary<Resource, List<MapResource>>();

    public void Add(MapResource mapResource)
    {
        if(_resources.ContainsKey(mapResource.Cell.Resource) == false)
            _resources.Add(mapResource.Cell.Resource, new List<MapResource>());

        _resources[mapResource.Cell.Resource].Add(mapResource);
    }

    public bool TryGetClosest(Resource resource, Vector3 position, out MapResource mapResource)
    {
        mapResource = null;

        if(_resources.ContainsKey(resource) == false)
            return false;

        if (_resources[resource].Count == 0)
            return false;

        mapResource = GetClosest(_resources[resource], position);

        return true;
    }

    private MapResource GetClosest(List<MapResource> list, Vector3 position)
    {
        MapResource closestResource = list[0];

        foreach (MapResource resource in list) 
        {
            if((resource.Transform.position - position).magnitude < (closestResource.Transform.position - position).magnitude)
                closestResource = resource;
        }

        list.Remove(closestResource);

        return closestResource;
    }
}
