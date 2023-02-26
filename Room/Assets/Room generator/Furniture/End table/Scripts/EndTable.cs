using UnityEngine;

[RequireComponent(typeof(Interacteble))]
public class EndTable : MonoBehaviour
{
    [SerializeField] private bool _isOpen;
    [SerializeField] private Animator _animator;
    private Interacteble _interacteble;

    private void Awake()
    {
        _interacteble = GetComponent<Interacteble>();
    }

    private void OnEnable()
    {
        _interacteble.OnInteract.AddListener(OnInteract);
    }

    private void OnDisable()
    {
        _interacteble.OnInteract.RemoveListener(OnInteract);
    }

    private void OnInteract()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("IsOpen",_isOpen);
    }
}
