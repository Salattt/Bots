using UnityEngine;

[RequireComponent (typeof(SphereCollider))]
public class MapResourceTransferer : MonoBehaviour
{
    [SerializeField] private WareHouse _wareouse;

    public Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out MapResource resource))
        {
            _wareouse.AddResource(resource.Cell);
            resource.Collect();
        }
    }
}
