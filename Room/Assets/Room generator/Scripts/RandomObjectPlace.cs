using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPlace : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefubs = new();
    private GameObject _instance;

    public GameObject Instance => _instance;

    protected void Awake()
    {
        GenerateObject();
    }

    public void GenerateObject()
    {
        GameObject prefab = _prefubs.RandomElemet();
        GenerateObject(prefab);
    }

    public void GenerateObject(GameObject prefab)
    {
        DestroyInstance();

        if (prefab)
        {
            _instance = Instantiate(prefab, transform);
        }
    }

    public void DestroyInstance()
    {
        if (_instance)
        {
            Destroy(_instance.gameObject);
        }
    }
}
