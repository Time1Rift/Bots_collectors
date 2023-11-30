using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] private Transform _positionBase;
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;
    private bool _isHolds = false;
    private bool _isFree = true;
    private Coroutine _movement;

    public bool IsFree => _isFree;

    private void OnDisable()
    {
        StopCoroutineMovement();
    }

    private void Update()
    {
        if (_isFree == false && _isHolds == false)
        {
            StopCoroutineMovement();
            _movement = StartCoroutine(Movement(_targetPosition));

            if (transform.childCount > 0)
            {
                StopCoroutineMovement();
                _isHolds = true;
            }                
        }

        if(_isHolds == true)
        {
            StopCoroutineMovement();
            _movement = StartCoroutine(Movement(_positionBase.position));

            if (transform.childCount == 0)
            {
                StopCoroutineMovement();
                _isHolds = false;
                _isFree = true;
            }                
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        _targetPosition = position;
        _isFree = false;
    }

    private void StopCoroutineMovement()
    {
        if (_movement != null)
            StopCoroutine(_movement);
    }

    private IEnumerator Movement(Vector3 position)
    {
        while (enabled)
        {
            transform.forward = position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, position, _speed * Time.deltaTime);
            yield return null;
        }        
    }
}