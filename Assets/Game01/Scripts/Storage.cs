using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private int _point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Minion minion))
        {
            if (minion.transform.childCount > 0)
            {
                _point++;
                Debug.Log("ресурсов - " + _point);
                minion.SubmitResource();
            }            
        }
    }
}