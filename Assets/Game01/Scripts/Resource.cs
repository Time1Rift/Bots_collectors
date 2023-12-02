using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool _isFound = false;

    public bool IsFound => _isFound;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float positionFeight = 0.5f;

        if (collision.collider.TryGetComponent(out Minion minion))
        {
            if (minion.TryHandsBusy())
            {
                transform.SetParent(minion.transform);
                Destroy(_rigidbody);
                transform.position = new Vector3(transform.position.x, positionFeight, transform.position.z);
            }
        }
    }

    public void ChangeStatus()
    {
        _isFound = true;
    }
}