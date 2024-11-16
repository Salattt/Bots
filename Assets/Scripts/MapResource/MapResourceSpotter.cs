using UnityEngine;

[RequireComponent (typeof(SphereCollider))]
public class MapResourceSpotter : MonoBehaviour
{
    [SerializeField] private ResourceHolder _resourceHolder;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out MapResource mapResource))
        {
            _resourceHolder.Add(mapResource);
        }
    }
}
