using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPlaceGroup : MonoBehaviour
{
    [SerializeField] private List<RandomObjectPlace> _places;
    [SerializeField] private List<GameObject> _garantSpawnItems;

    private void Start()
    {
        
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_garantSpawnItems.Count > _places.Count)
        {
            Debug.LogWarning("You can't spawn more objects, then you have place for");
            _garantSpawnItems.RemoveAt(_garantSpawnItems.Count - 1);
        }
    }
#endif
}
