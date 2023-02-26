using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class NextRoomDoor : MonoBehaviour
{
    [SerializeField] private UnityEvent<NextRoomDoor> _openEvent = new();
    [SerializeField] private UnityEvent<NextRoomDoor> _playerEntered = new();
    [SerializeField] private bool _isOpen = false;
    [SerializeField] private List<Room> _possibleRooms = new();

    private Collider _trigger;

    public UnityEvent<NextRoomDoor> OpenEvent => _openEvent;
    public UnityEvent<NextRoomDoor> PlayerEntered => _playerEntered;
    public bool IsOpen => _isOpen;
    public List<Room> PossibleRooms => new(_possibleRooms);

    private void Awake()
    {
        _trigger = GetComponent<Collider>();

        _trigger.isTrigger = true;
    }

    public void Open()
    {
        _openEvent.Invoke(this);
    }

    public void Close()
    {
        _trigger.isTrigger = false;
    }

    public Room GenerateNextRoom(Room previewRoom)
    {
        return Instantiate(_possibleRooms[Random.Range(0, _possibleRooms.Count)],transform.position, transform.rotation).Init(previewRoom);
    }

    protected void OnTriggerEnter(Collider other)
    {
        _playerEntered.Invoke(this);
    }
}
