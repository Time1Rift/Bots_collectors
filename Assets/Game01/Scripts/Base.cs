using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Scanner))]
public class Base : MonoBehaviour
{
    private List<Minion> _minions = new List<Minion>();
    private Scanner _scanner;
    private List<Collider> _resources = new List<Collider>();
    private Collider _resource;

    private void Start()
    {
        _scanner = GetComponent<Scanner>();

        for (int i = 0; i < transform.childCount; i++)
            _minions.Add(transform.GetChild(i).GetComponent<Minion>());
    }

    private void FixedUpdate()
    {
        if (_resources.Count == 0)
            _resources = _scanner.Scan();

        for (int i = 0; i < _minions.Count; i++)
        {
            if (_minions[i].IsFree && _resources.Count > 0 && _resources[_resources.Count - 1] != null)
            {
                _resource = _resources[_resources.Count - 1];
                _resources.Remove(_resource);
                _minions[i].SetTargetPosition(_resource.transform.position);
            }
        }
    }
}