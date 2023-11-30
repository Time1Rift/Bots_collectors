using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Minion minion))
        {
            transform.SetParent(minion.transform);
            Destroy(_rigidbody);
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
    }
}