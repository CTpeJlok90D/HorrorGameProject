using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Container _inventory;
    [SerializeField] private float _interactDistance;

    public Transform CameraTransform => _camera;
    public Container Inventory => _inventory;
    public float InteractDistance => _interactDistance;

    private void OnEnable()
    {
        InputSingletone.Instance.Player.Interact.started += OnInteract;
    }

    private void OnDisable()
    {
        InputSingletone.Instance.Player.Interact.started -= OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Ray ray = new(_camera.position, _camera.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _interactDistance) &&
            hit.collider.TryGetComponent(out Interacteble interacteble))
        {
            InteractInfo info = new InteractInfo()
            {
                Inventory = _inventory
            };
            interacteble.Interact(info);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_camera.position, _camera.position + _camera.forward * _interactDistance);
    }
}
