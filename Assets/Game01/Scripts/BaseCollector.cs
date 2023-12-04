using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseCollector : MonoBehaviour
{
    private int _point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Minion minion))
        {
            Resource resource = minion.GetComponentInChildren<Resource>();

            if (resource != null)
            {
                _point++;
                Debug.Log("ресурсов - " + _point);
                minion.SubmitResource(resource);
            }            
        }
    }
}