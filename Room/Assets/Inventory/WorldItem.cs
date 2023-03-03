using UnityEngine;

[RequireComponent(typeof(Interacteble))]
public class WorldItem : MonoBehaviour
{
    [SerializeField] private Stack _stack;

    private Interacteble _interacteble;

    public Stack Stack => _stack;

    protected void Awake()
    {
        _interacteble= GetComponent<Interacteble>();
    }

    protected void OnEnable()
    {
        _interacteble.OnInteract.AddListener(OnInteract);
    }

    protected void OnDisable()
    {
        _interacteble.OnInteract.RemoveListener(OnInteract);
    }

    private void OnInteract(InteractInfo info)
    {
        Stack stack = info.Inventory.AddStack(_stack);

        if (stack == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnValidate()
    {
        _stack.Count = _stack.Count;
    }
}
