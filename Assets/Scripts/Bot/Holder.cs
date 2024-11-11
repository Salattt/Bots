using UnityEngine;

public class Holder : MonoBehaviour
{
    [SerializeField] private float _scaleMultiplier;

    private Transform _transform;
    private MapResource _resource;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if(_resource != null)
        {
            _resource.Transform.position = _transform.position;
            _resource.Transform.rotation = _transform.rotation;
        }
    }

    public void SetupResource(MapResource resource)
    {
        _resource = resource;

        _resource.Transform.localScale *= _scaleMultiplier;
    }
}
