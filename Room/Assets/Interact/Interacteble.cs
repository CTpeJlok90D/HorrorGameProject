using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interacteble : MonoBehaviour
{
    [SerializeField] private UnityEvent _onInteract;

    public UnityEvent OnInteract => _onInteract;

    public void Interact()
    {
        _onInteract.Invoke();
    }
}
