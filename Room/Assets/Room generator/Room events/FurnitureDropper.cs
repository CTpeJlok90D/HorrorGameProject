using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDropper : RoomEvent
{
    [SerializeField] private List<GameObject> _posibleFunitureDrop;
    [SerializeField] private float _force;
    [SerializeField] private float _maxTime;
    [SerializeField] private float _minTime;

    private float _currentTime;
    private float _requestTime;

    public override void OnPlayerEnter()
    {
        _requestTime = Random.Range(_minTime, _maxTime);
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(TimerCorutine());
    }

    public IEnumerator TimerCorutine()
    {
        while (_currentTime < _requestTime)
        {
            _currentTime += Time.deltaTime;
            yield return null;
        }
        Drop();
    }

    public void Drop()
    {
        GameObject selectedFurniture = _posibleFunitureDrop.RandomElemet();
        Rigidbody furnitureRigidbody = selectedFurniture.AddComponent<Rigidbody>();
        furnitureRigidbody.AddForce(Vector3.up * _force);
    }

    private void OnValidate()
    {
        if (_maxTime < _minTime)
        {
            _maxTime = _minTime;
        }
    }
}
