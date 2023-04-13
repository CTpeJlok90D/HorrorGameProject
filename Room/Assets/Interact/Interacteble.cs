using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interacteble : MonoBehaviour
{
    [SerializeField] private UnityEvent<InteractInfo> _onInteract;
    public bool CanInteract = true;

    public UnityEvent<InteractInfo> OnInteract => _onInteract;

    public void Interact(InteractInfo info)
    {
        if (CanInteract == false)
        {
            return;
        }
        _onInteract.Invoke(info);
    }
}


[CustomEditor(typeof(Interacteble))]
public class InteractebleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

    }
}
public struct InteractInfo
{
    public Container Inventory;
}