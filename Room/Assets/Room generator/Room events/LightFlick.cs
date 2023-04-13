using UnityEngine;

public class LightFlick : RoomEvent
{
    [SerializeField] private RoomFurnitureList _room;
    public override void OnPlayerEnter()
    {
        _room.LightIsShining = false;
    }

    public override void OnPlayerLeave()
    {
        _room.LightIsShining = true;
    }
}
