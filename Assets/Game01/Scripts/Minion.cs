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

    public bool IsFree => _isFree;

    private void Update()
    {
        if (_isFree == false && _isHolds == false)
        {
            Movement(_targetPosition);

            if (transform.childCount > 0)
                _isHolds = true;
        }

        if (_isHolds == true)
        {
            Movement(_positionBase.position);

            if (transform.childCount == 0)
            {
                transform.position = transform.position;
                _isHolds = false;
                _isFree = true;
            }
        }
    }

    public bool TryHandsBusy() => transform.childCount == 0;

    public void SetTargetPosition(Vector3 position)
    {
        _targetPosition = position;
        _isFree = false;
    }

    private void Movement(Vector3 position)
    {
        transform.forward = position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, position, _speed * Time.deltaTime);
    }
}