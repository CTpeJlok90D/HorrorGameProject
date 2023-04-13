using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractView : MonoBehaviour
{
    [SerializeField] private GameObject _interactIdicator;
    [SerializeField] private PlayerInteract _playerInteract;
    private void Update()
    {
        Ray ray = new(_playerInteract.CameraTransform.position, _playerInteract.CameraTransform.forward);

        _interactIdicator.SetActive(
            Physics.Raycast(ray, out RaycastHit hit, _playerInteract.InteractDistance) &&
            hit.collider.TryGetComponent(out Interacteble interacteble));
        
    }
}
