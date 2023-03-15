using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private bool _isOpen = false;
    [SerializeField] private bool _isLocked = false;
    [SerializeField] private UnityEvent<bool> _openStateChanged = new();
    [SerializeField] private UnityEvent _closed = new();
    [SerializeField] private UnityEvent _opened = new();
    [SerializeField] private UnityEvent _playerEntered = new();
    [SerializeField] private UnityEvent _locked = new();
    [SerializeField] private UnityEvent _unlocked = new();
    [SerializeField] private UnityEvent<bool> _lockStateChanged = new();
    [SerializeField] private Transform _view;
    [SerializeField] private float _openedAngle = 90;
    [SerializeField] private float _openSpeed = 1f;

    [SerializeField] private Interacteble _doorHandle;

    public UnityEvent<bool> StateChanged => _openStateChanged;
    public UnityEvent Closed => _closed;
    public UnityEvent Opened => _opened;
    public UnityEvent PlayerEntered => _playerEntered;
    public UnityEvent Locked => _locked;
    public UnityEvent Unlocked => _unlocked;
    public UnityEvent<bool> LockStateChanged => _lockStateChanged;
    public Transform View => _view;

    public float OpenAngle => _openedAngle;
    public float OpenSpeed => _openSpeed;
    public Interacteble DoorHandle => _doorHandle;

    public bool IsOpen
    {
        get
        {
            return _isOpen;
        }
        set
        {
            if (IsLocked)
            {
                return;
            }

            _isOpen = value;
            _openStateChanged.Invoke(_isOpen);

            if (_isOpen)
            {
                StartCoroutine(RotateDoorCorotine(_openedAngle));
                _opened.Invoke();
            }
            else
            {
                StartCoroutine(RotateDoorCorotine(0));
                _closed.Invoke();
            }
        }
    }

    public bool IsLocked
    {
        get
        {
            return _isLocked;
        }
        set
        {
            _isLocked = value;
            _lockStateChanged.Invoke(_isLocked);

            if (_isLocked)
            {
                _doorHandle.OnInteract.RemoveListener(OnInteract);
                _locked.Invoke();
            }
            else
            {
                _doorHandle.OnInteract.AddListener(OnInteract);
                _unlocked.Invoke();
            }
        }
    }

    public void OnInteract(InteractInfo info)
    {
        IsOpen = !IsOpen;
    }

    public void Close()
    {
        IsOpen = false;
    }

    public void Open()
    {
        IsOpen = true;
    }

    public void Lock()
    {
        IsLocked = true;
    }

    public void Unlock()
    {
        IsLocked = false;
    }

    public void LockPermanently()
    {
        IsLocked = true;
        Destroy(DoorHandle);
    }

    private IEnumerator RotateDoorCorotine(float targetAngle)
    {
        if (_doorHandle != null)
        {
            _doorHandle.enabled = false;
        }

        float lerpCoefficient = 0;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, targetAngle, 0));
        while (lerpCoefficient <= 1)
        {
            _view.localRotation = Quaternion.Lerp(_view.localRotation, targetRotation, lerpCoefficient);
            lerpCoefficient += Mathf.Clamp(Time.deltaTime * _openSpeed,0,1);
            yield return null;
        }

        if (_doorHandle != null)
        {
            _doorHandle.enabled = true;
        }
    }

    protected void OnEnable()
    {
        if (IsLocked == false)
        {
            _doorHandle.OnInteract.AddListener(OnInteract);
        }
    }

    protected void OnDisable()
    {
        _doorHandle.OnInteract.RemoveListener(OnInteract);
    }

    protected void OnTriggerEnter(Collider other)
    {
        PlayerEntered.Invoke();
    }

    private void OnValidate()
    {
        if (_openedAngle > 360)
        {
            _openedAngle = 360;
        }

        if (_openedAngle < 0)
        {
            _openedAngle = 0;
        }
    }
}
