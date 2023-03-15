using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private List<NextRoomDoor> _leaveRoomDoors = new();
    [SerializeField] private EnterDoor _enterDoor;

    private List<Room> _nextRooms = new();
    private Room _previewRoom;

    public Room Init(Room previewRoom)
    {
        _previewRoom = previewRoom;
        return this;
    }

    protected void OnEnable()
    {
        _enterDoor?.PlayerEntered.AddListener(OnPlayerEnterRoom);

        foreach (NextRoomDoor door in _leaveRoomDoors)
        {
            door?.PlayerEntered.AddListener(OnPlayerLeaveRoom);
        }
    }

    protected void OnDisable()
    {
        _enterDoor?.PlayerEntered.RemoveListener(OnPlayerEnterRoom);

        foreach (NextRoomDoor door in _leaveRoomDoors)
        {
            door?.PlayerEntered.RemoveListener(OnPlayerLeaveRoom);
        }
    }

    private void OnPlayerEnterRoom()
    {
        _previewRoom.RemoveAllRoomsExcept(this);
        GenerateNextRooms(this);
    }

    private void OnPlayerLeaveRoom()
    {
        _enterDoor?.Close();
        foreach (NextRoomDoor door in _leaveRoomDoors)
        {
            door?.Close();
            door?.LockPermanently();
        }
    }

    public void GenerateNextRooms(Room pewviewRoom)
    {
        foreach (NextRoomDoor door in _leaveRoomDoors)
        {
            _nextRooms.Add(door.GenerateNextRoom(pewviewRoom));
        }
    }

    public void RemoveAllRoomsExcept(Room exceptRoom)
    {
        foreach (Room nextRoom in _nextRooms.ToArray())
        {
            if (nextRoom != exceptRoom)
            {
                _nextRooms.Remove(nextRoom);
                Destroy(nextRoom.gameObject);
            }
        }
        if (_previewRoom != null)
        {
            Destroy(_previewRoom.gameObject);
        }
    }
}
