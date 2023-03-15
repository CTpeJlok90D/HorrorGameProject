using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private Door _lockedDoor;
    [SerializeField] private Interacteble _interacteble;
    [SerializeField] private ItemData _key;

    protected void Awake()
    {
        _lockedDoor.IsLocked = true;
    }

    public void Unlock()
    {
        _lockedDoor.IsLocked = false;
        Destroy(gameObject);
    }

    protected void OnEnable()
    {
        _interacteble.OnInteract.AddListener(Interact);
    }

    protected void OnDisable()
    {
        _interacteble.OnInteract.RemoveListener(Interact);
    }

    private void Interact(InteractInfo info)
    {
        if (info.Inventory.RemoveItem(_key))
        {
            Unlock();
        }
    }
}
