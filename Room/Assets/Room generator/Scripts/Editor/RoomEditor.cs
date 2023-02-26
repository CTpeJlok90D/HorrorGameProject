using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Room))]
public class RoomEditor : Editor
{
    private new Room target => base.target as Room;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate next rooms"))
        {
            target.GenerateNextRooms(target);
        }
    }
}
