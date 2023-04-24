using UnityEngine;

public class RandomObjectPlace : MonoBehaviour
{
    [SerializeField] private RoomObjectsList _prefabs;
    [SerializeField] private RoomFurnitureList _roomFurnitureList;
    [SerializeField] private Furniture _instance;

    public Furniture Instance => _instance;
    public RoomFurnitureList FurnitureList => _roomFurnitureList;

    protected void Awake()
    {
        SetParentRoom();
		GenerateObject();
    }

    private void SetParentRoom()
    {
        RoomFurnitureList list = transform.GetComponentInParent<RoomFurnitureList>();
		if (list != null)
        {
            _roomFurnitureList = list;
            return;
        }

        RandomObjectPlace parentPlace = transform.GetComponentInParent<RandomObjectPlace>();
        if (parentPlace != null)
        {
            parentPlace.SetParentRoom();
            _roomFurnitureList = parentPlace.FurnitureList;
        }
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

#if UNITY_EDITOR

    private void OnValidate()
	{
        SetParentRoom();
	}
#endif
}
