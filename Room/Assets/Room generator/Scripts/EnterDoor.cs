using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class EnterDoor : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerEntered = new();
    private Collider _trigger;
    private bool _entered;

    public UnityEvent PlayerEntered => _playerEntered;

    public void Close()
    {
        _trigger.isTrigger = false;
    }

    protected void Awake()
    {
        _trigger= GetComponent<Collider>();
        _trigger.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_entered == false)
        {
            _playerEntered.Invoke();
            _entered = true;
        }
    }
}