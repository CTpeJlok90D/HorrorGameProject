using System.Collections.Generic;
using UnityEngine;

public class RoomFurnitureList : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lights = new();
    [SerializeField] private List<GameObject> _simpleFurniture = new();
    
    [SerializeField] private bool _lightIsShining = true;

    public bool LightIsShining
    {
        get
        {
            return _lightIsShining;
        }
        set
        {
            foreach (GameObject light in _lights)
            {
                light.gameObject.SetActive(value);
            }

            _lightIsShining = value;
        }
    }

    public void AddSimpleFurniture(GameObject simpleFurniture)
    {
        _simpleFurniture.Add(simpleFurniture);
    }

    public void AddLight(GameObject light)
    {
        _lights.Add(light);
    }

    public void FlickLight()
    {
        LightIsShining = !LightIsShining;
    }

    private void OnValidate()
    {
        LightIsShining = _lightIsShining;
    }
}