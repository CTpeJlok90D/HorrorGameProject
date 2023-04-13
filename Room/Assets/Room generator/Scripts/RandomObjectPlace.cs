using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPlace : MonoBehaviour
{
    [SerializeField] private RoomObjectsList _prefabs;
    [SerializeField] private RoomFurnitureList _roomFurnitureList;

    private Furniture _instance;

    public Furniture Instance => _instance;

    protected void Awake()
    {
        GenerateObject();
    }

    public Furniture GenerateObject()
    {
        Furniture prefab = _prefabs.Furnitures.RandomElemet();
        return GenerateObject(prefab);
    }

    public Furniture GenerateObject(Furniture prefab)
    {
        DestroyInstance();

        if (prefab != null)
        {
            _instance = Instantiate(prefab, transform).Init(_roomFurnitureList);
        }
        return _instance;
    }

    public void DestroyInstance()
    {
        if (_instance)
        {
            Destroy(_instance.gameObject);
        }
    }
}
