using System.Collections.Generic;
using UnityEngine;

public abstract class Furniture : MonoBehaviour
{
    [Header(nameof(Furniture))]
    [SerializeField] private List<Furniture> subFurnitures;

    protected abstract Furniture OnInit(RoomFurnitureList roomFurnitureList);

    public Furniture Init(RoomFurnitureList roomFurnitureList)
    {
        OnInit(roomFurnitureList);
        foreach (Furniture furniture in subFurnitures)
        {
            furniture.Init(roomFurnitureList);
        }
        return this;
    }
}
