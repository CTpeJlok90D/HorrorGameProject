using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interacteble : MonoBehaviour
{
    [SerializeField] private UnityEvent<InteractInfo> _onInteract;

    public UnityEvent<InteractInfo> OnInteract => _onInteract;

    public void Interact(InteractInfo info)
    {
        _onInteract.Invoke(info);
    }
}


public struct InteractInfo
{
    public Container Inventory;
}