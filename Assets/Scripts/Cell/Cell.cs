using System;
using UnityEngine;

public class Cell
{
    public Cell(Resource resource, float quantity)
    {
        Resource = resource;
        Quantity = quantity;
    }

    public Resource Resource { get; private set; }
    public float Quantity { get; private set; }

    public Sprite Sprite => Resource.GetIcon();

    public void Add(float quantity)
    {
        if (quantity < 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));

        Quantity += quantity;
    }

    public void Remove(float quantity)
    {
        if (quantity < 0 || Quantity - quantity < 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));

        Quantity -= quantity;
    }

    public void Multiplie(float multplier)
    {
        if (multplier < 0)
            throw new ArgumentOutOfRangeException(nameof(multplier));

        Quantity *= multplier;
    }

    public Cell Clone()
    {
        return new Cell(Resource, Quantity);
    }
}
