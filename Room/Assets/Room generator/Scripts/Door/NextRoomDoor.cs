using UnityEditor;
using UnityEngine;
public class NextRoomDoor : Door
{
    [SerializeField] private RoomList _possibleRooms;
    [SerializeField] private bool _generateRoom;

    protected new void OnEnable()
    {
        base.OnEnable();
        Opened.AddListener(OnOpen);
    }

    public void OnOpen()
    {
        LockPermanently();
    }

    public Room GenerateNextRoom(Room previewRoom)
    {
        if (_generateRoom)
        {
            return Instantiate(_possibleRooms.List[Random.Range(0, _possibleRooms.List.Count)], transform.position, transform.rotation).Init(previewRoom);
        }
        return null;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(NextRoomDoor))]
public class NextRoomDoorEditor : Editor
{
    private new NextRoomDoor target => base.target as NextRoomDoor;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Interact"))
        {
            if (Application.isPlaying)
            {
                target.IsOpen = !target.IsOpen;
            }
            else
            {
                Debug.LogWarning("You can use interact button in playmode only!");
            }
        }
    }
}
#endif