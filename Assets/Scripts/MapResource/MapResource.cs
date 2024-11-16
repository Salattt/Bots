using System;
using UnityEngine;

public class MapResource : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private int _quantity;

    private Cell _cell;

    public event Action TransferedToWarehouse;
    public event Action<MapResource> Destroyed;

    public Transform Transform {  get; private set; }
    public Cell Cell => _cell.Clone();

    private void Awake()
    {
        Transform = transform;
        _cell = new Cell(_resource,_quantity);
    }

    public void Collect() 
    { 
        TransferedToWarehouse?.Invoke();
        Destroyed?.Invoke(this);
    }
}
