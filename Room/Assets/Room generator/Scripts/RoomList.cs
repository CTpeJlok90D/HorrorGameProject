using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Room genaration/Room list")]
public class RoomList : ScriptableObject
{
    [SerializeField] private List<Room> _list;

    public List<Room> List => _list;
}
