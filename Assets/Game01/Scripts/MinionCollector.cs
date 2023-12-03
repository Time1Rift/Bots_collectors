using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCollector : MonoBehaviour
{
    private bool _haveResource;

    public event Action ResourceCollected;

    private void Update()
    {
        _haveResource = transform.childCount > 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        float height = 0.5f;

        if (other.TryGetComponent(out Resource resource) && _haveResource == false && resource.GetComponentInParent<Minion>() == false)
        {
            resource.transform.SetParent(transform);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            ResourceCollected?.Invoke();
        }
    }
}