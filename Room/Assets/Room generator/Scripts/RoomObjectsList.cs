using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Room genaration/Furniture list")]
public class RoomObjectsList : ScriptableObject
{
    [SerializeField] private List<Furniture> _furnitures;

    public List<Furniture> Furnitures => new(_furnitures);
}
