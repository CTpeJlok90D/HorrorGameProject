using System.Collections.Generic;
using UnityEngine;

public class RoomEventGenerator : MonoBehaviour
{
    [SerializeField] private Room _room;
    [SerializeField] private List<RoomEvent> _possibleEvents;
    [SerializeField] private int _requestEventCount;

    private List<RoomEvent> _currentEvents = new();

    private void Awake()
    {
        while (_currentEvents.Count < _requestEventCount)
        {
            _currentEvents.Add(_possibleEvents.RandomElemet());
        }
    }

    private void OnEnable()
    {
        foreach (RoomEvent @event in _currentEvents)
        {
            _room.PlayerEntered.AddListener(@event.OnPlayerEnter);
            _room.PlayerLeaved.AddListener(@event.OnPlayerLeave);
        }
    }

    private void OnDisable()
    {
        foreach (RoomEvent @event in _currentEvents)
        {
            _room.PlayerEntered.RemoveListener(@event.OnPlayerEnter);
            _room.PlayerLeaved.RemoveListener(@event.OnPlayerLeave);
        }
    }

    private void OnValidate()
    {
        if (_requestEventCount < _possibleEvents.Count)
        {
            _requestEventCount = _possibleEvents.Count;
        }
    }
}
