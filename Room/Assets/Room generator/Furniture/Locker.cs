using System.Collections;
using UnityEditor;
using UnityEngine;

public class Locker : MonoBehaviour
{
    [SerializeField] private Interacteble _interactZone;
    [SerializeField] private Vector3 _openPosition;
    [SerializeField] private Vector3 _closePosition;
    [SerializeField] private bool _isOpen;
    [SerializeField] private float _openSpeed = 1f;

    public bool IsOpen
    {
        get
        {
            return _isOpen;
        }
        set
        {
            if (value)
            {
                Open();
            }
            else
            {
                Close();
            }
            _isOpen = value;
        }
    }

    private void Interacted(InteractInfo info)
    {
        IsOpen = !IsOpen;
    }

    public void Open()
    {
        StartCoroutine(MoveCorutine(_openPosition));
    }

    public void Close()
    {
        StartCoroutine(MoveCorutine(_closePosition));
    }

    private IEnumerator MoveCorutine(Vector3 newPosition)
    {
        _interactZone.CanInteract = false;
        while (transform.localPosition != newPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, newPosition, Time.deltaTime * _openSpeed);
            yield return null;
        }
        _interactZone.CanInteract = true;
    }

    private void Awake()
    {
        _closePosition = transform.localPosition;
    }

    private void OnEnable()
    {
        _interactZone.OnInteract.AddListener(Interacted);
    }

    private void OnValidate()
    {
        if (IsOpen)
        {
            transform.localPosition = _openPosition;
            return;
        }
        transform.localPosition = _closePosition;
    }
}