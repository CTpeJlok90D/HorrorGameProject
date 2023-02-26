using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoomList : ScriptableObject
{
    [SerializeField] private List<Room> _list;

    public List<Room> List => _list;
}
