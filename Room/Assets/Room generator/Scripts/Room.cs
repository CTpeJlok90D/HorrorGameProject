using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] private List<NextRoomDoor> _leaveRoomDoors = new();
    [SerializeField] private List<GameObject> _light = new();
    [SerializeField] private EnterDoor _enterDoor;
    [SerializeField] private UnityEvent _playerEntered;
    [SerializeField] private UnityEvent _playerLeaved;

    private List<Room> _nextRooms = new();
    private Room _previewRoom;

    public UnityEvent PlayerEntered => _playerEntered;
    public UnityEvent PlayerLeaved => _playerLeaved;

    public List<GameObject> Light => _light;

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

    public void TurnOffLight()
    {
        FlickLight(false);
    }

    public void TurnOnLight()
    {
        FlickLight(true);
    }

    public void FlickLight(bool value)
    {
        foreach (GameObject light in _light)
        {
            light.SetActive(value);
        }
    }

    private void OnPlayerEnterRoom()
    {
        _previewRoom.RemoveAllRoomsExcept(this);
        GenerateNextRooms(this);
        _playerEntered.Invoke();
    }

    private void OnPlayerLeaveRoom()
    {
        _enterDoor?.Close();
        foreach (NextRoomDoor door in _leaveRoomDoors)
        {
            door?.Close();
            door?.LockPermanently();
        }
        _playerLeaved.Invoke();
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
