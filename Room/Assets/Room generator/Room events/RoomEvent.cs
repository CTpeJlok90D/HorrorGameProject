using UnityEngine;

public abstract class RoomEvent : MonoBehaviour
{
    public virtual void OnPlayerEnter() { }
    public virtual void OnPlayerLeave() { }
}
