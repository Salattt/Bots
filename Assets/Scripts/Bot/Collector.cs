using System;
using UnityEngine;

[RequireComponent (typeof(SphereCollider))]
public class Collector : MonoBehaviour
{
    [SerializeField] private Holder _holder;

    private MapResource _resource;

    public event Action ResourceCollected;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out MapResource resource) && resource == _resource)
        {
            ResourceCollected?.Invoke();
            _holder.SetupResource(resource);
        }
    }

    public void SetupResource(MapResource resource)
    {
        _resource = resource;
    }
}
