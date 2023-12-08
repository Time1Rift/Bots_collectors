using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Base))]
public class BaseCollector : MonoBehaviour
{
    private int _point;
    private Base _base;

    private void Awake()
    {
        _base = GetComponent<Base>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Minion minion))
        {
            Resource resource = minion.GetComponentInChildren<Resource>();

            if (resource != null)
            {
                _point++;
                Debug.Log($"В { _base.name} ресурсов - { _point}");
                minion.SubmitResource(resource);
                _base.AddMinion(minion);
            }            
        }
    }
}