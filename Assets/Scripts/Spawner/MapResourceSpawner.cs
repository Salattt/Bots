using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MapResourceSpawner : MonoBehaviour
{
    [SerializeField] private List<MapResource> _resources;

    [SerializeField] private int _spawnQuantity;
    [SerializeField] private ResourceHolder _holder; 

    private BoxCollider _spawnZone;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _spawnZone = GetComponent<BoxCollider>();

        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnQuantity; i++)
        {
            foreach (MapResource resource in _resources)
            {
                MapResource mapResource = Instantiate(resource, GenerateSpawnPoint(), _transform.rotation);
                _holder.Add(mapResource);
            }
        }
    }

    private Vector3 GenerateSpawnPoint()
    {
        return new Vector3(_transform.position.x + Random.Range(-_spawnZone.size.x , _spawnZone.size.x) / 2,
            _transform.position.y, _transform.position.z + Random.Range(-_spawnZone.size.z, _spawnZone.size.z) / 2);
    }
}
