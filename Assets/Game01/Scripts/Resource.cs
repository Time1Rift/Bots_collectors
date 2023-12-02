using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        float height = 0.5f;

        if (collision.collider.TryGetComponent(out Minion minion))
        {
            if (minion.TryHandsBusy())
            {
                transform.SetParent(minion.transform);
                transform.position = new Vector3(transform.position.x, height, transform.position.z);
            }
        }
    }
}