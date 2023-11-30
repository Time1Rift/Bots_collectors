using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private int _point;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Resource resource))
        {
            _point++;
            Debug.Log(_point);
            Destroy(resource.gameObject);
        }
    }
}