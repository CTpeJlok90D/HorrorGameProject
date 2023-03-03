using System.Collections.Generic;
using UnityEngine;

public class FurniturePlace : MonoBehaviour
{
    [SerializeField] private List<GameObject> _furniturePrefubs = new();
    private GameObject _instance;

    public GameObject Instance => _instance;

    protected void Awake()
    {
        GenerateObject();
    }

    public void GenerateObject()
    {
        GameObject prefab = _furniturePrefubs[Random.Range(0, _furniturePrefubs.Count)];

        if (prefab != null)
        {
            _instance = Instantiate(prefab, transform);
        }
    }
}
