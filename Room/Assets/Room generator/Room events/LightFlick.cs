using UnityEngine;

public class LightFlick : RoomEvent
{
    [SerializeField] private Room _room;
    public override void OnPlayerEnter()
    {
        _room.TurnOffLight();
    }

    public override void OnPlayerLeave()
    {
        _room.TurnOnLight();
    }
}
