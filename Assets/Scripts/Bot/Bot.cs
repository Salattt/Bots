using System;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField]private BotMover _mover;
    [SerializeField]private Collector _collector;

    private MapResource _targetResource;

    public event Action<Bot> ResourceDelivered;
    public event Action<Bot> ResourceCollected;

    public Resource Resource { get; private set; }
    public Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
    }

    private void OnEnable()
    {
        _collector.ResourceCollected += OnResourceCollected;
    }

    private void OnDisable()
    {
        _collector.ResourceCollected -= OnResourceCollected;
    }

    public void Startup(Resource resource)
    {
        Resource = resource;

        ResourceDelivered?.Invoke(this);
    }

    public void SetupTargetResource(MapResource target)
    {
        _targetResource = target;

        _mover.SetupTarget(_targetResource.Transform.position);
        _collector.SetupResource(_targetResource);

        _targetResource.TransferedToWarehouse += OnResourceTransfered;
    }

    public void MoveToPoint(Vector3 point)
    {
        _mover.SetupTarget(point);
    }

    private void OnResourceCollected()
    {
        _mover.Stop();

        ResourceCollected?.Invoke(this);
    }

    private void OnResourceTransfered()
    {
        _mover.Stop();

        _targetResource.TransferedToWarehouse -= OnResourceTransfered;

        ResourceDelivered?.Invoke(this);
    }
}
